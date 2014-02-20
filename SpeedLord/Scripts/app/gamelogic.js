$(document).ready(function () {

    var result;

    $.ajax({
        // async defaults to True- This means that the result will wait for a return before running anything else.
        async: false,
        // Setting the dataType to JSON is a convenience. It automatically parses it into a JSON object for us.
        dataType: "json",
        // This is the URL we're pulling from. 
        url: "/game/Initialize",

        // This is just our super-simple function that gets called on success.
        success: function (data) {
            result = JSON.parse(data);
            console.log(result);
            
            appendResults(result);
        }
    });




    $('.input').submit(function () {

        //find the URL based on the command key
        var inputValue = $('#gameInput').val();
        inputValue = inputValue.toUpperCase();

        var searchResults = $(".screenoptions").find("span[commandKey='" + inputValue + "']");

        var postUrl = searchResults.attr("postUrl");


        $.ajax({
            // async defaults to True- This means that the result will wait for a return before running anything else.
            async: false,
            // Setting the dataType to JSON is a convenience. It automatically parses it into a JSON object for us.
            dataType: "json",
            // This is the URL we're pulling from. 
            url: postUrl,

            // This is just our super-simple function that gets called on success.
            // ALL it's doing is setting the result back to that variable we declared before.

            success: function (data) {
                result = JSON.parse(data);
                console.log(result);

                appendResults(result);
            }
        });

        return false;
    });
});

//TODO: replace this with a templating engine. Backbone?
function appendResults(result) {
    if (!result) {
        return;
    }
    var outputDiv = "<div class=\"gameoutput\">" + result['OutputText'] + "</div>";
    var screenOptions = result['ScreenOptions'];

    console.log(screenOptions[0]);

    var screenOptionsDiv = "<div class=\"screenoptions\">";

    for (i = 0; i < screenOptions.length; i++) {
        screenOptionsDiv += "<span commandKey='" + screenOptions[i].CommandKey + "' postUrl ='" + screenOptions[i].PostUrl + "' >" + screenOptions[i].Description + "</span>";
    }

    screenOptionsDiv += "</div>";
        
    $(".output").html(outputDiv);
    $(".output").append(screenOptionsDiv);
    $("#gameInput").text = "";

}