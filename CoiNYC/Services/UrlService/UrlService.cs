using CoiNYC.Domain.Products;
using Microsoft.AspNetCore.Mvc;
using System;


namespace CoiNYC.Services
{
    public class UrlService : IUrlService
    {
        public IUrlHelper urlHelper;

        public UrlService(IUrlHelper urlHelper)
        {
            this.urlHelper = urlHelper;
        }

        public IUrlHelper GetHelper()
        {
            return urlHelper;
        }

        public string GetUrl(ProductShortDto product, string mode)
        {
            if (!String.IsNullOrEmpty(product.SeoUrl))
            {
                //return urlHelper.RouteUrl("Default_Seo", new { seoUrl = product.SeoUrl, mode = mode });
                if (String.IsNullOrEmpty(mode))
                    return product.SeoUrl;

                return String.Format("{0}?mode={1}", product.SeoUrl, mode);
            }


            return urlHelper.Action("Detail", "Product", new { code = product.Code, mode = mode });
        }

        //public void SetUrls(ProductList.FilterContainer currentFilters, ProductList.FilterContainer allFilters, ProductComponentModel components)
        //{
        //    int pageIndex = components.PageIndex;
        //    components.PageIndex = 1;

        //    foreach (var filterItem in currentFilters.Categories)
        //    {
        //        if (filterItem.IsSelected)
        //            filterItem.SeoUrl = Remove(components.Categories, filterItem.Id, components, allFilters);
        //        else
        //            filterItem.SeoUrl = Add(components.Categories, filterItem.Id, components, allFilters);
        //    }

        //    foreach (var filterItem in currentFilters.Brands)
        //    {
        //        if (filterItem.IsSelected)
        //            filterItem.SeoUrl = Remove(components.Brands, filterItem.Id, components, allFilters);
        //        else
        //            filterItem.SeoUrl = Add(components.Brands, filterItem.Id, components, allFilters);
        //    }


        //    foreach (var filterItem in currentFilters.Collections)
        //    {
        //        if (filterItem.IsSelected)
        //            filterItem.SeoUrl = Remove(components.Collections, filterItem.Id, components, allFilters);
        //        else
        //            filterItem.SeoUrl = Add(components.Collections, filterItem.Id, components, allFilters);
        //    }

        //    components.PageIndex = pageIndex;
        //}

        //public string GetPageUrl(int pageIndex, ProductList.FilterContainer allFilters, ProductComponentModel components)
        //{



        //    string url = String.Empty;
        //    if (pageIndex != components.PageIndex)
        //    {
        //        var tempIndex = components.PageIndex;
        //        components.PageIndex = pageIndex;
        //        url = GetUrl(allFilters, components);
        //        components.PageIndex = tempIndex;
        //    }

        //    return url;
        //}

        //public string GetPageSizeUrl(int pageSize, ProductList.FilterContainer allFilters, ProductComponentModel components)
        //{



        //    string url = String.Empty;
        //    if (pageSize != components.PageSize)
        //    {
        //        var tempSize = components.PageSize;
        //        components.PageSize = pageSize;
        //        url = GetUrl(allFilters, components);
        //        components.PageSize = tempSize;
        //    }



        //    return url;
        //}


        //private string Add(HashSet<int> filter, int id, ProductComponentModel components, ProductList.FilterContainer allFilters)
        //{
        //    string seoUrl = null;
        //    filter.Add(id);
        //    seoUrl = GetUrl(allFilters, components);
        //    filter.Remove(id);
        //    return seoUrl;
        //}

        //private string Remove(HashSet<int> filter, int id, ProductComponentModel components, ProductList.FilterContainer allFilters)
        //{
        //    string seoUrl = null;
        //    filter.Remove(id);
        //    seoUrl = GetUrl(allFilters, components);
        //    filter.Add(id);
        //    return seoUrl;
        //}


        //public string GetUrl(ProductList.FilterContainer allFilters, ProductComponentModel components)
        //{
        //    List<string> queryString = new List<string>();
        //    if (components.PageIndex > 1)
        //        queryString.Add(String.Format("page={0}", components.PageIndex));

        //    if (components.PageSize != 25)
        //        queryString.Add(String.Format("psize={0}", components.PageSize));

        //    if (components.IsNew.HasValue)
        //    {
        //        queryString.Add(String.Format("newSeason=true"));
        //    }

        //    string seoUrl = null;

        //    if (components.TotalSelection != 1)
        //    {
        //        if (components.Categories != null && components.Categories.Count > 0)
        //            queryString.Add(String.Format("cat={0}", String.Join(",", components.Categories.Select(x => x.ToString()))));

        //        if (components.Brands != null && components.Brands.Count > 0)
        //            queryString.Add(String.Format("brand={0}", String.Join(",", components.Brands.Select(x => x.ToString()))));

        //        if (components.Collections != null && components.Collections.Count > 0)
        //            queryString.Add(String.Format("col={0}", String.Join(",", components.Collections.Select(x => x.ToString()))));
        //    }
        //    else
        //    {
        //        if (components.IsSingleCategory)
        //            seoUrl = allFilters.Categories.Where(x => x.Id == components.Categories.First()).Select(x => x.SeoUrl).FirstOrDefault();

        //        if (components.IsSingleBrand)
        //            seoUrl = allFilters.Brands.Where(x => x.Id == components.Brands.First()).Select(x => x.SeoUrl).FirstOrDefault();

        //        if (components.IsSingleCollection)
        //            seoUrl = allFilters.Collections.Where(x => x.Id == components.Collections.First()).Select(x => x.SeoUrl).FirstOrDefault();

        //    }

        //    seoUrl = seoUrl ?? "/products/";

        //    if (queryString.Count == 0)
        //        return seoUrl;
        //    else
        //        return seoUrl + "?" + String.Join("&", queryString);
        //}
    }
}