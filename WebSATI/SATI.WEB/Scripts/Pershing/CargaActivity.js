

$(document).ready(function () {
    $("#file").change(function () {
        var ext = $(this).val().split('.')[1];

        if(ext == "xls" || ext == "xlsx")
        {
            $("#respuesta").text($(this).val());
            $("#btnProcesar").prop("disabled",false)
        }else
        {
            $("#respuesta").text("Solo se permiten los formatos .xls y .xlsx");
            $("#btnProcesar").prop("disabled", true)
        }

    });

    $("#formulario").submit(function () {
        $("#btnProcesar").hide();
        $("#loading-process").show();

        var form = $(this);

        form.ajaxSubmit({
            dataType: "html",
            method: "POST",
            url: $(this).attr('action'),
            success: function(result)
            {
                $("#modal-container").html(result);
                $('#pruebaModal').modal('show');            
            },
            error: function(jsHXR,textstatus,error)
            {
                alert("Error Inesperado. Verifique que el archivo es el correcto y vuelva a intentarlo");
                alert(error);
            },
            complete: function (data) {
                $("#loading-process").hide();
                $("#btnProcesar").show();
            }
    });

    return false;
    });
});
