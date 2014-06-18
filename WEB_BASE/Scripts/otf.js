$(function () {
    //***************** FORM SEARCH ********************
    var ajaxFormSearchSubmit = function () {

        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),
            beforeSend: function () {
                processing.showPleaseWait();
            },
            complete: function () {
                processing.hidePleaseWait();
            }
        }

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf-target"));
            $target.replaceWith('<div id="listProducts">' +data + '</div>');
        });
        return false;
    };

    //*********** SUBMIT FORM AUTOCOMPLETE **************
    var submitAutocompleteform = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);
        var $form = $input.parents("form:first");
        //$form.attr("action", "/Products/Index");
        $form.submit();
    };

    //*********** AUTOCOMPLETE **************
    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-otf-autocomplete"),
            autoFocus: "true",
            select: submitAutocompleteform
        };

        $input.autocomplete(options);
    };

    //*********** PAGED LIST **************
    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-otf-target");
            $(target).replaceWith(data);
        });
        return false;
    };

    $("form[id='formSearch']").submit(ajaxFormSearchSubmit);
    $("input[data-otf-autocomplete]").each(createAutocomplete);
    $(".main-content").on("click", ".pagedList a[href]", getPage);

});