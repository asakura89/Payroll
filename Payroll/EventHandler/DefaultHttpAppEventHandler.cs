using System;
using System.IO;
using System.Web;
using Emi;
using log4net;
using Shiro;

namespace Payroll.EventHandler {
    public class DefaultHttpAppEventHandler {
        public void OnAppStart(Object source, EmitterEventArgs e) {
            String configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config.xml");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configFilePath));

            LogExt.UseExternalLogger(LogManager.GetLogger(typeof(DefaultHttpAppEventHandler).FullName));
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {
                e.EventName,
                Sender = source.GetType().FullName,
                Args = e.Data["EventArgs"] as EventArgs
            });
        }

        public void OnAppBeginRequest(Object source, EmitterEventArgs e) =>
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {
                e.EventName,
                Sender = source.GetType().FullName,
                Args = e.Data["EventArgs"] as EventArgs
            });

        public void OnAppEndRequest(Object source, EmitterEventArgs e) =>
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {
                e.EventName,
                Sender = source.GetType().FullName,
                Args = e.Data["EventArgs"] as EventArgs
            });

        public void OnAppEnd(Object source, EmitterEventArgs e) =>
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {
                e.EventName,
                Sender = source.GetType().FullName,
                Args = e.Data["EventArgs"] as EventArgs
            });

        public void OnAppError(Object source, EmitterEventArgs e) {
            String caller = this.GetFormattedCallerInfoString();
            LogExt.Debug(caller, new {
                e.EventName,
                Sender = source.GetType().FullName,
                Args = e.Data["EventArgs"] as EventArgs
            });

            Exception lastError = (e.Data["HttpContext"] as HttpContext).Server.GetLastError();
            if (lastError != null)
                LogExt.Error(caller, lastError);
        }

        public void OnAppSessionStart(Object source, EmitterEventArgs e) =>
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {
                e.EventName,
                Sender = source.GetType().FullName,
                Args = e.Data["EventArgs"] as EventArgs
            });

        public void OnAppSessionEnd(Object source, EmitterEventArgs e) =>
            LogExt.Debug(this.GetFormattedCallerInfoString(), new {
                e.EventName,
                Sender = source.GetType().FullName,
                Args = e.Data["EventArgs"] as EventArgs
            });
    }
}