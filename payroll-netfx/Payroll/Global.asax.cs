using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Emi;
using Payroll.Helpers;
using Payroll.Pipeline;
using Reflx;
using Ria;

namespace Payroll {
    public class MvcApplication : HttpApplication {
        event EventHandler<EmitterEventArgs> AppStart;
        event EventHandler<EmitterEventArgs> AppBeginRequest;
        event EventHandler<EmitterEventArgs> AppEndRequest;
        event EventHandler<EmitterEventArgs> AppEnd;
        event EventHandler<EmitterEventArgs> AppError;
        event EventHandler<EmitterEventArgs> AppSessionStart;
        event EventHandler<EmitterEventArgs> AppSessionEnd;

        void DynamicLoadAssemblies() {
            AppDomain.CurrentDomain.AssemblyResolve += DefaultAssemblyResolver.Resolve;
            ReflectionExt.LoadAssemblies(AppDomain.CurrentDomain.BaseDirectory);
        }

        void BuildCompositionRoot() {
            String pipelineAndEventConfig = $"{AppDomain.CurrentDomain.BaseDirectory}\\payroll.config.xml";

            GlobalContext.ServiceRegistry.RegisterService<IEventRegistrar>(() => new XmlConfigEventRegistrar(pipelineAndEventConfig));
            GlobalContext.ServiceRegistry.RegisterService<IPipelineExecutor>(() => new XmlConfigPipelineLoader(pipelineAndEventConfig).Load());
            GlobalContext.ServiceRegistry.RegisterService<IPipelineResultHandler, PipelineResultHandler>();
        }

        void InitializeApp() {
            DynamicLoadAssemblies();
            BuildCompositionRoot();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Register javascript, css, and others
            BundleConfig.RegisterNormalBundles(BundleTable.Bundles);
        }

        protected void Application_Start(Object sender, EventArgs e) {
            InitializeApp();

            AppStart?.Invoke(this, new EmitterEventArgs(nameof(MvcApplication.AppStart), new Dictionary<String, Object> {
                ["HttpContext"] = HttpContext.Current,
                ["EventArgs"] = e
            }));
        }

        protected void Application_BeginRequest(Object sender, EventArgs e) =>
            AppBeginRequest?.Invoke(this, new EmitterEventArgs(nameof(MvcApplication.AppBeginRequest), new Dictionary<String, Object> {
                ["HttpContext"] = HttpContext.Current,
                ["EventArgs"] = e
            }));

        protected void Application_EndRequest(Object sender, EventArgs e) =>
            AppEndRequest?.Invoke(this, new EmitterEventArgs(nameof(MvcApplication.AppEndRequest), new Dictionary<String, Object> {
                ["HttpContext"] = HttpContext.Current,
                ["EventArgs"] = e
            }));

        protected void Application_End(Object sender, EventArgs e) =>
            AppEnd?.Invoke(this, new EmitterEventArgs(nameof(MvcApplication.AppEnd), new Dictionary<String, Object> {
                ["HttpContext"] = HttpContext.Current,
                ["EventArgs"] = e
            }));

        protected void Application_Error(Object sender, EventArgs e) =>
            AppError?.Invoke(this, new EmitterEventArgs(nameof(MvcApplication.AppError), new Dictionary<String, Object> {
                ["HttpContext"] = HttpContext.Current,
                ["EventArgs"] = e
            }));

        protected void Session_Start(Object sender, EventArgs e) =>
            AppSessionStart?.Invoke(this, new EmitterEventArgs(nameof(MvcApplication.AppSessionStart), new Dictionary<String, Object> {
                ["HttpContext"] = HttpContext.Current,
                ["EventArgs"] = e
            }));

        protected void Session_End(Object sender, EventArgs e) =>
            AppSessionEnd?.Invoke(this, new EmitterEventArgs(nameof(MvcApplication.AppSessionEnd), new Dictionary<String, Object> {
                ["HttpContext"] = HttpContext.Current,
                ["EventArgs"] = e
            }));
    }
}