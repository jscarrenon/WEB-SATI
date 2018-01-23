$(document).ready(function () {
    var title = $(this).attr('title').toUpperCase();
    ActiveItemsMenu(title);
});

function ActiveItemsMenu(items)
{
    $("a[name='" + items + "']").addClass("active");
}