//retorno de feedback com modal(processando...)
var processing;
processing = processing || (function () {
    var pleaseWaitDiv = $('<div class="modal" data-backdrop="static" data-keyboard="false"><div class="modal-dialog"><div class="modal-content"><div class="modal-header"><h2 class="modal-title">Processando...</h2></div><div class="modal-body"><div class="progress progress-striped active"><div class="progress-bar" style="width: 100%"></div></div></div></div></div></div>');
    return {
        showPleaseWait: function () {
            pleaseWaitDiv.modal();
        },
        hidePleaseWait: function () {
            pleaseWaitDiv.modal('hide');
        },

    };
})();

//limpar o form
function done() {
    $('form').resetForm();
}

//Deixar o menu clicado ativo
$(document).ready(function () {

    var url = window.location;
    //$('ul.nav a[href="' + url + '"]').parent().addClass('active');
    $('ul.nav a').filter(function () {
        return this.href == url;
    }).parent().addClass('active');

    $('.alert-danger, .alert-success').fadeTo('slow', 1);
    $('.alert-danger, .alert-success').fadeTo(400, 0.5);
    $('.alert-danger, .alert-success').fadeTo(200, 1);
    $('.alert-danger, .alert-success').delay(4000).slideToggle('slow');

    $('[data-toggle="tooltip"]').tooltip();

    $('.fadeIndSlow').fadeIn('slow');
});

function selectIcon() {
    var valorCombo = $('#Icon').val();
    $('#iconSelected').removeClass();
    $('#iconSelected').addClass('glyphicon ' + valorCombo);
}

function showMessage(title, message, type) {
    var icon = null;
    switch (type) {
        case 'info':
            icon = 'glyphicon glyphicon-info-sign';
            break;
        case 'success':
            icon = 'glyphicon glyphicon-ok-sign';
            break;
        case 'danger':
            icon = 'glyphicon glyphicon-remove-sign';
            break;
        case 'warning':
            icon = 'glyphicon glyphicon-exclamation-sign';
            break;
        default: icon = 'glyphicon glyphicon-info-sign';
    }
    $.growl({
        title: title,
        icon: icon,
        type: type,
        message: message,
        position: {
            from: "top",
            align: "right"
        },
        template: {
            title_divider: '<hr class="separator" />'
        }
    });
}