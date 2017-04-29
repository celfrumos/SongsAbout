// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX
"use strict";
var jquery_1 = require("jquery");
jquery_1.default(document).ready(function () {
    jquery_1.default("input[data-autocomplete-source]").each(function () {
        var target = jquery_1.default(this);
        target.autocomplete({
            source: target.attr("data-autocomplete-source")
        });
    });
});
//# sourceMappingURL=custom.js.map