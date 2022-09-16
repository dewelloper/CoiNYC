function GridPageData(grid) {
    var GridId = grid.attr("id");
    main.pageGrids[GridId] = {
        GridId: GridId,
        ActiveRecord: undefined,
        GridSelector: undefined,
        GridUrl: "",
        setGridUrl: SetGridURL,
        reloadGrid: ReloadGrid,
        getActiveRecordProperties: GetActiveRecordProperties
    };

    if (GridId !== undefined) {
        main.pageGrids[GridId].GridSelector = $("#" + GridId);
        var $listButton = main.pageGrids[GridId].GridSelector.parents('.ibox-content').find('.grid-list-button');

        $listButton.data('grid-id', GridId);
        $listButton.click(function (e) {
            e.preventDefault();

            var gridId = $(this).data('grid-id');
            var form = $('.grid-filter').find('form');

            var url = $(this).attr("href");

            url = AppendQueryString(url, 'nd=' + new Date().getTime());
            if (form != undefined) {
                // url = url + '&' + $(form).serialize();
            }

            main.pageGrids[gridId].setGridUrl(url, main.pageGrids[GridId]);

            return false;
        });

        //bootgrid initilize
        main.pageGrids[GridId].GridSelector.bootstrapTable(
            {
                queryParams: function (p) {
                    var form = $('.grid-filter').find('form');
                    var data = {};
                    if (form != undefined) {
                        $(form).serializeArray().map(function (x) { data[x.name] = x.value; });
                    }

                    var json2 = {
                        order: p.order,
                        limit: p.limit,
                        offset: p.offset,
                        search: p.search,
                        sort: p.sort
                    };
                    var finalobj = {};
                    for (var _obj in json2) finalobj[_obj] = json2[_obj];
                    for (var _obj in data) finalobj[_obj] = data[_obj];
                    return finalobj;
                },
                onLoadSuccess: function (e) {
                    main.pageGrids[GridId].ActiveRecord = undefined;
                },
                onCheck: function (row, $element) {
                    // console.log(row);
                    main.pageGrids[GridId].ActiveRecord = row;
                }
            });

        if ($listButton.hasClass("grid-immediate")) {
            $listButton.click();
        }
    }
};

//formatters
var Formatters = {
    date: function (value, row, index){
        var milisecond = value.split("(")[1].split(")")[0],
            date = new Date(parseInt(milisecond));

        return date.toJSON().split("T")[0];
    },
    checkbox: function (value, row, index) {
        if (value)
            return "<input name='select' type='checkbox' checked disabled='disabled' value='"+value+"'/>";
        else
            return "<input name='select' type='checkbox' disabled='disabled' value='" + value +"'/> ";
    },
    link: function (value, row, index) {
        if (value == null || value == "")
            return "";
        return "<a href='"+value+"'>" + value + "</a>";
    }
}

function SetGridURL(url, grid) {

    grid.GridSelector.on('load-success.bs.table', function (e) {
        grid.GridSelector.parents('.ibox-content').find('.grid-list-button').find('i').removeClass('fa-spin');
    });

    grid.GridSelector.parents('.ibox-content').find('.grid-list-button').find('i').addClass('fa-spin')
    var form = $('.grid-filter').find('form');
    var data = {};
    if (form != undefined) {
        $(form).serializeArray().map(function (x) { data[x.name] = x.value; });
    }

    if (grid.GridSelector !== undefined) {
        grid.GridUrl = url;
        grid.GridSelector.bootstrapTable(
            'refresh',
            {
                url: url,
                query: data
            }
        );

        $(document).ready(function () {
            $('.fixed-table-body').scroll(function () {
                $('.fixed-table-footer').scrollLeft($(this).scrollLeft());
            });
        });
    }

}

function ReloadGrid() {
    this.GridSelector.on('load-success.bs.table', function (e) {
        $('.grid-list-button').find('i').removeClass('fa-spin');
    });

    this.GridSelector.parents('.ibox-content').find('.grid-list-button').find('i').addClass('fa-spin')
    var form = $('.grid-filter').find('form');
    var data = {};
    if (form != undefined) {
        $(form).serializeArray().map(function (x) { data[x.name] = x.value; });
    }

    this.GridSelector.bootstrapTable("refresh", { query: data });
}

function GetActiveRecordProperties(props) {
    var activeRecord = this.ActiveRecord;
    var queryString = '';
    if (props != undefined && props != null) {
        var names = props.split(',');
        $(names).each(function () {
            var name = $.trim(this);
            if (name !== '') {
                queryString = queryString + '&' + name + '=' + encodeURIComponent(activeRecord[name])
            }
        });
    }
    return queryString;
}


function BindToolbarButtons() {
    $('.bound-btn').on('click', function (e) {
        var relatedGrid = main.pageGrids[$(this).parents('.ibox-content').find('.ts-grid').attr('id')];
        var method = "GET";
        e.preventDefault();
        var btn = $(this);
        var data = $(this).data();

        if (data.binding == 'ActiveRecord' && relatedGrid.ActiveRecord == undefined) {
            //alert('Please select a row first!');
            main.tpop({ msg: 'Please select a row first!', type: 'warning' });
        }
        else {
            var url = $(this).attr("href");
            var parameters = {};
            console.log(data.binding);
            if (data.binding !== undefined) {
                if (data.binding == 'ActiveRecord')
                    url = AppendQueryString(url, relatedGrid.getActiveRecordProperties(data.bindingProps));
                else {
                    var form = $('.grid-filter').find('form');
                    if (form != undefined) {
                        // url = url + '&' + $(form).serialize();
                        $(form).serializeArray().map(function (x) { parameters[x.name] = x.value; });
                    }
                }
            }
            url = AppendQueryString(url, 'nd=' + new Date().getTime());

            if (data.actionTarget === "Dialog") {
                $.fancybox.open({
                    type: 'ajax', src: url, modal: true, padding: 0,
                    afterLoad: function () {
                          InitFormElements('.fancybox-inner form');
                    }
              });
            }
            else
                if (data.actionTarget === "Window") {
                    window.location = AppendQueryString($(this).attr("href"), relatedGrid.getActiveRecordProperties(data.bindingProps).replace('&', ''));
                }
                else {
                    window.open(url, "popupWindow", "width=800,height=600,scrollbars=yes");
                }
        }
        return false;
    });
};

$(function () {
    $('.ts-grid').each(function () {
        new GridPageData($(this));
    })

    // InitFormElements('form');

    BindToolbarButtons();

});

function formatterInt(data, userdata) {
    if (userdata !== undefined) {
        var columnInfo = this;
        var footerTable = ""
        if (userdata.constructor === Array) {
            userdata.forEach(function (e, v) {
                footerTable += "<div><strong>" + e[columnInfo.footerField] + "</strong></div>"
            });
        } else {
            footerTable += "<div><strong>" + userdata[columnInfo.footerField] + "</strong></div>"
        }
        return footerTable;
    }

    return "";
}

function formatterMoney(data, userdata) {
    if (userdata !== undefined && userdata != null) {
        var columnInfo = this;
        var footerTable = "";
        var currency = "";
        if (typeof globalCurrency != 'undefined')
            currency = globalCurrency;

        if (userdata.constructor === Array) {
            userdata.forEach(function (e, v) {
                var currencyAttr = getCurrencyAttributeNamefromJSONObj(e);
                if (currencyAttr != null) {
                    if (e[currencyAttr] != null)
                        currency = e[currencyAttr];
                }
                if (e[columnInfo.footerField] != null) {
                    footerTable += "<div><strong>" + e[columnInfo.footerField] + " " + currency + "</strong></div>"
                }
            });
        } else {
            var currencyAttr = getCurrencyAttributeNamefromJSONObj(userdata);
            if (currencyAttr != null) {
                if (userdata[currencyAttr] != null)
                    currency = userdata[currencyAttr];
            }
            if (userdata[columnInfo.footerField] != null) {
                footerTable += "<div><strong>" + userdata[columnInfo.footerField] + " " + currency + "</strong></div>";
            }
        }
        return footerTable;
    }
    return "";
}

function getCurrencyAttributeNamefromJSONObj(userdata) {
    for (var key in userdata) {
        if (key.toLowerCase().indexOf("currency") >= 0) {
            return key;
        }
    }
    return null;
}
