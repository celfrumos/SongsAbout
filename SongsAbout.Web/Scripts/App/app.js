

$(document).ready(function () {
    $("input[data-autocomplete-source]").each(function () {
        var target = $(this);
        target.autocomplete({
            source: target.attr("data_autocomplete_source"),
        });
    });


});