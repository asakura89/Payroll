using System;
using System.Web;
using Emi;
using Payroll.Models;

namespace Payroll.Helpers {
    public static class HttpAppEventArgsFactory {
        public static EmitterEventArgs CreateForAppStart(Object sender, EventArgs args) {
            var context = new HttpAppEventContext("App.Start", sender, args);
            return new EmitterEventArgs(context);
        }

        public static EmitterEventArgs CreateForAppBeginRequest(Object sender, EventArgs args, HttpContext httpCtx) {
            var context = new HttpAppEventContext("App.BeginRequest", sender, args, httpCtx);
            return new EmitterEventArgs(context);
        }

        public static EmitterEventArgs CreateForAppEndRequest(Object sender, EventArgs args, HttpContext httpCtx) {
            var context = new HttpAppEventContext("App.EndRequest", sender, args, httpCtx);
            return new EmitterEventArgs(context);
        }

        public static EmitterEventArgs CreateForAppEnd(Object sender, EventArgs args, HttpContext httpCtx) {
            var context = new HttpAppEventContext("App.End", sender, args, httpCtx);
            return new EmitterEventArgs(context);
        }

        public static EmitterEventArgs CreateForAppError(Object sender, EventArgs args, HttpContext httpCtx) {
            var context = new HttpAppEventContext("App.Error", sender, args, httpCtx);
            return new EmitterEventArgs(context);
        }

        public static EmitterEventArgs CreateForAppSessionStart(Object sender, EventArgs args, HttpContext httpCtx) {
            var context = new HttpAppEventContext("App.SessionStart", sender, args, httpCtx);
            return new EmitterEventArgs(context);
        }

        public static EmitterEventArgs CreateForAppSessionEnd(Object sender, EventArgs args, HttpContext httpCtx) {
            var context = new HttpAppEventContext("App.SessionEnd", sender, args, httpCtx);
            return new EmitterEventArgs(context);
        }
    }
}