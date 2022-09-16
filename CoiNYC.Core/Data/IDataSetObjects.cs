using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Core.Data
{
    public interface IDataSetObjects
    {
        List<T> GetResult<T>();
    }
}
