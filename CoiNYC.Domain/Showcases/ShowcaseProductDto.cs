using CoiNYC.Core.Data;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Domain.Showcases
{
    public class ShowcaseProductDto : BaseUniqueDTO
    {
        public int ShowcaseId { get; set; }
        public int ProductId { get; set; }
        public int DisplayOrder { get; set; }
        public string ShowcaseName { get; set; }
        public string ProductName { get; set; }
    }
}
