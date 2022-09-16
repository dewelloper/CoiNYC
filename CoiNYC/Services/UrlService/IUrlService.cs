using CoiNYC.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace CoiNYC.Services
{
    public interface IUrlService
    {
        string GetUrl(ProductShortDto product, string mode =null);
        IUrlHelper GetHelper();
        //string GetUrl(ProductList.FilterContainer allFilters, ProductComponentModel components);
        //void SetUrls(ProductList.FilterContainer currentFilters, ProductList.FilterContainer allFilters, ProductComponentModel components);
        //string GetPageUrl(int pageIndex, ProductList.FilterContainer allFilters, ProductComponentModel components);
        //string GetPageSizeUrl(int pageSize, ProductList.FilterContainer allFilters, ProductComponentModel components);
    }
}