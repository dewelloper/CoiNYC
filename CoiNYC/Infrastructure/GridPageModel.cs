using CoiNYC.Infrastructure.Builders;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MvcJqGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoiNYC.Infrastructure
{
    public class FilterModel
    {
        [BindingName(Name = "rows")]
        public int PageSize { get; set; }

        [BindingName(Name = "page")]
        public int PageIndex { get; set; }

        [BindingName(Name = "sord")]
        public string SortDirection { get; set; }

        [BindingName(Name = "sidx")]
        public string SortColumn { get; set; }
    }

    public interface IGridPageModel
    {
        GridBuilder GridBuilder { get; }
        string GridId { get; set; }
        FilterModel Filter { get; set; }
        string FilterViewName { get; set; }
        string ScriptViewName { get; set; }
        ScriptModel ScriptModel { get; set; }
        string Title { get; set; }
    }

    public class GridPageModel<T> : IGridPageModel
        where T : GridBuilder
    {
        public GridBuilder GridBuilder { get; private set; }
        public string GridId { get; set; }
        public FilterModel Filter { get; set; }
        public string FilterViewName { get; set; }
        public string ScriptViewName { get; set; }
        public ScriptModel ScriptModel { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GridPageModel"/> class.
        /// </summary>
        public GridPageModel(IHttpContextAccessor httpContextAccessor, IServiceProvider serviceProvider)
        {
            GridId = "mainGrid";
            FilterViewName = "_Filter";
            //GridBuilder = serviceProvider.GetService<CoiNYC.Areas.Product.ProductGridBuilder>();
            GridBuilder = httpContextAccessor.HttpContext.RequestServices.GetService<T>();
        }
    }

    public class ScriptModel
    {
        public string ControllerName { get; set; }
        public string Json { get; set; }
    }
}
