using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoiNYC.Infrastructure.Builders.GridEnums;

namespace CoiNYC.Infrastructure.Builders
{
    public class GridColumnBuilder<TObject> : GridColumnBuilder
        where TObject : class 
    {
        internal Expression<Func<TObject, object>> PropertySelector { get; private set; }
        internal Func<TObject, object> ConversionFunc { get; private set; }

        public GridColumnBuilder(Expression<Func<TObject, object>> propertySelector, Func<TObject, object> function = null)
        {
            PropertySelector = propertySelector;

            var body = propertySelector.Body as MemberExpression;

            if (body == null)
            {
                body = ((UnaryExpression)propertySelector.Body).Operand as MemberExpression;
            }

            Name = body.Member.Name;


            if (function == null)
            {
                var compiledFunc = propertySelector.Compile();
                ConversionFunc = compiledFunc;
            }
            else
            {
                ConversionFunc = function;
            }

        }

    }




    public class GridColumnBuilder
    {
        public bool IsExpandable { get; internal set; }
   
        public bool IsNameSet { get; internal set; }
        public bool Sortable { get; internal set; }
        public GridColumnVisibility Visibility { get; internal set; }
        public GridColumnAlignment Alignment { get; internal set; }
        public GridColumnFormatter Formatter { get; internal set; }
        public string FormatOptions { get; internal set; }
        public bool IsKey { get; internal set; }
        public string CustomFormatter { get; internal set; }
        public string CustomFooterFormatter { get; internal set; }
        public int? Width { get; internal set; }
        public GridColumnWidthUnit WidthUnit { get; internal set; }
        public bool FixedWidth { get; internal set; }
        public string Name { get; internal set; }
        public string TitleResourceKey { get; internal set; }
        public string CssClass { get; internal set; }
        public GridColumnValueType? ValueType { get; set; }
        public string FooterFieldName { get; set; }
        
        public GridColumnBuilder()
        {
            Sortable = true;
            Visibility = GridColumnVisibility.VisibleOptional;
            Alignment = GridColumnAlignment.Default;
            Formatter = GridColumnFormatter.None;
            FormatOptions = null;
            IsKey = false;
            CustomFormatter = null;
            CustomFooterFormatter = null;
            FixedWidth = false;
            IsExpandable = false;
            WidthUnit = GridColumnWidthUnit.Percentage;
            FooterFieldName = null;
        }


        public GridColumnBuilder SetExpandable(bool expandable)
        {
            IsExpandable = expandable;
            return this;
        }

        public GridColumnBuilder SetSortable(bool sortable)
        {
            Sortable = sortable;
            return this;
        }

        public GridColumnBuilder SetVisibility(GridColumnVisibility visibility)
        {
            Visibility = visibility;
            return this;
        }
        public GridColumnBuilder SetAlignment(GridColumnAlignment alignment)
        {
            Alignment = alignment;
            return this;
        }
        public GridColumnBuilder SetFormatter(GridColumnFormatter formater, string formatOptions = null)
        {
            Formatter = formater;
            FormatOptions = formatOptions;
            return this;
        }
        public GridColumnBuilder SetKey(bool isKey)
        {
            IsKey = isKey;
            return this;
        }

        public GridColumnBuilder SetValueType(GridColumnValueType? valueType)
        {
            ValueType = valueType;
            return this;
        }

        public GridColumnBuilder SetWidth(int? width, GridColumnWidthUnit widthUnit, bool fixedWidth = false)
        {
            Width = width;
            WidthUnit = widthUnit;
            FixedWidth = fixedWidth;
            return this;
        }

        public GridColumnBuilder SetTitle(string titleResourceKey)
        {
            TitleResourceKey = titleResourceKey;
            return this;
        }

        public GridColumnBuilder SetCssClass(string cssClass)
        {
            CssClass = cssClass;
            return this;
        }

        public GridColumnBuilder SetCustomFormatter(string formatter)
        {
            CustomFormatter = formatter;
            return this;
        }

        public GridColumnBuilder SetCustomFooterFormatter(string formatter)
        {
            CustomFooterFormatter = formatter;
            return this;
        }

        public GridColumnBuilder SetFooterField(string footerFieldName)
        {
            FooterFieldName = footerFieldName;
            return this;
        }
    }

}
