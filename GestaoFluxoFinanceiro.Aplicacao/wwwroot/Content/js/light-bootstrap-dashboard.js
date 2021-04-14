/*!

 =========================================================
 * Light Bootstrap Dashboard - v2.0.1
 =========================================================

 * Product Page: http://www.creative-tim.com/product/light-bootstrap-dashboard
 * Copyright 2017 Creative Tim (http://www.creative-tim.com)
 * Licensed under MIT (https://github.com/creativetimofficial/light-bootstrap-dashboard/blob/master/LICENSE.md)

 =========================================================

 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

 */

var searchVisible = 0;
var transparent = true;

var transparentDemo = true;
var fixedTop = false;

var navbar_initialized = false;
var mobile_menu_visible = 0,
    mobile_menu_initialized = false,
    toggle_initialized = false,
    bootstrap_nav_initialized = false,
    $sidebar,
    isWindows;

$(document).ready(function() {
    window_width = $(window).width();

    // check if there is an image set for the sidebar's background
    lbd.checkSidebarImage();

    // Init navigation toggle for small screens
    if (window_width <= 991) {
        lbd.initRightMenu();
    }

    //  Activate the tooltips
    $('[rel="tooltip"]').tooltip();

    //      Activate regular switches
    if ($("[data-toggle='switch']").length != 0) {
        $("[data-toggle='switch']").bootstrapSwitch();
    }

    $('.form-control').on("focus", function() {
        $(this).parent('.input-group').addClass("input-group-focus");
    }).on("blur", function() {
        $(this).parent(".input-group").removeClass("input-group-focus");
    });

    // Fixes sub-nav not working as expected on IOS
    $('body').on('touchstart.dropdown', '.dropdown-menu', function(e) {
        e.stopPropagation();
    });
});

// activate collapse right menu when the windows is resized
$(window).resize(function() {
    if ($(window).width() <= 991) {
        lbd.initRightMenu();
    }
});

lbd = {
    misc: {
        navbar_menu_visible: 0
    },
    checkSidebarImage: function() {
        $sidebar = $('.sidebar');
        image_src = $sidebar.data('image');

        if (image_src !== undefined) {
            sidebar_container = '<div class="sidebar-background" style="background-image: url(' + image_src + ') "/>'
            $sidebar.append(sidebar_container);
        } else if (mobile_menu_initialized == true) {
            // reset all the additions that we made for the sidebar wrapper only if the screen is bigger than 991px
            $sidebar_wrapper.find('.navbar-form').remove();
            $sidebar_wrapper.find('.nav-mobile-menu').remove();

            mobile_menu_initialized = false;
        }
    },

    initRightMenu: function() {
        $sidebar_wrapper = $('.sidebar-wrapper');

        if (!mobile_menu_initialized) {

            $navbar = $('nav').find('.navbar-collapse').first().clone(true);

            nav_content = '';
            mobile_menu_content = '';

            //add the content from the regular header to the mobile menu
            $navbar.children('ul').each(function() {

                content_buff = $(this).html();
                nav_content = nav_content + content_buff;
            });

            nav_content = '<ul class="nav nav-mobile-menu">' + nav_content + '</ul>';

            $navbar_form = $('nav').find('.navbar-form').clone(true);

            $sidebar_nav = $sidebar_wrapper.find(' > .nav');

            // insert the navbar form before the sidebar list
            $nav_content = $(nav_content);
            $nav_content.insertBefore($sidebar_nav);
            $navbar_form.insertBefore($nav_content);

            $(".sidebar-wrapper .dropdown .dropdown-menu > li > a").click(function(event) {
                event.stopPropagation();

            });

            mobile_menu_initialized = true;
        } else {
            console.log('window with:' + $(window).width());
            if ($(window).width() > 991) {
                // reset all the additions that we made for the sidebar wrapper only if the screen is bigger than 991px
                $sidebar_wrapper.find('.navbar-form').remove();
                $sidebar_wrapper.find('.nav-mobile-menu').remove();

                mobile_menu_initialized = false;
            }
        }

        if (!toggle_initialized) {
            $toggle = $('.navbar-toggler');

            $toggle.click(function() {

                if (mobile_menu_visible == 1) {
                    $('html').removeClass('nav-open');

                    $('.close-layer').remove();
                    setTimeout(function() {
                        $toggle.removeClass('toggled');
                    }, 400);

                    mobile_menu_visible = 0;
                } else {
                    setTimeout(function() {
                        $toggle.addClass('toggled');
                    }, 430);


                    main_panel_height = $('.main-panel')[0].scrollHeight;
                    $layer = $('<div class="close-layer"></div>');
                    $layer.css('height', main_panel_height + 'px');
                    $layer.appendTo(".main-panel");

                    setTimeout(function() {
                        $layer.addClass('visible');
                    }, 100);

                    $layer.click(function() {
                        $('html').removeClass('nav-open');
                        mobile_menu_visible = 0;

                        $layer.removeClass('visible');

                        setTimeout(function() {
                            $layer.remove();
                            $toggle.removeClass('toggled');

                        }, 400);
                    });

                    $('html').addClass('nav-open');
                    mobile_menu_visible = 1;

                }
            });

            toggle_initialized = true;
        }
    }
}



// Returns a function, that, as long as it continues to be invoked, will not
// be triggered. The function will be called after it stops being called for
// N milliseconds. If `immediate` is passed, trigger the function on the
// leading edge, instead of the trailing.

function debounce(func, wait, immediate) {
    var timeout;
    return function() {
        var context = this,
            args = arguments;
        clearTimeout(timeout);
        timeout = setTimeout(function() {
            timeout = null;
            if (!immediate) func.apply(context, args);
        }, wait);
        if (immediate && !timeout) func.apply(context, args);
    };
};

function initDashboardPageCharts() {

    var dataPreferences = {
        series: [
            [25, 30, 20, 25]
        ]
    };

    var optionsPreferences = {
        donut: true,
        donutWidth: 40,
        startAngle: 0,
        total: 100,
        showLabel: false,
        axisX: {
            showGrid: false
        }
    };

    Chartist.Pie('#chartPreferences', dataPreferences, optionsPreferences);

    Chartist.Pie('#chartPreferences', {
        labels: ['53%', '36%', '11%'],
        series: [53, 36, 11]
    });


    var dataSales = {
        labels: ['9:00AM', '12:00AM', '3:00PM', '6:00PM', '9:00PM', '12:00PM', '3:00AM', '6:00AM'],
        series: [
            [287, 385, 490, 492, 554, 586, 698, 695, 752, 788, 846, 944],
            [67, 152, 143, 240, 287, 335, 435, 437, 539, 542, 544, 647],
            [23, 113, 67, 108, 190, 239, 307, 308, 439, 410, 410, 509]
        ]
    };

    // var optionsSales = {
    //   lineSmooth: false,
    //   low: 0,
    //   high: 800,
    //    chartPadding: 0,
    //   showArea: true,
    //   height: "245px",
    //   axisX: {
    //     showGrid: false,
    //   },
    //   axisY: {
    //     showGrid: false,
    //   },
    //   lineSmooth: Chartist.Interpolation.simple({
    //     divisor: 6
    //   }),
    //   showLine: false,
    //   showPoint: true,
    //   fullWidth: true
    // };
    var optionsSales = {
        lineSmooth: false,
        low: 0,
        high: 800,
        showArea: true,
        height: "245px",
        axisX: {
            showGrid: false,
        },
        lineSmooth: Chartist.Interpolation.simple({
            divisor: 3
        }),
        showLine: false,
        showPoint: false,
        fullWidth: false
    };

    var responsiveSales = [
        ['screen and (max-width: 640px)', {
            axisX: {
                labelInterpolationFnc: function(value) {
                    return value[0];
                }
            }
        }]
    ];

    var chartHours = Chartist.Line('#chartHours', dataSales, optionsSales, responsiveSales);

    // lbd.startAnimationForLineChart(chartHours);

    var data = {
        labels: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez  '],
        series: [
            [542, 443, 320, 780, 553, 453, 326, 434, 568, 610, 756, 895]
        ]
    };

    var options = {
        seriesBarDistance: 10,
        axisX: {
            showGrid: false
        },
        height: "245px"
    };

    var responsiveOptions = [
        ['screen and (max-width: 640px)', {
            seriesBarDistance: 5,
            axisX: {
                labelInterpolationFnc: function(value) {
                    return value[0];
                }
            }
        }]
    ];

    var chartActivity = Chartist.Bar('#chartActivity', data, options, responsiveOptions);

    var data2 = {
        labels: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez  '],
        series: [
            [456, 89, 498, 123, 438, 368, 234, 785, 125, 12, 542, 322]
        ]
    };

    var options2 = {
        seriesBarDistance: 10,
        axisX: {
            showGrid: false
        },
        height: "245px"
    };

    var responsiveOptions2 = [
        ['screen and (max-width: 640px)', {
            seriesBarDistance: 5,
            axisX: {
                labelInterpolationFnc: function(value) {
                    return value[0];
                }
            }
        }]
    ];

    var chartActivity2 = Chartist.Bar('#chartActivity2', data2, options2, responsiveOptions2);

}

function showNotification(from, align) {
    color = Math.floor((Math.random() * 4) + 1);

    $.notify({
        icon: "nc-icon nc-app",
        message: "Welcome to <b>Light Bootstrap Dashboard</b> - a beautiful freebie for every web developer."

    }, {
        type: type[color],
        timer: 8000,
        placement: {
            from: from,
            align: align
        }
    });
}



function initWizard () {
    // Code for the Validator
    var $validator = $('#wizardForm').validate({
        rules: {
            // email: {
            //     required: true,
            //     email: true,
            //     minlength: 5
            // },
            // first_name: {
            //     required: false,
            //     minlength: 5
            // },
            // last_name: {
            //     required: false,
            //     minlength: 5
            // },
            // website: {
            //     required: true,
            //     minlength: 5,
            //     url: true
            // },
            // framework: {
            //     required: false,
            //     minlength: 4
            // },
            // cities: {
            //     required: true
            // },
            // price: {
            //     number: true
            // }
        },
        highlight: function(element) {
            $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
        },
        success: function(element) {
            $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
        },

        errorPlacement: function(error, element) {
            $(element).parent('div').addClass('has-danger');
         }
    });

    // Wizard Initialization
    $('#CadastroPropostaPF').bootstrapWizard({
        'tabClass': 'nav nav-pills',
        'nextSelector': '.btn-next',
        'previousSelector': '.btn-previous',

        onNext: function (tab, navigation, index) {

            if (index == 1) {
                // Make sure we entered the name
                if (!$('#PropostaCliente_0__Cliente_Nome').val()) {
                    swal({
                        title: "Erro",
                        text: "Preencha o Titular do plano",
                        type: "warning",
                        confirmButtonColor: "#df4a4b"
                    });
                    $('#PropostaCliente_0__Cliente_Nome').focus();
                    return false;
                }
                verificarPlanoExistente();
                atualizarValor();
            }
            if (index == 2) {
                if (!$("#regEnfermaria").is(":checked") && !$("#regEnfermaria40").is(":checked") && !$("#nacionalEnf").is(":checked")
                    && !$("#regApt").is(":checked") && !$("#Reg40Apt").is(":checked") && !$("#NacionalApt").is(":checked"))
                {
                    swal({
                        title: "Erro",
                        text: "Selecione o Plano",
                        type: "warning",
                        confirmButtonColor: "#df4a4b"
                    });
                    return false;
                }
                atualizarValor();
            }
            if (index == 3) {
                if ($("#Resp1").is(":checked") && (!$('#ResponsavelFinancId').val() || !$('#Cliente_Nome').val())) {
                    swal({
                        title: "Erro",
                        text: "Selecione o Respons. Financeiro",
                        type: "warning",
                        confirmButtonColor: "#df4a4b"
                    });
                        return false;
                }
            }
            //var $valid = $('#wizardForm').valid();
            //if (!$valid) {
            //    $validator.focusInvalid();
            //    return false;
            //}
            return true;
        },

        onPrevious: function (tab, navigation, index) {
            if (index == 0) {
                $("#valorTotal").text("");
                //$(".tipoPlano").prop("checked", false);

                var originalAttributes = $('#somesegmentDiv').attr('style');
                $("#segment").attr('style', originalAttributes);
            }
        },

        //onFinish: function (tab, navigation, index) {
        //    var fi = document.getElementById('input-pd');
        //    if (fi.files.length > 0) {
        //        var totalsize = 0;
        //        for (var i = 0; i <= fi.files.length - 1; i++) {

        //            var fname = fi.files.item(i).name;
        //            var fsize = fi.files.item(i).size;
        //            totalsize += fsize;
        //        }
        //        if (totalsize > 10000000) {
        //            swal({
        //                title: "Erro",
        //                text: "Tamanho máximo de upload excedido.  O tamanho máximo do(s) arquivo(s) é 10 MB</br>Remova ou diminua os arquivos até o limite máximo permitido.",
        //                type: "warning",
        //                confirmButtonColor: "#df4a4b"
        //            });
        //            return false;
        //        }
        //    }
        //},

        onInit: function(tab, navigation, index) {
            //check number of tabs and fill the entire row
            var $total = navigation.find('li').length;
            var $wizard = navigation.closest('.card-wizard');

            $first_li = navigation.find('li:first-child a').html();
            $moving_div = $('<div class="moving-tab">' + $first_li + '</div>');
            $('.card-wizard .wizard-navigation').append($moving_div);

            refreshAnimation($wizard, index);

            $('.moving-tab').css('transition', 'transform 0s');
        },

        onTabClick: function(tab, navigation, index) {
            // var $valid = $('#wizardForm').valid();

            // if (!$valid) {
            //     return false;
            // } else {
            //     return true;
            // }
            // Disable the posibility to click on tabs
            return false;
        },

        onTabShow: function(tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;

            var $wizard = navigation.closest('.card-wizard');

            // If it's the last tab then hide the last button and show the finish instead
            if ($current >= $total) {
                $($wizard).find('.btn-next').hide();
                $($wizard).find('.btn-finish').show();
            } else {
                $($wizard).find('.btn-next').show();
                $($wizard).find('.btn-finish').hide();
            }

            button_text = navigation.find('li:nth-child(' + $current + ') a').html();

            setTimeout(function() {
                $('.moving-tab').text(button_text);
            }, 150);

            var checkbox = $('.footer-checkbox');
            

            if (!index == 0) {
                $(checkbox).css({
                    'opacity': '0',
                    'visibility': 'hidden',
                    'position': 'absolute'
                });
            } else {
                $(checkbox).css({
                    'opacity': '1',
                    'visibility': 'visible'
                });
            }

            refreshAnimation($wizard, index);
        }
    });

    $('#CadastroPropostaPJ').bootstrapWizard({
        'tabClass': 'nav nav-pills',
        'nextSelector': '.btn-next',
        'previousSelector': '.btn-previous',

        onNext: function (tab, navigation, index) {

            if (index == 1) {
                // Make sure we entered the name
                if (!$('#PropostaCliente_0__Cliente_Nome').val()) {
                    swal({
                        title: "Erro",
                        text: "Preencha o Titular do plano",
                        type: "warning",
                        confirmButtonColor: "#df4a4b"
                    });
                    $('#PropostaCliente_0__Cliente_Nome').focus();
                    return false;
                }
                verificarPlanoExistente();
            }
            if (index == 2) {
                if (!$("#regEnfermaria").is(":checked") && !$("#regEnfermaria40").is(":checked") && !$("#nacionalEnf").is(":checked")
                    && !$("#regApt").is(":checked") && !$("#Reg40Apt").is(":checked") && !$("#NacionalApt").is(":checked")) {
                    swal({
                        title: "Erro",
                        text: "Selecione o Plano",
                        type: "warning",
                        confirmButtonColor: "#df4a4b"
                    });
                    return false;
                }
            }


            //var $valid = $('#wizardForm').valid();
            //if (!$valid) {
            //    $validator.focusInvalid();
            //    return false;
            //}
            return true;
        },

        onPrevious: function (tab, navigation, index) {
            if (index == 0) {
                //$(".tipoPlano").prop("checked", false);

                var originalAttributes = $('#somesegmentDiv').attr('style');
                $("#segment").attr('style', originalAttributes);
            }
        },

        onInit: function (tab, navigation, index) {
            //check number of tabs and fill the entire row
            var $total = navigation.find('li').length;
            var $wizard = navigation.closest('.card-wizard');

            $first_li = navigation.find('li:first-child a').html();
            $moving_div = $('<div class="moving-tab">' + $first_li + '</div>');
            $('.card-wizard .wizard-navigation').append($moving_div);

            refreshAnimation($wizard, index);

            $('.moving-tab').css('transition', 'transform 0s');
        },

        onTabClick: function (tab, navigation, index) {
            // var $valid = $('#wizardForm').valid();

            // if (!$valid) {
            //     return false;
            // } else {
            //     return true;
            // }
            // Disable the posibility to click on tabs
            return false;
        },

        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;

            var $wizard = navigation.closest('.card-wizard');

            // If it's the last tab then hide the last button and show the finish instead
            if ($current >= $total) {
                $($wizard).find('.btn-next').hide();
                $($wizard).find('.btn-finish').show();
            } else {
                $($wizard).find('.btn-next').show();
                $($wizard).find('.btn-finish').hide();
            }

            button_text = navigation.find('li:nth-child(' + $current + ') a').html();

            setTimeout(function () {
                $('.moving-tab').text(button_text);
            }, 150);

            var checkbox = $('.footer-checkbox');


            if (!index == 0) {
                $(checkbox).css({
                    'opacity': '0',
                    'visibility': 'hidden',
                    'position': 'absolute'
                });
            } else {
                $(checkbox).css({
                    'opacity': '1',
                    'visibility': 'visible'
                });
            }

            refreshAnimation($wizard, index);
        }
    });

    // Prepare the preview for profile picture
    $("#wizard-picture").change(function() {
        readURL(this);
    });

    $('[data-toggle="wizard-radio"]').click(function() {
        wizard = $(this).closest('.card-wizard');
        wizard.find('[data-toggle="wizard-radio"]').removeClass('active');
        $(this).addClass('active');
        $(wizard).find('[type="radio"]').removeAttr('checked');
        $(this).find('[type="radio"]').attr('checked', 'true');
    });

    $('[data-toggle="wizard-checkbox"]').click(function() {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            $(this).find('[type="checkbox"]').removeAttr('checked');
        } else {
            $(this).addClass('active');
            $(this).find('[type="checkbox"]').attr('checked', 'true');
        }
    });

    $('.set-full-height').css('height', 'auto');

    $(window).resize(function() {
        $('.card-wizard').each(function() {
            $wizard = $(this);

            index = $wizard.bootstrapWizard('currentIndex');
            refreshAnimation($wizard, index);

            $('.moving-tab').css({
                'transition': 'transform 0s'
            });
        });
    });

    function refreshAnimation($wizard, index) {
        $total = $wizard.find('.nav li').length;
        $li_width = 100 / $total;

        total_steps = $wizard.find('.nav li').length;
        move_distance = $wizard.width() / total_steps;
        index_temp = index;
        vertical_level = 0;

        mobile_device = $(document).width() < 600 && $total > 3;

        if (mobile_device) {
            move_distance = $wizard.width() / 2;
            index_temp = index % 2;
            $li_width = 50;
        }

        $wizard.find('.nav li').css('width', $li_width + '%');

        step_width = move_distance;
        move_distance = move_distance * index_temp;

        $current = index + 1;

        if ($current == 1 || (mobile_device == true && (index % 2 == 0))) {
            move_distance -= 8;
        } else if ($current == total_steps || (mobile_device == true && (index % 2 == 1))) {
            move_distance += 8;
        }

        if (mobile_device) {
            vertical_level = parseInt(index / 2);
            vertical_level = vertical_level * 38;
        }

        $wizard.find('.moving-tab').css('width', step_width);
        $('.moving-tab').css({
            'transform': 'translate3d(' + move_distance + 'px, ' + vertical_level + 'px, 0)',
            'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

        });
    }
}