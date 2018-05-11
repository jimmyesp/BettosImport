Number.prototype.formatMoney = function (c, d, t) {
    var n = this, c = isNaN(c = Math.abs(c)) ? 2 : c, d = d == undefined ? "," : d, t = t == undefined ? "." : t, s = n < 0 ? "-" : "", i = parseInt(n = Math.abs(+n || 0).toFixed(c)) + "", j = (j = i.length) > 3 ? j % 3 : 0;
    return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
};

$(document).ajaxSend(function () {
    if (!pageBlocked) {
        $.blockUI({
            message: 'Procesando...  <br /> <img src="../img/loading.gif" />',
            theme: false,
            baseZ: 2000,
            css: {
                border: 'none',
                padding: '20px',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: .6,
                color: '#000',
                'font-size': '12pt',
                'font-weight': 'bold'
            }
        });
    }
}).ajaxStop(function () {
    jQuery.unblockUI();
    pageBlocked = false;
});

$.ajaxSetup({
    cache: false
});

var pageBlocked = false;
var Accion = '';
var bettosimport = bettosimport || {};

bettosimport.util = {
    ajaxCallback: function (url, args, callback) {
        $.ajax({
            type: "post",
            url: url,
            data: args,
            success: function (response) {
                callback(response);
            },
            failure: function (response) {
                callback(response);
            }
        });
    },
    showMessage: function (message, alertType) {
        $('#message').append('<div id="alertdiv" class="alert ' + alertType + '"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')

        setTimeout(function () {
            $("#alertdiv").remove();
        }, 5000);
    },
    configDatepickerEs: function () {
        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: 'Anterior',
            nextText: 'Siguiente',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sem',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            changeMonth: true,
            changeYear: true,
            showAnim: 'drop',
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);
    },
    openModal: function (selectorDiv, selectorFrame, urlFrame, titulo) {
        $('#' + selectorFrame).attr("src", urlFrame);
        $('#' + selectorDiv).dialog({
            title: titulo,
            modal: true,
            height: '500',
            width: '550',
            close: function () {
                $('#' + selectorFrame).attr("src", "");
                $('#' + selectorDiv).dialog('destroy');
            }
        });
    },
    openModalCustomSize: function (selectorDiv, selectorFrame, urlFrame, titulo, alto, ancho) {
        $('#' + selectorFrame).attr("src", urlFrame);
        $('#' + selectorDiv).dialog({
            title: titulo,
            modal: true,
            height: alto,
            width: ancho,
            close: function () {
                $('#' + selectorFrame).attr("src", "");
                $('#' + selectorDiv).dialog('destroy');
            }
        });
    },
    alert: function (msg) {
        $.blockUI({
            theme: true,
            title: 'Bettos Import S.A.C',
            message: '<p>' + msg + '</p>',
            timeout: 1000
        });
    },
    alertURL: function (msg, url) {
        $.blockUI({
            theme: false,
            title: 'Bettos Import S.A.C',
            message: '<p>' + msg + '</p>',
            timeout: 1000,
            onUnblock: function () {
                window.location = url;
            }
        });
        
    },
    confirmar(msg, uniqueID) {
        $("#spanConfirmacion").html(msg);
         
        $("#confirmacion").dialog({
            title: 'Bettos Import SAC',
            modal: true,
            buttons: {
                "Eliminar": function () { __doPostBack(uniqueID, ''); $(this).dialog("close"); },
                "Cancel": function () { $(this).dialog("close"); }
            }
        });
         
        return false;
    },
    openModalConfirmacion: function (mensaje, callback) {
        $('#message').html(mensaje);
        $('#message').dialog({
            title: 'Confirmación',
            modal: true,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close").hide();
            },
            close: function () {
                $('#message').html('');
                $('#message').dialog('destroy');
            },
            buttons: {
                "Aceptar": function () {
                    if (typeof (callback) != typeof (undefined))
                        callback();

                    $('#message').html('');
                    $('#message').dialog('destroy');
                },
                "Cancelar": function () {
                    $('#message').html('');
                    $('#message').dialog('destroy');
                }
            }
        });
    },
    getParameterByName: function (name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    },
    importes: function (selector) {
        var $this = $('#' + selector);
        $this.on('keypress', function (e) {
            if (String.fromCharCode(e.keyCode).match(/[^0-9.]/g)) return false;
        });
    },
    parseJsonDate: function (jsonDate) {
        var dateString = jsonDate.substr(6);
        var currentTime = new Date(parseInt(dateString));
        var month = currentTime.getMonth() + 1;
        var day = currentTime.getDate();
        var year = currentTime.getFullYear();
        var date = day + "/" + month + "/" + year;
        return date;
    }
};



