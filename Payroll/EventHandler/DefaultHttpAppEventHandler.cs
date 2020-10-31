using System;
using System.IO;
using Emi;
using Payroll.Models;
using Shiro;

namespace Payroll.EventHandler {
    public class DefaultHttpAppEventHandler {
        public void OnAppStart(EmitterEventArgs e) {
            String configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config.xml");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configFilePath));

            var ctx = e.Context as HttpAppEventContext;
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {ctx.EventName, Sender = ctx.Sender.GetType().FullName, ctx.Args});
        }

        public void OnAppBeginRequest(EmitterEventArgs e) {
            var ctx = e.Context as HttpAppEventContext;
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {ctx.EventName, Sender = ctx.Sender.GetType().FullName, ctx.Args});
        }

        public void OnAppEndRequest(EmitterEventArgs e) {
            var ctx = e.Context as HttpAppEventContext;
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {ctx.EventName, Sender = ctx.Sender.GetType().FullName, ctx.Args});
        }

        public void OnAppEnd(EmitterEventArgs e) {
            var ctx = e.Context as HttpAppEventContext;
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {ctx.EventName, Sender = ctx.Sender.GetType().FullName, ctx.Args});
        }

        public void OnAppError(EmitterEventArgs e) {
            String caller = this.GetFormattedCallerInfoString();
            var ctx = e.Context as HttpAppEventContext;
            LogExt.Debug(caller, new {ctx.EventName, Sender = ctx.Sender.GetType().FullName, ctx.Args});
            
            Exception lastError = ctx.HttpContext.Server.GetLastError();
            if (lastError != null)
                LogExt.Error(caller, lastError);
        }

        public void OnAppSessionStart(EmitterEventArgs e) {
            var ctx = e.Context as HttpAppEventContext;
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {ctx.EventName, Sender = ctx.Sender.GetType().FullName, ctx.Args});
        }

        public void OnAppSessionEnd(EmitterEventArgs e) {
            var ctx = e.Context as HttpAppEventContext;
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {ctx.EventName, Sender = ctx.Sender.GetType().FullName, ctx.Args});
        }
    }
}