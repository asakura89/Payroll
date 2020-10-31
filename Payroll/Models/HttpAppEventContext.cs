using System;
using System.Web;

namespace Payroll.Models {
    public class HttpAppEventContext {
        public String EventName { get; }
        public Object Sender { get; }
        public EventArgs Args { get; }
        public HttpContext HttpContext { get; }

        public HttpAppEventContext(String eventName, Object sender, EventArgs args = null, HttpContext httpContext = null) {
            if (String.IsNullOrEmpty(eventName))
                throw new ArgumentNullException(nameof(eventName));

            if (sender == null)
                throw new ArgumentNullException(nameof(sender));

            EventName = eventName;
            Sender = sender;
            Args = args;
            HttpContext = httpContext;
        }
    }
}