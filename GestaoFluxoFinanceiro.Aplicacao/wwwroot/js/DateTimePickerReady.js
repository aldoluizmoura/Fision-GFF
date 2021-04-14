$(function () {
    $.datetimepicker.setDateFormatter('moment');
    $("#datetimefield").datetimepicker({
        format: 'MM/DD/YYYY hh:mm A',
        language: "pt-BR"    
    });
});