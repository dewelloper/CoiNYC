using CoiNYC.Core.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoiNYC.Infrastructure
{
    public static class SelectListHelper
    {

        public static List<SelectListItem> GetSelectListFromList<TModel>(IList<TModel> list, Expression<Func<TModel, string>> textPropertyExpression, Expression<Func<TModel, object>> valuePropertyExpression, string placeHolder = null)
        {
            var funcText = textPropertyExpression.Compile();
            var funcValue = valuePropertyExpression.Compile();

            List<SelectListItem> selectItems = new List<SelectListItem>();
            if (!String.IsNullOrEmpty(placeHolder))
                selectItems.Add(new SelectListItem { Value = "", Text = placeHolder, Selected = false });

            foreach (TModel item in list)
            {
                SelectListItem selectItem = new SelectListItem();
                object value = funcValue(item);
                selectItem.Value = value == null ? String.Empty : value.ToString();
                selectItem.Text = funcText(item);

                selectItems.Add(selectItem);
            }

            return selectItems;
        }

        public static SelectList GetSelectListFromEnum(Type enumType, Type resourceType, object selectedValue, bool hasValue)
        {
            var enums = EnumFunc.GetEnumValues(enumType, resourceType);


            var allEnums = enums.Select(x => new { Text = x.Value, Value = x.Key }).ToList();
            /*if (!String.IsNullOrEmpty(placeHolder))
                allEnums.Insert(0, new { Text = placeHolder, Value = String.Empty });*/

            SelectList list = null;

            if (hasValue)
                list = new SelectList(allEnums, "Value", "Text", selectedValue);
            else
                list = new SelectList(allEnums, "Value", "Text");



            return list;
        }


    }
}
