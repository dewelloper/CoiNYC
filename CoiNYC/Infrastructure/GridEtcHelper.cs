using MvcJqGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Core.Reflection;
using CoiNYC.Core.Extensions;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using CoiNYC.Infrastructure.Builders;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CoiNYC.Infrastructure
{
    public partial class ModelWrapper<M>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        private HtmlHelper<M> Helper
        {
            get;
            set;
        }
        private ModelWrapper()
        {
        }

        public ModelWrapper(HtmlHelper<M> helper)
        {
            this.Helper = helper;
        }

    }

    public static class HMTLHelperExtensions
    {
        public static ModelWrapper<TModel> Wrapper<TModel>(this HtmlHelper<TModel> helper)
        {
            return new ModelWrapper<TModel>(helper);
        }

        public static object GridFrom(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, GridBuilder builder, string id)
        {
            return builder.ToGrid(id);
        }

        public static string ToDataAttributes(this object obj)
        {
            if (obj == null)
                return String.Empty;

            var dictionary = ObjectToDictionaryRegistry.Convert(obj);

            StringBuilder sb = new StringBuilder();
            foreach (var item in dictionary)
            {
                if (item.Value != null)
                    sb.AppendFormat("data-{0}=\"{1}\" ", item.Key.SplitUpperCase("-").ToLowerInvariant(), item.Value);
            }

            var s = sb.ToString();

            return s;
        }
        public static IDictionary<string, object> ToHtmlAttributes(this object obj)
        {
            if (obj == null)
                return null;

            var dictionary = ObjectToDictionaryRegistry.Convert(obj);

            var list = dictionary.ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                if (item.Key.StartsWith("data_"))
                {
                    dictionary.Remove(item.Key);
                    dictionary.Add(item.Key.Replace('_', '-').ToLowerInvariant(), item.Value);
                }
            }

            return dictionary;
        }


        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }
        //public static MvcHtmlString BooleanDropDownList<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, BooleanValues values, object htmlAttributes = null)
        //{
        //    Func<TModel, TValue> func = expression.Compile();
        //    TValue value = func(html.ViewData.Model);
        //    Type valueType = typeof(TValue);

        //    if (valueType == typeof(object))
        //        valueType = html.ViewData.ModelMetadata.ModelType;

        //    IList<SelectListItem> items = new List<SelectListItem>();
        //    bool? nonNullableValue = null;

        //    if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Nullable<>))
        //    {
        //        items.Add(new SelectListItem() { Text = values.All, Value = "", Selected = value == null });
        //        nonNullableValue = value as bool?;
        //    }
        //    else
        //        nonNullableValue = Convert.ToBoolean(value);


        //    items.Add(new SelectListItem() { Text = values.True, Value = "true", Selected = nonNullableValue.HasValue && nonNullableValue.Value });
        //    items.Add(new SelectListItem() { Text = values.False, Value = "false", Selected = nonNullableValue.HasValue && !nonNullableValue.Value });

        //    return html.DropDownListFor(expression, items, htmlAttributes);
        //}

        //public static MvcHtmlString LocalizedEnumDropDownList<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object placeHolderObject = null, object htmlAttributes = null)
        //{
        //    Func<TModel, TValue> func = expression.Compile();
        //    TValue value = func(html.ViewData.Model);
        //    Type valueType = typeof(TValue);

        //    if (valueType == typeof(object))
        //        valueType = html.ViewData.ModelMetadata.ModelType;

        //    SelectList list = null;

        //    if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Nullable<>) && value == null)
        //        list = SelectListHelper.GetSelectListFromEnum(valueType, null, null, false);
        //    else
        //        list = SelectListHelper.GetSelectListFromEnum(valueType, null, value, true);

        //    string placeHolder = null;
        //    if (placeHolderObject != null)
        //        placeHolder = placeHolderObject.ToString();

        //    return html.DropDownListFor(expression, list, placeHolder, htmlAttributes);
        //}

        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = Convert.ToString(html.ViewContext.RouteData.Values["action"]).ToLowerInvariant();
            string currentController = Convert.ToString(html.ViewContext.RouteData.Values["controller"]).ToLowerInvariant();

            if (String.IsNullOrEmpty(controller))
                controller = currentController;
            else
                controller = controller.ToLowerInvariant();

            if (String.IsNullOrEmpty(action))
                action = currentAction;
            else
                action = action.ToLowerInvariant();

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string IsSelected(this HtmlHelper html, string[] controllers, string cssClass = null)
        {
            if (controllers.IsEmptyOrNull())
                return String.Empty;

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentController = Convert.ToString(html.ViewContext.RouteData.Values["controller"]).ToLowerInvariant();

            return controllers.Any(x => x.ToLowerInvariant() == currentController) ? cssClass : String.Empty;
        }
    }

}
