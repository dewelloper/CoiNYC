/// Global
var
    main = {
        pageGrids: {}
    };

$.fancybox.defaults.afterLoad = function () {
    InitFormElements('.fancybox-inner form');
};

$.fancybox.defaults.beforeClose = function () {
    DestroyFormElements('.fancybox-inner form');
};

$.ajaxSetup({
    // Disable caching of AJAX responses
    cache: false,
    statusCode: {
        401: function (xhr, t, e) {
            var url = "/";
            if (xhr.getResponseHeader("Redirect-url") != undefined)
                url = xhr.getResponseHeader("Redirect-url");
            window.location = url;
        }/*,
        400: function (xhr, t, e) {
            main.tpop({
                type: "error",
                closeButton: true,
                progressBar: true,
                msg: xhr.responseJSON.Messages[0]
            });
        },
        500: function (xhr, t, e) {
            main.loadingTarget({ sw: false });
            $('.main').hide();

            main.tpop({
                type: "error",
                closeButton: true,
                progressBar: true,
                msg: xhr.responseJSON.Messages[0]
            });

        }*/
    }
});


function AppendQueryString(url, parameter) {
    if (parameter != undefined && parameter != null && parameter != "") {
        if (url.indexOf("?") === -1)
            url = url + "?";
        else
            url = url + "&";
        url = url + parameter;
    }
    return url;
}

function reloadGallery($gallery) {
    $gallery.find('[data-fancybox="gallery-items"]').fancybox(
        {
            animationEffect: false,
            thumbs: { autoStart: true }
        }
    );
}

function copyToClipboard(text) {
    if (window.clipboardData && window.clipboardData.setData) {
        // IE specific code path to prevent textarea being shown while dialog is visible.
        return clipboardData.setData("Text", text);

    } else if (document.queryCommandSupported && document.queryCommandSupported("copy")) {
        var textarea = document.createElement("textarea");
        textarea.textContent = text;
        textarea.style.position = "fixed";  // Prevent scrolling to bottom of page in MS Edge.
        document.body.appendChild(textarea);
        textarea.select();
        try {
            return document.execCommand("copy");  // Security exception may be thrown by some browsers.
        } catch (ex) {
            console.warn("Copy to clipboard failed.", ex);
            return false;
        } finally {
            document.body.removeChild(textarea);
        }
    }
}

function fixForm($selector) {
    $selector.find('.collapse-link').click(function () {
        var ibox = $(this).closest('div.ibox');
        var button = $(this).find('i');
        var content = ibox.children('.ibox-content');
        content.slideToggle(200);
        button.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
        ibox.toggleClass('').toggleClass('border-bottom');
        setTimeout(function () {
            ibox.resize();
            ibox.find('[id^=map-]').resize();
        }, 50);
    });

    // Close ibox function
    $selector.find('.close-link').click(function () {
        var content = $(this).closest('div.ibox');
        content.remove();
    });

    // Fullscreen ibox function
    $selector.find('.fullscreen-link').click(function () {
        var ibox = $(this).closest('div.ibox');
        var button = $(this).find('i');
        $('body').toggleClass('fullscreen-ibox-mode');
        button.toggleClass('fa-expand').toggleClass('fa-compress');
        ibox.toggleClass('fullscreen');
        setTimeout(function () {
            $(window).trigger('resize');
        }, 100);
    });

}
function DestroyFormElements(formSelector) {
    try {
        $(formSelector).find('.colorpicker-component').colorpicker('destroy');
    } catch (e) {
    }
}

function InitFormElements(formSelector) {
    BindFormValidationClasses(formSelector);
    fixForm($(formSelector));

    $('.date').each(function (x) {
        $(this).removeClass('hasDatepicker');

        var settings = $(this).data();

        if (settings.calendarMonthonly) {
            settings.beforeShow = function (input, obj) {
                $('#ui-datepicker-div').addClass('month-picker');
            };

            settings.onClose = function (dateText, inst) {
                var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                $(this).datepicker('setDate', new Date(year, month, 1));
                $('#ui-datepicker-div').hide().removeClass('month-picker');
            };
        }

        $(this).datepicker(settings);
    });

    try {
        $(formSelector).find('.colorpicker-component').colorpicker();
    } catch (e) {
    }

    $('select[data-hascascade]').each(function () {
        var thisEle = $(this);
        if (!thisEle.hasClass("cascadebound")) {
            thisEle.addClass("cascadebound");
            var data = thisEle.data();
            thisEle.closest("form").find('#' + data.cascadesource).on("change", function () {
                var url = data.cascadeurl + $(this).val();
                ChangeComboItems(this, thisEle.attr("Id"), url)
            });
        }
    })

};

function RefreshPage() {
    window.location = window.location;
}

function RefreshGallery($gallery) {
    if ($gallery == undefined && $.fancybox.getInstance() !== false) {
        var galleryId = $.fancybox.getInstance().$refs.inner.data('galleryId');
        $gallery = $('#' + galleryId + '');
    }

    if ($gallery != undefined) {
        $.ajax({
            type: "GET",
            url: $gallery.data().src,
            success: function (result) {
                $gallery.html(result);
            },
        });
    }
}


$(document).ready(function () {
    $.fancybox.defaults.animationEffect = false;
    $.fancybox.defaults.clickContent = function () { return false; };

    $('.sidebar-collapse').slimScroll({
        height: '100%',
        railOpacity: 0.9
    });

    $(document).on('click', '.html-edit', function () {
        $this = $(this);
        $this.siblings('.html-save').show();
        $this.hide();
        $this.parents('.html-zone-wrapper').find('.html-zone').summernote({ focus: true, onCreateLink: function (linkUrl) { return linkUrl; } });
    });

    $(document).on('click', '.html-save', function () {
        $this = $(this);
        $this.siblings('.html-edit').show();
        $this.hide();
        $htmlZone = $this.parents('.html-zone-wrapper').find('.html-zone');
        var text = $('<div/>').text($htmlZone.summernote('code')).html();
        $htmlZone.siblings('input').val(text);
        $htmlZone.summernote('destroy');

    });

    $(document).on('click', '.lang-toggle', function () {
        $this = $(this);
        data = $this.data();
        $langContent = $($this.siblings('.lang-content')[0]);
        if (data.disableTarget != undefined) {
            $(data.disableTarget).toggle();
        }

        if (!data.loaded) {
            $.ajax({
                type: "GET",
                url: data.src,
                success: function (result) {
                    $langContent.html(result);
                    $langContent.toggle();
                    $this.data("loaded", "true");
                    fixForm($langContent);
                    //   reloadGallery($gallery);
                },
                error: function (xhr, status, p3, p4) {
                    var err = "Error " + " " + status + " " + p3 + " " + p4;
                    if (xhr.responseText && xhr.responseText[0] == "{")
                        err = JSON.parse(xhr.responseText).Message;
                    console.log(err);
                }
            });
        }
        else {
            $langContent.toggle();
        }
    });

    $(document).on('click', 'a[data-copy]', function () {
        $this = $(this);
        $hidden = $this.find('[hidden]');
        if ($hidden != undefined) {
            copyToClipboard($hidden.html());
        }
    });

    $(document).on('click', 'a.gallery-button', function () {
        $this = $(this);
        $gallery = $this.parents('.picture-gallery')
        if ($gallery.attr('id') == undefined) {
            $gallery.attr('id', 'pg-' + $('.picture-gallery').length);
        }

        $.fancybox.open({
            type: 'ajax', src: $this.data().src, modal: true, padding: 0,
            buttons: ['close'],
            afterLoad: function () {
                InitFormElements('.fancybox-inner form');
                $.fancybox.getInstance().$refs.inner.data('galleryId', $gallery.attr('id'));
            }
        });
    });

    $('.picture-gallery').each(function (index, el) {
        RefreshGallery($(el));
    });

    $(document).on('click', 'a.image-uploader', function () {
        $this = $(this);
        $form = $this.parents('form');

        $fileInput = $form.find('input[type="file"]');
        var files = $fileInput[0].files;

        if (files.length > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();
                data.append($fileInput[0].name, files[0]);
                $form.find(':input:not(:file, :button)').each(function () {
                    data.append(this.name, this.value);
                });

                $.ajax({
                    type: "POST",
                    url: $form[0].action,
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function () {
                        RefreshGallery();
                        $.fancybox.close();
                        //   reloadGallery($gallery);
                    }
                });
            } else {
                alert("This browser doesn't support HTML5 file uploads!");
            }
        }
    });

    //$form = $('.image-uploader').find('form');
    //$gallery = $('.image-uploader').find('.image-gallery');
    //$form.submit(function (event) {
    //    event.preventDefault();

    //    $fileInput = $form.find('input[type="file"]');
    //    var files = $fileInput[0].files;

    //    if (files.length > 0) {
    //        if (window.FormData !== undefined) {
    //            var data = new FormData();
    //            data.append($fileInput[0].name, files[0]);
    //            $form.find(':input:not(:file, :button)').each(function () {
    //                data.append(this.name, this.value);
    //            });
    //            //for (var x = 0; x < files.length; x++) {
    //            //    data.append("file" + x, files[x]);
    //            //}

    //            $.ajax({
    //                type: "POST",
    //                url: $form[0].action,
    //                contentType: false,
    //                processData: false,
    //                data: data,
    //                success: function (result) {
    //                    $gallery.html(result);
    //                 //   reloadGallery($gallery);
    //                },
    //                error: function (xhr, status, p3, p4) {
    //                    var err = "Error " + " " + status + " " + p3 + " " + p4;
    //                    if (xhr.responseText && xhr.responseText[0] == "{")
    //                        err = JSON.parse(xhr.responseText).Message;
    //                    console.log(err);
    //                }
    //            });
    //        } else {
    //            alert("This browser doesn't support HTML5 file uploads!");
    //        }
    //    }

    //});
    //$form.ajaxForm({
    //    success: function (data) {
    //        $gallery.html(data);
    //    },
    //}); 

    //$form.submit(function () {
    //    // inside event callbacks 'this' is the DOM element so we first 
    //    // wrap it in a jQuery object and then invoke ajaxSubmit 
    //    $(this).ajaxSubmit({
    //        success: function (data) {
    //            $gallery.html(data);
    //        },
    //    });

    //    // !!! Important !!! 
    //    // always return false to prevent standard browser submit and page navigation 
    //    return false;
    //});

});


