using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Payroll.Helpers;

namespace Payroll {
    public class MvcApplication : HttpApplication {
        void InitializeApp() {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Register javascript, css, and others
            BundleConfig.RegisterNormalBundles(BundleTable.Bundles);
            GlobalContext.Initialize();
        }

        protected void Application_Start(Object sender, EventArgs e) {
            InitializeApp();
            GlobalContext.Emitter.Emit("App.Start", HttpAppEventArgsFactory.CreateForAppStart(sender, e));
        }

        protected void Application_BeginRequest(Object sender, EventArgs e) =>
            GlobalContext.Emitter.Emit("App.BeginRequest",
                HttpAppEventArgsFactory.CreateForAppBeginRequest(sender, e, HttpContext.Current));

        protected void Application_EndRequest(Object sender, EventArgs e) =>
            GlobalContext.Emitter.Emit("App.EndRequest",
                HttpAppEventArgsFactory.CreateForAppEndRequest(sender, e, HttpContext.Current));

        protected void Application_End(Object sender, EventArgs e) =>
            GlobalContext.Emitter.Emit("App.End",
                HttpAppEventArgsFactory.CreateForAppEnd(sender, e, HttpContext.Current));

        protected void Application_Error(Object sender, EventArgs e) =>
            GlobalContext.Emitter.Emit("App.Error",
                HttpAppEventArgsFactory.CreateForAppError(sender, e, HttpContext.Current));

        protected void Session_Start(Object sender, EventArgs e) =>
            GlobalContext.Emitter.Emit("App.SessionStart",
                HttpAppEventArgsFactory.CreateForAppSessionStart(sender, e, HttpContext.Current));

        protected void Session_End(Object sender, EventArgs e) =>
            GlobalContext.Emitter.Emit("App.SessionEnd",
                HttpAppEventArgsFactory.CreateForAppSessionEnd(sender, e, HttpContext.Current));
    }
}