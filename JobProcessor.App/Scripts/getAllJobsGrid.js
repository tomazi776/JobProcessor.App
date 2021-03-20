$(document).ready(function () {
    //$('#title').hide().fadeIn(500);

    $('.highlitable').on('mouseover', function () {

        var rowToHighlight = $(this);
        rowToHighlight.children().css('background-color', '#F5F5F5');
    })

    $('.highlitable').on('mouseout', function () {
        var rowToHighlight = $(this);
        rowToHighlight.children().css('background-color', 'white');
    })
});