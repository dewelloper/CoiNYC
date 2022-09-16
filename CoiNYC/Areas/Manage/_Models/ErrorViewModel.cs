using System;

namespace CoiNYC.Areas
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Error { get; set; }
    }
}