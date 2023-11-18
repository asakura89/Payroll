using System;

namespace Payroll.Models {
    public class ViewMessageResult {
        public Int16 Status { get; set; }
        public String Message { get; set; }
        public String Content { get; set; }

        public ViewMessageResult(Int16 status, String message, String content) {
            Status = status;
            Message = message;
            Content = content;
        }

        public ViewMessageResult(Int16 status, String message) : this(status, message, String.Empty) { }
    }
}