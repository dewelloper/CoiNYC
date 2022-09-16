using System;
using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Core.Data
{
    public class StoredProcedureResult
    {
        public int ErrorNo { get; set; }
        public string ErrorCode { get; set; }
        public bool IsSuccess { get; set; }
        public int AffectedRows { get; set; }

        public StoredProcedureResult()
        {
        }

        public StoredProcedureResult(string spName, int errorNo)
        {
            ErrorNo = errorNo;
            ErrorCode = "SP_" + spName + ErrorNo;
            IsSuccess = ErrorNo == 0;
        }

    }
}
