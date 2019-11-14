
// A $( document ).ready() block.
$(document).ready(function () {
    console.log("ready!");
    
    $('.closable').click(function() {
        console.log($(this).parent());
        $($(this).parent()).remove();
    });
});

async function removeAlertos() {
    var bloque = $('#alert_placer');
    console.log(bloque.length);

}

function removeMeARow(i) {
    console.log(i);
    $('#selec_elem').val(i);
    console.log($('#selec_elem').val());
    $('form').submit();
}