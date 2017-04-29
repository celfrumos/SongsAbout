// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX

import $ from 'jquery'

$(document).ready(function () {
    $("input[data-autocomplete-source]").each(function () {
        var target = $(this);
        target.autocomplete({
            source: target.attr("data-autocomplete-source")
        });
    });
});

