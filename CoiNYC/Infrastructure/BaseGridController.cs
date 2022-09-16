using CoiNYC.Core.CQRS;
using CoiNYC.Core.Data;
using CoiNYC.Domain.Resources;
using CoiNYC.Features.Shared;
using CoiNYC.Infrastructure.Builders;
using CoiNYC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoiNYC.Infrastructure
{
    public class BaseGridController : BaseController
    {
        private readonly bool useDefaultCrudButtons;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //protected string AreaName => Convert.ToString(this.ControllerContext.RouteData.DataTokens["area"]);
        protected string AreaName => ((object[])this.ControllerContext.RouteData.Values.Values)[1].ToString();
        public BaseGridController(IMediator mediator, ICurrencyService currency, ICacheService cache, IHttpContextAccessor httpContextAccessor)
            : base(mediator, currency, cache)
        {
            this.useDefaultCrudButtons = true;
            _httpContextAccessor = httpContextAccessor;
        }

        public BaseGridController(bool useDefaultCrudButtons, IMediator mediator, ICurrencyService currency, ICacheService cache)
            : base(mediator, currency, cache)
        {
            this.useDefaultCrudButtons = useDefaultCrudButtons;
        }

        protected virtual List<ButtonBaseModel> GetButtons(bool includeCrudButtons)
        {
            var controllerName = Convert.ToString(ControllerContext.RouteData.Values["controller"]);
            var areaName = AreaName;

            List<ButtonBaseModel> buttons = new List<ButtonBaseModel>();
            buttons.AddRange(
                 new ButtonModel[]
                 {
                      new ButtonModel { Action =  "List", Controller = areaName, RouteValues = new { area = areaName }, Text = R.ListV, Class="btn-primary grid-list-button grid-immediate", PrependIcon = "fa fa-refresh", Order = 1000}
                }
                );

            if (useDefaultCrudButtons)
            {
                buttons.Add(new ButtonModel()
                {
                    Action = "Add",
                    RouteValues = new { area = areaName },
                    Controller = areaName,
                    Text = R.Create,
                    Class = "btn-primary bound-btn",
                    PrependIcon = "fa fa-plus",
                    Order = 1,
                    Binding = new ButtonBinding() { ActionTarget = ActionTarget.Window }
                });
                buttons.Add(new ButtonModel()
                {
                    Action = "Edit",
                    RouteValues = new { area = areaName },
                    Controller = areaName,
                    Text = R.Edit,
                    Class = "btn-primary bound-btn",
                    PrependIcon = "fa fa-edit",
                    Order = 2,
                    Binding = new ButtonBinding() { Binding = BindingType.ActiveRecord, ActionTarget = ActionTarget.Window, Properties = new List<string>() { "Id" } }
                });

                buttons.Add(new ButtonModel()
                {
                    Action = "Delete",
                    RouteValues = new { area = areaName },
                    Controller = areaName,
                    Text = R.Delete,
                    Class = "btn-warning bound-btn",
                    PrependIcon = "fa fa-trash",
                    Order = 3,
                    Binding = new ButtonBinding() { Binding = BindingType.ActiveRecord, ActionTarget = ActionTarget.Dialog, Properties = new List<string>() { "Id" } }
                });
            }
            return buttons;
        }

        //[ChildActionOnly]
        public virtual ActionResult RenderButtons()
        {
            return PartialView("_Buttons", GetButtons(useDefaultCrudButtons));
        }

        protected ActionResult GetGridData<TGrid, TObject>(IList<TObject> list)
            where TObject : class
            where TGrid : GridBuilder<TObject>
        {

            var gridBuilder = _httpContextAccessor.HttpContext.RequestServices.GetService<TGrid>();
            //var gridBuilder = DependencyResolver.Current.GetService<TGrid>();
            return Json(gridBuilder.ToGridData(list), System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        protected ActionResult GetSummaryGridData<TGrid, TObject, TSummary>(ISummaryPagedList<TObject, TSummary> list)
        where TObject : class
        where TGrid : GridBuilder<TObject>
        {
            var gridBuilder = _httpContextAccessor.HttpContext.RequestServices.GetService<TGrid>();
            return Json(gridBuilder.ToGridData(list), System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
