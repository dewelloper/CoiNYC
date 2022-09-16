using CoiNYC.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoiNYC.Domain.Article
{
    public class ArticleDto: BaseUniqueDTO
    {
        public string Name { get; set; }
    }

    //public class BrandDto : BaseUniqueDTO
    //{

    //    public string Name { get; set; }
    //    public SeoDto Seo { get; set; }
    //}
    //public class BrandGridDto : BaseUniqueDTO
    //{
    //    public string Name { get; set; }
    //    public string SeoUrl { get; set; }
    //}
}
