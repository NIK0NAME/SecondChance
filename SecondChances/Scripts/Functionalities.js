
// A $( document ).ready() block.
$(document).ready(function () {
    console.log("ready!");
    $('.closable').click(function() {
        console.log($(this).parent());
        $($(this).parent()).remove();
    });
});