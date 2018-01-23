$(document).ready(function () {
    $("#procesar-libroOper").submit(function () {   
        $.ajax({
            method: "POST",
            dataType: "html",
            type: "html",
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                $("#dowloadFile").attr('href', JSON.parse(response));
                $("#dowloadFile").show();
                window.open(JSON.parse(response), '_bank');
            },
            error: function (jsHXR, textstatus, error) {
                alert("Error : " + error);
            }
        });
        return false;
    });

    $("#procesar-RegRecep").submit(function () {
        $.ajax({
            method: "POST",
            dataType: "html",
            type: "html",
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function (response) {
                $("#dowloadFile-regrep").attr('href', JSON.parse(response));
                $("#dowloadFile-regrep").show();
                window.open(JSON.parse(response), '_bank');
            },
            error: function (jsHXR, textstatus, error) {
                alert("Error : " + error);
            }
        });
        return false;
    });
});