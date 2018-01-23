$(document).ready(function () {
    $("#frm-procesar").submit(function () {
            $.ajax({
            dataType: "html",
            type: "html",
            method: "POST",
            data: $(this).serialize(),
            url: $(this).attr('action'),
            success: function (result) {
                $('#pruebaModal').modal('hide');
                $("#Procesador-excel").hide();
                $("#View-result-pershing").show();
                $("#View-result-pershing").html(result);
            }
        });

        return false;
    });
});