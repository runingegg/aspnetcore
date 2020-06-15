//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.FSharp.Core;
using WebSharper;
using WebSharper.UI;
using WebSharper.UI.Templating;
using SDoc = WebSharper.UI.Doc;
using DomElement = WebSharper.JavaScript.Dom.Element;
using DomEvent = WebSharper.JavaScript.Dom.Event;
namespace WebSharper.AspNetCore.Tests.CSharp.Template
{
    [JavaScript]
    public class Main
    {
        string key = System.Guid.NewGuid().ToString();
        List<TemplateHole> holes = new List<TemplateHole>();
        Instance instance;
        public Main Title(string x) { holes.Add(TemplateHole.NewText("title", x)); return this; }
        public Main Title(View<string> x) { holes.Add(TemplateHole.NewTextView("title", x)); return this; }
        public Main MenuBar(Doc x) { holes.Add(TemplateHole.NewElt("menubar", x)); return this; }
        public Main MenuBar(IEnumerable<Doc> x) { holes.Add(TemplateHole.NewElt("menubar", SDoc.Concat(x))); return this; }
        public Main MenuBar(params Doc[] x) { holes.Add(TemplateHole.NewElt("menubar", SDoc.Concat(x))); return this; }
        public Main MenuBar(string x) { holes.Add(TemplateHole.NewText("menubar", x)); return this; }
        public Main MenuBar(View<string> x) { holes.Add(TemplateHole.NewTextView("menubar", x)); return this; }
        public Main Body(Doc x) { holes.Add(TemplateHole.NewElt("body", x)); return this; }
        public Main Body(IEnumerable<Doc> x) { holes.Add(TemplateHole.NewElt("body", SDoc.Concat(x))); return this; }
        public Main Body(params Doc[] x) { holes.Add(TemplateHole.NewElt("body", SDoc.Concat(x))); return this; }
        public Main Body(string x) { holes.Add(TemplateHole.NewText("body", x)); return this; }
        public Main Body(View<string> x) { holes.Add(TemplateHole.NewTextView("body", x)); return this; }
        public Main scripts(Doc x) { holes.Add(TemplateHole.NewElt("scripts", x)); return this; }
        public Main scripts(IEnumerable<Doc> x) { holes.Add(TemplateHole.NewElt("scripts", SDoc.Concat(x))); return this; }
        public Main scripts(params Doc[] x) { holes.Add(TemplateHole.NewElt("scripts", SDoc.Concat(x))); return this; }
        public Main scripts(string x) { holes.Add(TemplateHole.NewText("scripts", x)); return this; }
        public Main scripts(View<string> x) { holes.Add(TemplateHole.NewTextView("scripts", x)); return this; }
        public struct Vars
        {
            public Vars(Instance i) { instance = i; }
            readonly Instance instance;
        }
        public class Instance : WebSharper.UI.Templating.Runtime.Server.TemplateInstance
        {
            public Instance(WebSharper.UI.Templating.Runtime.Server.CompletedHoles v, Doc d) : base(v, d) { }
            public Vars Vars => new Vars(this);
        }
        public Instance Create() {
            var completed = WebSharper.UI.Templating.Runtime.Server.Handler.CompleteHoles(key, holes, new Tuple<string, WebSharper.UI.Templating.Runtime.Server.ValTy>[] {  });
            var doc = WebSharper.UI.Templating.Runtime.Server.Runtime.GetOrLoadTemplate("main", null, FSharpOption<string>.Some("Main.html"), "<html lang=\"en\">\n<head>\n    <meta charset=\"utf-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <title>${Title}</title>\n    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css\">\n    <style>\n        /* Sticky footer styles */\n        html {\n            position: relative;\n            min-height: 100%;\n        }\n\n        body {\n            /* Margin bottom by footer height */\n            margin-bottom: 60px;\n        }\n\n        .footer {\n            position: absolute;\n            bottom: 0;\n            width: 100%;\n            /* Set the fixed height of the footer here */\n            height: 60px;\n            background-color: #f5f5f5;\n        }\n\n        .container .text-muted {\n            margin: 20px 0;\n        }\n    </style>\n</head>\n<body>\n    <!-- Static navbar -->\n    <nav class=\"navbar navbar-default navbar-static-top\">\n        <div class=\"container\">\n            <div class=\"navbar-header\">\n                <button type=\"button\" class=\"navbar-toggle collapsed\" data-toggle=\"collapse\" data-target=\"#navbar\" aria-expanded=\"false\" aria-controls=\"navbar\">\n                    <span class=\"sr-only\">Toggle navigation</span>\n                    <span class=\"icon-bar\"></span>\n                    <span class=\"icon-bar\"></span>\n                </button>\n                <a class=\"navbar-brand\" href=\"#\">Your App</a>\n            </div>\n            <div id=\"navbar\" class=\"navbar-collapse collapse\">\n                <ul class=\"nav navbar-nav\" ws-hole=\"MenuBar\"></ul>\n                <ul class=\"nav navbar-nav navbar-right\">\n                    <li><a href=\"http://websharper.com\">websharper.com</a></li>\n                </ul>\n            </div><!--/.nav-collapse -->\n        </div>\n    </nav>\n    <div class=\"container\">\n        <div ws-replace=\"Body\">\n        </div>\n    </div>\n    <footer class=\"footer\">\n        <div class=\"container\">\n            <p class=\"text-muted\">\n                For an enhanced template that provides automatic GitHub deployment to Azure, fork from <a href=\"https://github.com/intellifactory/ClientServer.Azure\">GitHub</a>, or\n                read more <a href=\"http://websharper.com/blog-entry/4368/deploying-websharper-apps-to-azure-via-github\">here</a>.\n            </p>\n        </div>\n    </footer>\n    <script ws-replace=\"scripts\"></script>\n</body>\n</html>", null, completed.Item1, FSharpOption<string>.Some("main"), ServerLoad.WhenChanged, new Tuple<string, FSharpOption<string>, string>[] {  }, null, true, false, false);
            instance = new Instance(completed.Item2, doc);
            return instance;
        }
        public Doc Doc() => Create().Doc;
        [Inline] public Elt Elt() => (Elt)Doc();
    }
}