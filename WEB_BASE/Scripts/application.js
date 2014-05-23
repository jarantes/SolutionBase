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

$(function() {
    
})