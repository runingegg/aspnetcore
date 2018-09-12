namespace WebSharper.AspNetCore.Tests

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open WebSharper.AspNetCore

type Startup() =

    member this.ConfigureServices(services: IServiceCollection) =
        services.AddSitelet<Website.MyWebsite>()
                .AddWebSharperRemoting<Website.RpcUserSession, Website.RpcUserSessionImpl>()
                .AddAuthentication("WebSharper")
                .AddCookie("WebSharper", fun options -> ())
        |> ignore

    member this.Configure(app: IApplicationBuilder, env: IHostingEnvironment) =
        if env.IsDevelopment() then app.UseDeveloperExceptionPage() |> ignore

        app.UseAuthentication()
            .UseWebSharper()
            .UseStaticFiles()
            .Run(fun context ->
                context.Response.StatusCode <- 404
                context.Response.WriteAsync("Fell through :("))
