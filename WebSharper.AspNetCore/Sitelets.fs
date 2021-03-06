// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}
module WebSharper.AspNetCore.Sitelets

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Http.Features
open WebSharper.Sitelets

let private writeResponse (resp: Task<Http.Response>) (out: HttpResponse) =
    resp.ContinueWith(fun (t: Task<Http.Response>) ->
        let resp = t.Result
        out.StatusCode <- resp.Status.Code
        for name, hs in resp.Headers |> Seq.groupBy (fun h -> h.Name) do
            let values =
                [| for h in hs -> h.Value |]
                |> Microsoft.Extensions.Primitives.StringValues
            out.Headers.Append(name, values)
        resp.WriteBody(out.Body)
    )

let Middleware (options: WebSharperOptions) =
    let sitelet =
        match options.Sitelet with
        | Some s -> Some s
        | None -> Loading.DiscoverSitelet options.Assemblies
    match sitelet with
    | None ->
        Func<_,_,_>(fun (_: HttpContext) (next: Func<Task>) -> next.Invoke())
    | Some sitelet ->
        Func<_,_,_>(fun (httpCtx: HttpContext) (next: Func<Task>) ->
            let ctx = Context.GetOrMake httpCtx options
            match sitelet.Router.Route ctx.Request with
            | Some endpoint ->
                let content = sitelet.Controller.Handle endpoint
                let response = Content.ToResponse content ctx |> Async.StartAsTask
                let syncIOFeature = httpCtx.Features.Get<IHttpBodyControlFeature>();
                if not (isNull syncIOFeature) then
                    syncIOFeature.AllowSynchronousIO <- true
                writeResponse response httpCtx.Response
            | None -> next.Invoke()
        )
