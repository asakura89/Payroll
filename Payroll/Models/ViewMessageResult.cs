using System;

namespace Payroll.Models
{
    public class ViewMessageResult
    {
        public Int16 Status { get; private set; }
        public String Message { get; private set; }
        public String Content { get; private set; }

        public ViewMessageResult(Int16 status, String message, String content)
        {
            Status = status;
            Message = message;
            Content = content;
        }

        public ViewMessageResult(Int16 status, String message) : this(status, message, String.Empty) { }
    }
}