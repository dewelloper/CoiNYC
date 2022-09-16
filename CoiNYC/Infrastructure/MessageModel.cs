using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoiNYC.Domain.Resources;

namespace CoiNYC.Infrastructure
{
    public class MessageModel
    {
        public string Message { get; set; }
        public string Title { get; set; }

        public static MessageModel NotExistingRecord => new MessageModel { Title = R.MSG_NotExistingRecord };
    }
}
