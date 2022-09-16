using MvcJqGrid;
using MvcJqGrid.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoiNYC.Infrastructure.Builders.GridEnums;
using CoiNYC.Core.Extensions;
using CoiNYC.Core.Data;
using System.Web.Mvc;
using System.Text;

namespace CoiNYC.Infrastructure.Builders
{
    //public enum GridOutputType
    //{
    //    JqGrid,
    //    JqBootGrid,
    //    BootstrapTable
    //}

    public abstract class TreeGridBuilder<TObject> : GridBuilder<TObject>
        where TObject : class
    {

        private static Func<TObject, object> ParentColumnFunc;
        private static Func<TObject, int> SequenceColumnFunc;

        public TreeGridBuilder()
        {

        }

        private static IList<TreeGridNode<TObject>> ConvertToTree(IList<TObject> objectList)
        {
            var dictionary = objectList.ToDictionary(m => KeyColumnFunc(m), m => new TreeGridNode<TObject>
            {
                Id = KeyColumnFunc(m),
                ParentId = ParentColumnFunc(m),
                Model = m,
                SortData = Convert.ToInt64(SequenceColumnFunc(m) << 32 | KeyColumnFunc(m).GetHashCode())
            });

            return CalculateTreeData(dictionary);
        }

        private static List<TreeGridNode<TObject>> CalculateTreeData(Dictionary<object, TreeGridNode<TObject>> dictionary)
        {

            foreach (var item in dictionary.Values)
            {
                if (item.Level == null)
                    CalculateNodeLevel(dictionary, item, false);

            }

            var list = new List<TreeGridNode<TObject>>(dictionary.Values.Count);
            SortTreeData(list, null, dictionary.Values.ToList());

            return list;
        }

        private static int CalculateNodeLevel(Dictionary<object, TreeGridNode<TObject>> dictionary, TreeGridNode<TObject> node, bool isChildCall)
        {

            node.HasChildren = node.HasChildren || isChildCall;

            if (node.Level.HasValue)
                return node.Level.Value;

            if (node.ParentId != null && dictionary.ContainsKey(node.ParentId))
                node.Level = 1 + CalculateNodeLevel(dictionary, dictionary[node.ParentId], true);
            else
                node.Level = 0;

            return node.Level.Value;
        }

        private static void SortTreeData(List<TreeGridNode<TObject>> sortedList, object parentID, List<TreeGridNode<TObject>> allNodes)
        {
            List<TreeGridNode<TObject>> children = allNodes.Where(x => object.Equals(x.ParentId, parentID)).OrderBy(x => x.SortData).ToList();


            foreach (var child in children)
            {
                sortedList.Add(child);
                SortTreeData(sortedList, child.Id, allNodes);
            }
        }

        protected override Grid GetInitialGrid(string id)
        {
            Grid grid = base.GetInitialGrid(id);
            grid.EnableTreeGrid(TreeGridModel.Adjacency, -1);
            SetDataType(GridEnums.DataType.Json);

            return grid;
        }

        public TreeGridBuilder<TObject> SetParentColumn(Func<TObject, object> parentColumn)
        {
            ParentColumnFunc = parentColumn;
            return this;
        }

        public TreeGridBuilder<TObject> SetSequenceColumn(Func<TObject, int> sequenceColumn)
        {
            SequenceColumnFunc = sequenceColumn;
            return this;
        }

        protected override object ToJsonData(IList<TObject> list)
        {
            var tree = ConvertToTree(list);

            var jsonData = new
            {
                total = 1,
                page = 1,
                records = tree.Count,
                rows = tree.Select(c => new
                {
                    id = KeyColumnFunc(c.Model),
                    cell = GetRowData(c)
                }).ToArray()
            };
            return jsonData;
        }

        private object[] GetRowData(TreeGridNode<TObject> node)
        {
            var list = ColumnFuncs.Select(f => f(node.Model)).ToList();
            list.AddRange(new object[] { node.Level, node.ParentId, !node.HasChildren, true, true, null });

            return list.ToArray();
        }

    }

    public class TreeGridNode<TObject>
    {
        public object Id { get; set; }
        public object ParentId { get; set; }
        public TObject Model { get; set; }
        public int? Level { get; set; }
        public object SortData { get; set; }
        public bool HasChildren { get; set; }

    }


    public abstract class GridBuilder<TObject> : GridBuilder
        where TObject : class
    {
        public GridBuilder()
        {
            Build();
        }

        public abstract void Build();
        public static Func<TObject, object> KeyColumnFunc;
        public static List<Func<TObject, object>> ColumnFuncs;

        public GridColumnBuilder<TObject> Column(Expression<Func<TObject, object>> propertySelector, Func<TObject, object> conversionFunc = null)
        {
            GridColumnBuilder<TObject> column = new GridColumnBuilder<TObject>(propertySelector, conversionFunc);
            columns.Add(column);
            return column;
        }

        protected void InitializeColumnFunctions()
        {
            if (ColumnFuncs == null)
            {
                ColumnFuncs = columns.Select(x => (x as GridColumnBuilder<TObject>).ConversionFunc).ToList();
                var keyColumn = columns.Where(x => x.IsKey).FirstOrDefault();
                if (keyColumn == null)
                    keyColumn = columns.FirstOrDefault();

                if (keyColumn != null)
                    KeyColumnFunc = (keyColumn as GridColumnBuilder<TObject>).ConversionFunc;
            }
        }



        protected virtual object ToJsonData(IList<TObject> list)
        {
            int totalPages = 1;
            int pageIndex = 1;
            int totalCount = 1;

            if (list is IPagedList<TObject>)
            {
                var pagedList = list as IPagedList<TObject>;
                totalPages = pagedList.TotalPages;
                totalCount = pagedList.TotalCount;
                pageIndex = pagedList.PageIndex;
            }
            else
            {
                totalCount = list.Count;
            }

            if (OutputType == GridOutputType.JqGrid)
            {
                return new
                {
                    total = totalPages,
                    page = pageIndex,
                    records = totalCount,
                    rows = list.Select(c => new
                    {
                        id = KeyColumnFunc(c),
                        cell = ColumnFuncs.Select(f => f(c)).ToArray()

                    }
                    ).ToArray()
                };
            }

            object sx = new
            {
                total = totalCount,
                current = pageIndex,
                rowCount = list.Count,
                rows = list.Select(c => columns.Select((x, i) => new { Name = x.Name, Value = ColumnFuncs[i](c) }).ToDictionary(x => x.Name, x => x.Value)
                ).ToArray()
            };
            return sx;

        }


        protected virtual object ToJsonData<TSummary>(ISummaryPagedList<TObject, TSummary> list)
        {
            int totalPages = 1;
            int pageIndex = 1;
            int totalCount = 1;

            totalPages = list.TotalPages;
            totalCount = list.TotalCount;
            pageIndex = list.PageIndex;


            if (OutputType == GridOutputType.JqGrid)
            {
                return new
                {
                    total = totalPages,
                    page = pageIndex,
                    records = totalCount,
                    rows = list.Select(c => new
                    {
                        id = KeyColumnFunc(c),
                        cell = ColumnFuncs.Select(f => f(c)).ToArray()

                    }
                    ).ToArray(),
                    userdata = list.TotalSummary
                };
            }

            object sx = new
            {
                total = totalCount,
                current = pageIndex,
                rowCount = list.Count,
                rows = list.Select(c => columns.Select((x, i) => new { Name = x.Name, Value = ColumnFuncs[i](c) }).ToDictionary(x => x.Name, x => x.Value)
                ).ToArray(),
                userdata = list.TotalSummary
            };
            return sx;

        }
        public object ToGridData(IList<TObject> list)
        {
            InitializeColumnFunctions();

            return ToJsonData(list);

        }

        public object ToGridData<TSummary>(ISummaryPagedList<TObject, TSummary> list)
        {
            InitializeColumnFunctions();

            return ToJsonData(list);

        }
    }

    public class SimpleGridBuilder : GridBuilder
    {
        public GridBuilder Column(GridColumnBuilder columnBuilder)
        {
            columns.Add(columnBuilder);
            return this;
        }
    }

    public enum GridOutputType
    {
        JqGrid,
        JqBootGrid,
        BootstrapTable
    }

    public abstract class GridBuilder
    {
        private GridOutputType? _outputType;
        public static Type ResourceType { get; set; }
        public string Caption { get; internal set; }
        public GridEnums.DataType? DataType { get; internal set; }
        public PagerPosition? PagerPosition { get; internal set; }
        public HtmlRequestType? RequestType { get; internal set; }
        public bool? PageButtons { get; internal set; }
        public bool? PageInput { get; internal set; }
        public int[] PageRowCounts { get; internal set; }
        public int RowCount { get; internal set; }
        public bool? HorizontalScroll { get; internal set; }
        public bool Pager { get; internal set; }
        public bool AlternativeRows { get; internal set; }
        public bool HoverRows { get; internal set; }
        public bool Exportable { get; internal set; }

        public bool ShowFooter { get; internal set; }
        public GridOutputType OutputType { get { return _outputType ?? new GridOutputType(); } }

        protected List<GridColumnBuilder> columns;


        public GridBuilder()
        {
            columns = new List<GridColumnBuilder>();
            RowCount = 50;
            PageRowCounts = new int[] { 10, 20, 50, 100 };
            Caption = null;
            Pager = true;
            AlternativeRows = true;
            HoverRows = true;
            ShowFooter = false;
        }

        protected virtual Grid GetInitialGrid(string id)
        {
            Grid grid = new Grid(id);
            grid.SetAutoWidth(true);
            grid.SetViewRecords(true);
            grid.SetShrinkToFit(true);
            grid.SetHiddenGrid(false);

            return grid;
        }

        protected Grid ToJqGrid(string id)
        {
            Grid grid = GetInitialGrid(id);

            if (DataType.HasValue)
                grid.SetDataType((MvcJqGrid.Enums.DataType)DataType.Value);
            if (RequestType.HasValue)
                grid.SetRequestType((RequestType)RequestType.Value);

            grid.SetHoverRows(HoverRows);
            grid.OnLoadBeforeSend("return noLoad(xhr, settings);");

            if (HorizontalScroll.HasValue && HorizontalScroll.Value)
            {
                grid.SetShrinkToFit(false).SetForceFit(false);
            }

            if (Pager)
            {
                grid.SetPager(id + "_pager");
                if (PagerPosition.HasValue)
                    grid.SetPagerPos((PagerPos)PagerPosition.Value);
                if (PageButtons.HasValue)
                    grid.SetPgButtons(PageButtons.Value);
                if (PageInput.HasValue)
                {
                    grid.SetPgInput(PageInput.Value);
                }
                grid.SetRowList(PageRowCounts);
                grid.SetRowNum(RowCount);
                grid.SetAltRows(AlternativeRows);
            }

            foreach (GridColumnBuilder columnBuilder in columns)
            {
                Column column = new Column(columnBuilder.Name);
                if (!String.IsNullOrEmpty(columnBuilder.CustomFormatter))
                {
                    column = column.SetCustomFormatter(columnBuilder.CustomFormatter);
                }
                else
                    if (columnBuilder.Formatter != GridColumnFormatter.None)
                {
                    Formatters formatter = (Formatters)columnBuilder.Formatter;
                    column = String.IsNullOrEmpty(columnBuilder.FormatOptions) ? column.SetFormatter(formatter) : column.SetFormatter(formatter, columnBuilder.FormatOptions);
                }

                if (columnBuilder.Alignment != GridColumnAlignment.Default)
                    column.SetAlign((Align)columnBuilder.Alignment);

                if (columnBuilder.Visibility == GridColumnVisibility.Hidden)
                    column.SetHidden(true);
                else
                {
                    column.SetWidth(columnBuilder.Width ?? 80);
                    if (columnBuilder.FixedWidth)
                        column.SetFixedWidth(true);
                }
                if (columnBuilder.IsKey)
                    column.SetKey(true);



                if (columnBuilder.IsExpandable)
                    column.SetAsExpandable();


                if (!String.IsNullOrEmpty(columnBuilder.CssClass))
                    column.AddClass(columnBuilder.CssClass);

                column.SetLabel(GetColumnTitle(columnBuilder));
                column.SetSortable(columnBuilder.Sortable);
                grid.AddColumn(column);
            }

            return grid;
        }

        private string GetColumnTitle(GridColumnBuilder columnBuilder)
        {
            string title = null;
            if (!String.IsNullOrEmpty(columnBuilder.TitleResourceKey) && ResourceType.PropertyExists(columnBuilder.TitleResourceKey))
                title = GetResourceValue(columnBuilder.TitleResourceKey);
            else
            if (ResourceType.PropertyExists(columnBuilder.Name))
                title = GetResourceValue(columnBuilder.Name);
            else
                title = columnBuilder.Name.SplitUpperCase();

            return title;
        }

        private object ToJqBootGrid(string id)
        {
            TagBuilder table = new TagBuilder("table");
            table.Attributes.Add("id", id);
            table.Attributes.Add("data-ajax", "true");
            table.Attributes.Add("data-selection", "true");
            table.Attributes.Add("data-row-select", "true");

            string cssClass = "ts-jqboot";

            if (AlternativeRows)
                cssClass += " table-striped";

            if (HoverRows)
                cssClass += " table-hover";



            table.Attributes.Add("data-row-count", string.Format("[{0}]", String.Join(",", PageRowCounts)));

            table.Attributes.Add("class", cssClass);

            TagBuilder thead = new TagBuilder("thead");
            TagBuilder tr = new TagBuilder("tr");

            StringBuilder sb = new StringBuilder();
            foreach (GridColumnBuilder columnBuilder in columns)
            {
                TagBuilder th = new TagBuilder("th");
                th.Attributes.Add("data-column-id", columnBuilder.Name);

                if (!String.IsNullOrEmpty(columnBuilder.CssClass))
                    th.Attributes.Add("data-cssClass", columnBuilder.CssClass);

                if (columnBuilder.Visibility == GridColumnVisibility.Hidden || columnBuilder.Visibility == GridColumnVisibility.HiddenOptional)
                    th.Attributes.Add("data-visible", "false");

                if (columnBuilder.Visibility == GridColumnVisibility.Hidden || columnBuilder.Visibility == GridColumnVisibility.Visible)
                    th.Attributes.Add("data-visible-in-selection", "false");

                if (columnBuilder.IsKey)
                    th.Attributes.Add("data-identifier", "true");

                if (columnBuilder.Alignment == GridColumnAlignment.Center)
                    th.Attributes.Add("data-align", "center");

                if (columnBuilder.Alignment == GridColumnAlignment.Right)
                    th.Attributes.Add("data-align", "right");

                if (!columnBuilder.Sortable)
                    th.Attributes.Add("data-sortable", "false");

                if (columnBuilder.Width.HasValue)
                    th.Attributes.Add("data-width", columnBuilder.Width.Value + (columnBuilder.WidthUnit == GridColumnWidthUnit.Percentage ? "%" : "px"));

                if (!columnBuilder.ValueType.HasValue && columnBuilder.IsKey || columnBuilder.ValueType.HasValue && columnBuilder.ValueType.Value != GridColumnValueType.String)
                    th.Attributes.Add("data-converter", "numeric");

                if (!String.IsNullOrEmpty(columnBuilder.CustomFormatter))
                    th.Attributes.Add("data-formatter", columnBuilder.CustomFormatter);
                else
                {
                    //columnBuilder.Formatter
                    switch (columnBuilder.Formatter)
                    {
                        case GridEnums.GridColumnFormatter.Email:
                            th.Attributes.Add("data-formatter", "email");
                            break;
                        case GridEnums.GridColumnFormatter.Showlink:
                        case GridEnums.GridColumnFormatter.Link:
                            th.Attributes.Add("data-formatter", "link");
                            break;
                        case GridEnums.GridColumnFormatter.Date:
                            th.Attributes.Add("data-formatter", "date");
                            break;
                        case GridEnums.GridColumnFormatter.Checkbox:
                            th.Attributes.Add("data-formatter", "checkbox");
                            break;
                        default:
                            break;
                    }
                }


                /*
                Integer = 0,
        Number = 1,
        Currency = 2,
        Date = 3,
        Email = 4,
        Link = 5,
        Showlink = 6,
        Checkbox = 7,
        Select = 8*/

                sb.Append(th.ToString(TagRenderMode.StartTag));
                sb.Append(GetColumnTitle(columnBuilder));
                sb.Append(th.ToString(TagRenderMode.EndTag));
            }

            tr.InnerHtml = sb.ToString();
            thead.InnerHtml = tr.ToString();
            table.InnerHtml = thead.ToString();

            return table.ToString(); // html.row on there (in the view)
            //return MvcHtmlString.Create(table.ToString());
        }
        /* <table id="bookingReport"
                           data-toolbar="toolbar"
                           data-search="false"
                           data-show-toggle="true"
                           data-show-columns="true"
                           data-minimum-count-columns="2"
                           data-search-time-out="500"
                           data-row-attributes="rowAttribute"
                           data-pagination="true"
                           data-side-pagination="server"
                           data-sort-name="PNR"
                           data-sort-order="asc"
                           data-url="@Url.Action("List", "BookingReport", new { area = "Reports" })"
                           data-page-list="[5 , 10, 25, 50, 100]">
                        <thead>
                            <tr>
                                <th data-sortable='true' data-field="PNR" data-hide="phone">PNR</th>
                                <th data-sortable='true' data-field="ReservationType" data-hide="phone">ReservationType</th>
                                <th data-sortable='true' data-field="BookingStatus" data-hide="phone">BookingStatus</th>
                                <th data-sortable='true' data-field="TripCode" data-hide="phone">TripCode</th>
                                <th data-sortable='true' data-field="CustomerName" data-hide="tablet phone">CustomerName</th>
                                <th data-sortable='true' data-field="CustomerSurName" data-hide="tablet phone">CustomerSurName</th>
                            </tr>
                        </thead>
                    </table>*/

        private object ToBootstrapTable(string id)
        {
            TagBuilder table = new TagBuilder("table");
            table.Attributes.Add("id", id);
            table.Attributes.Add("data-pagination", "true");
            table.Attributes.Add("data-method", "post");
            table.Attributes.Add("data-side-pagination", "server");
            table.Attributes.Add("data-search-time-out", "500");
            table.Attributes.Add("data-minimum-count-columns", "2");
            table.Attributes.Add("data-show-columns", "true");
            table.Attributes.Add("data-show-toggle", "true");
            table.Attributes.Add("data-search", "false");
            table.Attributes.Add("data-toolbar", "toolbar");
            table.Attributes.Add("data-page-list", string.Format("[{0}]", String.Join(",", PageRowCounts)));
            if (ShowFooter)
                table.Attributes.Add("data-show-footer", "true");
            if (Exportable)
                table.Attributes.Add("data-show-export", "true");


            table.Attributes.Add("data-id-field", columns.Where(x => x.IsKey).Select(x => x.Name).FirstOrDefault() ?? String.Empty);

            if (AlternativeRows)
                table.Attributes.Add("data-striped", "true");

            string cssClass = "ts-grid";

            if (HoverRows)
                cssClass += " table-hover";

            table.Attributes.Add("class", cssClass);

            TagBuilder thead = new TagBuilder("thead");
            TagBuilder tr = new TagBuilder("tr");
            StringBuilder sb = new StringBuilder();

            TagBuilder thSelection = new TagBuilder("th");
            thSelection.Attributes.Add("data-field", "state");
            thSelection.Attributes.Add("data-radio", "true");

            sb.Append(thSelection.ToString(TagRenderMode.StartTag));
            sb.Append(thSelection.ToString(TagRenderMode.EndTag));

            foreach (GridColumnBuilder columnBuilder in columns)
            {
                TagBuilder th = new TagBuilder("th");
                th.Attributes.Add("data-field", columnBuilder.Name);

                if (columnBuilder.Sortable)
                    th.Attributes.Add("data-sortable", "true");


                if (columnBuilder.Alignment == GridColumnAlignment.Center)
                    th.Attributes.Add("data-align", "center");

                if (columnBuilder.Alignment == GridColumnAlignment.Right)
                    th.Attributes.Add("data-align", "right");

                if (columnBuilder.Alignment == GridColumnAlignment.Left)
                    th.Attributes.Add("data-align", "left");

                th.Attributes.Add("data-halign", "center");

                if (columnBuilder.Width.HasValue)
                    th.Attributes.Add("data-width", columnBuilder.Width.Value + (columnBuilder.WidthUnit == GridColumnWidthUnit.Percentage ? "%" : "px"));

                if (columnBuilder.Visibility == GridColumnVisibility.Hidden || columnBuilder.Visibility == GridColumnVisibility.HiddenOptional)
                    th.Attributes.Add("data-visible", "false");

                if (columnBuilder.Visibility == GridColumnVisibility.Hidden || columnBuilder.Visibility == GridColumnVisibility.Visible)
                    th.Attributes.Add("data-switchable", "false");

                if (columnBuilder.Formatter == GridColumnFormatter.Checkbox)
                {
                    th.Attributes.Add("data-checkbox", "true");
                }

                if (!String.IsNullOrEmpty(columnBuilder.CustomFormatter))
                {
                    th.Attributes.Add("data-formatter", columnBuilder.CustomFormatter);
                }

                if (!String.IsNullOrEmpty(columnBuilder.CustomFooterFormatter))
                {
                    th.Attributes.Add("data-footer-field", columnBuilder.FooterFieldName ?? columnBuilder.Name);
                    th.Attributes.Add("data-footer-formatter", columnBuilder.CustomFooterFormatter);
                }


                if (!String.IsNullOrEmpty(columnBuilder.CssClass))
                    th.Attributes.Add("data-class", columnBuilder.CssClass);
               

                sb.Append(th.ToString(TagRenderMode.StartTag));
                sb.Append(GetColumnTitle(columnBuilder));
                sb.Append(th.ToString(TagRenderMode.EndTag));
            }

            tr.InnerHtml = sb.ToString();
            thead.InnerHtml = tr.ToString();
            table.InnerHtml = thead.ToString();

            return table;
            //return MvcHtmlString.Create(table.ToString());
        }

        public object ToGrid(string id)
        {
            if (OutputType == GridOutputType.JqGrid)
                return ToJqGrid(id);
            else
            if (OutputType == GridOutputType.BootstrapTable)
                return ToBootstrapTable(id);

            return ToJqBootGrid(id);
        }

        private string GetResourceValue(string key)
        {
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(ResourceType);

            return rm.GetString(key, System.Threading.Thread.CurrentThread.CurrentUICulture);
        }
        public GridBuilder SetCaption(string caption)
        {
            Caption = caption;
            return this;
        }

        public GridBuilder SetExportable(bool exportable)
        {
            Exportable = exportable;
            return this;
        }

        public GridBuilder SetDataType(GridEnums.DataType dataType)
        {
            DataType = dataType;
            return this;
        }


        public GridBuilder SetPagerPosition(PagerPosition pagerPosition)
        {
            PagerPosition = pagerPosition;
            return this;
        }

        public GridBuilder SetRequestType(HtmlRequestType requestType)
        {
            RequestType = requestType;
            return this;
        }

        public GridBuilder SetPageButtons(bool pageButtons)
        {
            PageButtons = pageButtons;
            return this;
        }

        public GridBuilder SetPageInput(bool pageInput)
        {
            PageInput = pageInput;
            return this;
        }


        public GridBuilder SetHorizontalScroll(bool horizontalScroll)
        {
            HorizontalScroll = horizontalScroll;
            return this;
        }

        public GridBuilder SetRowCount(int rowCount)
        {
            RowCount = rowCount;
            return this;
        }

        public GridBuilder SetPageRowCounts(int[] pageRowCounts)
        {
            PageRowCounts = pageRowCounts;
            return this;
        }

        public GridBuilder SetHasPager(bool pager)
        {
            Pager = pager;
            return this;
        }

        public GridBuilder SetAlternativeRows(bool alternativeRows)
        {
            AlternativeRows = alternativeRows;
            return this;
        }

        public GridBuilder SetHoverRows(bool hoverRows)
        {
            HoverRows = hoverRows;
            return this;
        }

        public GridBuilder SetShowFooter(bool showFooter)
        {
            ShowFooter = showFooter;
            return this;
        }

        public GridBuilder SetOutputType(GridOutputType? outputType)
        {
            _outputType = outputType;
            return this;
        }
    }


}
