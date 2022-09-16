(function ($) {
    "use strict"; // Start of use strict
    $(function () {
        //Tag Toggle
        if ($('.toggle-tab').length > 0) {
            $('.toggle-tab').each(function () {
                $(this).find('.item-toggle-tab').first().find('.toggle-tab-content').show();
                $('.toggle-tab-title').on('click', function () {
                    $(this).parent().siblings().removeClass('active');
                    $(this).parent().toggleClass('active');
                    $(this).parents('.toggle-tab').find('.toggle-tab-content').slideUp();
                    $(this).next().stop(true, false).slideToggle();
                });
            });
        }

        $('.wishlist-button a').click(function () {
            var data = $(this).data();
            if (data.closePopUp == true)
                $('.wishlist-mask').hide();
            if (data.goBasket == true)
                window.location = "/basket/overview/";
        });
        $('.main-header .wishlist-count a').click(function () {
            var wishlist = localStorage.getItem("wishlist");
            console.log(wishlist);
        });
        //Menu Responsive
        $('.toggle-mobile-menu').on('click', function (event) {
            event.preventDefault();
            $(this).parents('.main-nav').toggleClass('active');
            $('body').toggleClass('ovr');
        });
        $('.main-nav li.menu-item-has-children>a').on('click', function (event) {
            if ($(window).width() < 768) {
                event.preventDefault();
                $(this).next().stop(true, false).slideToggle();
            }
        });
        //Custom ScrollBar
        if ($('.custom-scroll').length > 0) {
            $('.custom-scroll').each(function () {
                $(this).mCustomScrollbar({
                    scrollButtons: {
                        enable: true
                    }
                });
            });
        }
    });
    //Offset Menu
    function offset_menu() {
        if ($(window).width() > 767) {
            $('.main-nav .sub-menu').each(function () {
                var wdm = $(window).width();
                var wde = $(this).width();
                var offset = $(this).offset().left;
                var tw = offset + wde;
                if (tw > wdm) {
                    $(this).addClass('offset-right');
                }
            });
        } else {
            return false;
        }
    }
    //Fixed Header
    function fixed_header() {
        if ($('.header-ontop').length > 0) {
            if ($(window).width() > 1023) {
                var ht = $('#header').height();
                var st = $(window).scrollTop();
                if (st > ht) {
                    $('.header-ontop').addClass('fixed-ontop');
                } else {
                    $('.header-ontop').removeClass('fixed-ontop');
                }
            } else {
                $('.header-ontop').removeClass('fixed-ontop');
            }
        }
    }
    //Slider Background
    function background() {
        $('.bg-slider .item-slider').each(function () {
            var src = $(this).find('.banner-thumb a img').attr('src');
            $(this).css('background-image', 'url("' + src + '")');
        });
    }
    function animated() {
        $('.banner-slider .owl-item').each(function () {
            var check = $(this).hasClass('active');
            if (check == true) {
                $(this).find('.animated').each(function () {
                    var anime = $(this).attr('data-animated');
                    $(this).addClass(anime);
                });
            } else {
                $(this).find('.animated').each(function () {
                    var anime = $(this).attr('data-animated');
                    $(this).removeClass(anime);
                });
            }
        });
    }

    function createZoom($targetImg) {
        if ($targetImg.parents('.quickview').length == 0) {
            $('.zoomContainer').remove();
            $targetImg.removeData('elevateZoom');
            $targetImg.removeData('zoomImage');

            $targetImg.elevateZoom({
                zoomType: "inner",
                cursor: "crosshair",
                zoomWindowFadeIn: 500,
                zoomWindowFadeOut: 750
            });
        }
    }
    //Detail Gallery
    function detail_gallery($targetElement) {
        if ($targetElement == undefined || $targetElement == null)
            return;

        if ($targetElement.find('.wrap-detail-gallery').length > 0) {
            $targetElement.find('.wrap-detail-gallery').each(function () {
                $(this).find(".carousel").jCarouselLite({
                    btnNext: $(this).find(".gallery-control .next"),
                    btnPrev: $(this).find(".gallery-control .prev"),
                    speed: 800,
                    visible: 3,
                    circular: false
                });
                //Elevate Zoom
                createZoom($(this).first().find('.mid img'));
                //$('.wrap-detail-gallery').first().find('.mid img').elevateZoom({
                //    zoomType: "inner",
                //    cursor: "crosshair",
                //    zoomWindowFadeIn: 500,
                //    zoomWindowFadeOut: 750
                //});
                $(this).find(".carousel a").on('click', function (event) {
                    event.preventDefault();
                    var $gallery = $(this).parents('.wrap-detail-gallery').first();
                    $gallery.find(".carousel a").removeClass('active');
                    $(this).addClass('active');
                    var z_url = $(this).data().src;
                    $gallery.find(".mid img").attr("src", z_url);

                    createZoom($gallery.find('.mid img'));
                });
            });
        }
    }

    // Handle the start of gestures
    function  handleGestureStart(event) {
        evt.preventDefault();

        if (event.touches && evt.touches.length > 1) {
            return;
        }

        // Add the move and end listeners
        if (window.PointerEvent) {
            event.target.setPointerCapture(evt.pointerId);
        } else {
            // Add Mouse Listeners
            document.addEventListener('mousemove', this.handleGestureMove, true);
            document.addEventListener('mouseup', this.handleGestureEnd, true);
        }

        initialTouchPos = getGesturePointFromEvent(event);

        swipeFrontElement.style.transition = 'initial';
    }

    // Handle end gestures
    function handleGestureEnd(event) {
        event.preventDefault();

        if (event.touches && evt.touches.length > 0) {
            return;
        }

        rafPending = false;

        // Remove Event Listeners
        if (window.PointerEvent) {
            event.target.releasePointerCapture(evt.pointerId);
        } else {
            // Remove Mouse Listeners
            document.removeEventListener('mousemove', this.handleGestureMove, true);
            document.removeEventListener('mouseup', this.handleGestureEnd, true);
        }

        updateSwipeRestPosition();

        initialTouchPos = null;
    }

    function handleGestureMove(event) {
        event.preventDefault();

        if (!initialTouchPos) {
            return;
        }

        lastTouchPos = getGesturePointFromEvent(event);

        if (rafPending) {
            return;
        }

        rafPending = true;

        window.requestAnimFrame(onAnimFrame);
    }

    //Document Ready
    jQuery(document).ready(function () {
        //Mix Filter
        if ($('.grid-portfolio').length > 0) {
            $('.grid-portfolio').mixItUp();
        }
        //Filter Color
        $('.widget-filter ul li a ').on('click', function (event) {
            $(this).parent().toggleClass('active');
            //event.preventDefault();
        });
        //Widget Faqs
        $('.widget-faqs li').first().addClass('active');
        $('.widget-faqs li').find('p').hide();
        $('.widget-faqs li').first().find('p').show();
        $('.widget-faqs li h3').on('click', function () {
            $(this).parent().siblings().removeClass('active');
            $(this).parent().addClass('active');
            $('.widget-faqs p').not($(this).next()).slideUp();
            $(this).next().slideDown();
        });
        //Control Color
        $('.color-control a').on('click', function (event) {
            event.preventDefault();
            var src = $(this).attr('data-src');
            $(this).parents('.item-product').find('.product-thumb-link img').hide().attr('src', src).fadeIn(1000);
        });

        //Banner Background
        if ($('.banner-background').length > 0) {
            $('.banner-background').each(function () {
                var bn_src = $(this).find('.image-background').attr('src');
                $(this).css('background-image', 'url("' + bn_src + '")')
            });
        }

        if ($('.range-filter').length > 0) {
            $('.range-filter').each(function () {
                $(this).find(".slider-range").slider({
                    range: true,
                    min: 0,
                    max: 2500,
                    values: [450, 2000],
                    slide: function (event, ui) {
                        $(this).parents('.range-filter').find(".amount").html("$" + ui.values[0] + " - " + "$" + ui.values[1]);
                    }
                });
                $(this).find(".amount").html("$" + $(this).find(".slider-range").slider("values", 0) + " - " + "$" + $(this).find(".slider-range").slider("values", 1));
            });

        }
        //Qty Up-Down
        $('.info-qty').each(function () {
            var qtyval = parseInt($(this).find('.qty-val').text(), 10);
            $(this).find('.qty-up').on('click', function (event) {
                event.preventDefault();
                qtyval = qtyval + 1;
                $('.qty-val').text(qtyval);
            });
            $(this).find('.qty-down').on('click', function (event) {
                event.preventDefault();
                qtyval = qtyval - 1;
                if (qtyval > 1) {
                    $('.qty-val').text(qtyval);
                } else {
                    qtyval = 1;
                    $('.qty-val').text(qtyval);
                }
            });
        });
        //Offset Menu
        offset_menu();
        //Animate
        if ($('.wow').length > 0) {
            new WOW().init();
        }
        //Video Light Box
        if ($('.btn-video').length > 0) {
            $('.btn-video').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                prevEffect: 'none',
                nextEffect: 'none',

                arrows: false,
                helpers: {
                    media: {},
                    buttons: {}
                }
            });
        }
        //Light Box
        if ($('.fancybox').length > 0) {
            $('.fancybox').fancybox();
        }
        //Zoom Thumb
        if ($('.quick-view-thumb').length > 0) {
            $('.quick-view-thumb').fancybox();
        }
        //Back To Top
        $('.scroll-top').on('click', function (event) {
            event.preventDefault();
            $('html, body').animate({ scrollTop: 0 }, 'slow');
        });

        window.detailGallery = detail_gallery;

        // Check if pointer events are supported.
        if (window.PointerEvent) {
            // Add Pointer Event Listener
            //$('.owl-item').on('pointerdown', handleGestureStart);
            //$('.owl-item').on('pointermove', handleGestureMove);
            //$('.owl-item').on('pointerup', handleGestureEnd);
            //$('.product-slider2 .owl-item').on('pointercancel', handleGestureEnd);

            //document.addEventListener('pointerdown', this.handleGestureStart, true);
            //document.addEventListener('pointermove', this.handleGestureMove, true);
            //document.addEventListener('pointerup', this.handleGestureEnd, true);
            //document.addEventListener('pointercancel', this.handleGestureEnd, true);
        } else {
            //// Add Touch Listener
            //document.addEventListener('touchstart', this.handleGestureStart, true);
            //document.addEventListener('touchmove', this.handleGestureMove, true);
            //document.addEventListener('touchend', this.handleGestureEnd, true);
            //document.addEventListener('touchcancel', this.handleGestureEnd, true);

            //// Add Mouse Listener
            //document.addEventListener('mousedown', this.handleGestureStart, true);
        }

        //Detail Gallery
        detail_gallery($('body'));
        //Filter Price
    });
    //Window Load
    jQuery(window).on('load', function () {
        //Owl Carousel
        if ($('.wrap-item').length > 0) {
            $('.wrap-item').each(function () {
                var data = $(this).data();
                var owl = $(this).owlCarousel({
                    addClassActive: true,
                    stopOnHover: true,
                    itemsCustom: data.itemscustom,
                    autoPlay: data.autoplay,
                    transitionStyle: data.transition,
                    paginationNumbers: data.paginumber,
                    beforeInit: background,
                    afterAction: animated,
                    navigationText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>']
                });
            });
        }

        //Parallax Slider
        if ($('.parallax-slider').length > 0) {
            $(window).scroll(function () {
                var ot = $('.parallax-slider').offset().top;
                var sh = $('.parallax-slider').height();
                var st = $(window).scrollTop();
                var top = (($(window).scrollTop() - ot) * 0.5) + 'px';
                if (st > ot && st < ot + sh) {
                    $('.parallax-slider .item-slider').css({
                        'background-position': 'center ' + top
                    });
                } else if (st < ot) {
                    $('.parallax-slider .item-slider').css({
                        'background-position': 'center 0'
                    });
                } else {
                    return false;
                }
            });
        }
        //Bx Slider
        if ($('.bxslider').length > 0) {
            $('.bxslider').each(function () {
                $(this).find('.bx-slider').bxSlider({
                    pagerCustom: $(this).find('.bx-pager'),
                    nextText: '<i class="fa fa-angle-right" aria-hidden="true"></i>',
                    prevText: '<i class="fa fa-angle-left" aria-hidden="true"></i>',
                    responsive: true,
                });
            });
        }
        //Day Countdown
        if ($('.days-countdown').length > 0) {
            $(".days-countdown").TimeCircles({
                fg_width: 0.05,
                bg_width: 0,
                text_size: 0,
                circle_bg_color: "transparent",
                time: {
                    Days: {
                        show: true,
                        text: "D",
                        color: "#fff"
                    },
                    Hours: {
                        show: true,
                        text: "H",
                        color: "#fff"
                    },
                    Minutes: {
                        show: true,
                        text: "M",
                        color: "#fff"
                    },
                    Seconds: {
                        show: true,
                        text: "S",
                        color: "#fff"
                    }
                }
            });
        }
    });
    //Window Resize
    jQuery(window).on('resize', function () {
        offset_menu();
        fixed_header();
        detail_gallery();
    });
    //Window Scroll
    jQuery(window).on('scroll', function () {
        //Scroll Top
        if ($(this).scrollTop() > $(this).height()) {
            $('.scroll-top').addClass('active');
        } else {
            $('.scroll-top').removeClass('active');
        }
        //Fixed Header
        fixed_header();
    });
})(jQuery); // End of use strict