$(document).ready(function() {

    var result;

    $.ajax({
        // async defaults to True- This means that the result will wait for a return before running anything else.
        async: false,
        // Setting the dataType to JSON is a convenience. It automatically parses it into a JSON object for us.
        dataType: "json",
        // This is the URL we're pulling from. 
        url: "Game/Initialize",

        // This is just our super-simple function that gets called on success.
        // ALL it's doing is setting the result back to that variable we declared before.

        // Normally, in JS, you'd just do whatever it is you actually needed with your drawing/etc, right in the inline function..
        // Or have it call a longer function, that's defined normally (like the one we're in!)
        // But in this case, I wanted to a) illustrate Inline functions.
        //                           and b) make it short  
        success: function(data) {
            result = JSON.parse(data);
            console.log(result);
        }
    });

    var outputDiv = "<div class=\"gameoutput\">" + result['OutputText'] + "</div>";

    var screenOptions = result['ScreenOptions'];

    console.log(screenOptions[0]);

    var screenOptionsDiv = "<div class=\"screenoptions\">";

    for (i = 0; i < screenOptions.length; i++) {
        screenOptionsDiv += "<span>" + screenOptions[i].Description + "</span>";
    }

    screenOptionsDiv += "</div>";

    console.log(outputDiv);

    if (result) {
        $(".output").html(outputDiv);
        $(".output").append(screenOptionsDiv);
    }
    

    $('.input').submit(function () {
        alert('Handler for .submit() called.');
        return false;
    });


});