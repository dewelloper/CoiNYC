using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Domain.Commons
{
    public enum OwnerType : byte
    {
        None = 0,
        Product = 1,
        Collection = 2,
        Banner = 3,
        Category = 4,
        Brand = 5,
        DynamicPage = 6,
        Information = 7,
        Seo = 8,
        Menu = 9,
        Showcase = 10,
        Shipper = 11,
        ProductOption = 12,
        ProductOptionValue = 13,
        HtmlBlock = 14,
        ExtraDescription = 15,
        ProductExtraDescription = 16,
        EmailTemplate = 17,
        PaymentMethod = 18
    }

}
