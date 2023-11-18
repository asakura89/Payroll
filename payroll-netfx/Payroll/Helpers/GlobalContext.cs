using System;
using System.Collections.Generic;
using System.Linq;
using Arvy;
using Emi;
using Meutia;
using Ria;

namespace Payroll.Helpers {
    public static class GlobalContext {
        public static IServiceRegistry ServiceRegistry { get; } = new ServiceRegistry();

        //public static ILoggerAdapter Logger { get; private set; }

        //public static Emitter Emitter { get; private set; }

        //public static PipelineExecutor PipelineExecutor { get; private set; }

        //public static void Initialize() {
        //    //Emitter = new XmlConfigEmitterLoader().Load();
        //    //PipelineExecutor = new XmlConfigPipelineLoader().Load();
        //    //ServiceRegistry = new ServiceRegistry();
        //}



        //public static void Initialize() {
        //    _InitializeLogger();
        //    Logger = DIContainer.Resolve<ILoggerAdapter>();

        //    var globalCtxConfig = new AdminSiteGlobalContextConfig();
        //    globalCtxConfig.Load();

        //    Emitter = new XmlConfigEmitterLoader(globalCtxConfig.XFCoreEventConfigFilePath).Load();
        //    PipelineExecutor = new XmlConfigPipelineLoader(globalCtxConfig.XFCorePipelineConfigFilePath).Load();
        //}

        //static void _InitializeLogger() {
        //    XmlConfigurator.Configure();
        //    DIContainer.Register<ILoggerAdapter, DefaultLoggerAdapter>();
        //}
    }
}