var PartialLink = function() {
    // link element which responsible for partial view render
    var partialEl = $("[data-partial]");
    partialEl.on("click", null, function (e) {
        e.preventDefault();

        var currentPartialEl = $(e.target);
        var partialLink = currentPartialEl.attr("href");
        var partialTarget = currentPartialEl.data("target");

        var params = currentPartialEl.data("json-params");
        if (!params) {
            var paramsEl = currentPartialEl.data("json-elements");
            for (var i = 0; i < paramsEl.length; i++) {
                
            }
        }

        $.post(partialLink, params, function (data) {
            if (data.Status <= 0) {
                console.error(data.Message);
                $(partialTarget).html("<p style='color: red;'>" + data.Message + "</p>");
                return;
            }

            console.log(data);
            $(partialTarget).html(data.Content);
        });
    });
};

var MultiSubmit = function() {
    // button for multiple submit in one form
    var multiSubmit = $("[data-multisubmit]");
    multiSubmit.on("click", null, function(e) {

        var currentMultiSubmit = $(e.target);
        var currentForm = currentMultiSubmit.parents("form");
        currentForm.attr("action", currentMultiSubmit.data("action"));
        currentForm.attr("method", currentMultiSubmit.data("method"));

        currentForm.submit();

        return false;
    });
};