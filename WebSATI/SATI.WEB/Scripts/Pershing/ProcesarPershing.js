$(document).ready(function () {
    $(".instrumento").change(function () {
        ActualizaVista();
    });

    $(".check-full-p").change(function () {
        if ($(this).is(':checked')) {
            $(".check-full").prop('checked', 'checked');
        }else
        {
            $(".check-full").prop('checked', false);
        }
    });

    $(".check-full").change(function () {
        var contadorRadioCheck = 0;
        var contadorRadio = 0
        $(".check-full").each(function () {
            if ($(this).is(":checked"))
                contadorRadioCheck++;
        });
        $(".check-full").each(function () {          
            contadorRadio++;
        });

        if (contadorRadioCheck == contadorRadio)
        {          
            if (contadorRadioCheck > 0)
            {
                $(".check-full-p").prop('indeterminate', false)
                $(".check-full-p").prop('checked', true);
            }       
        } else
        {
            if (contadorRadioCheck > 0) {
                $(".check-full-p").prop('indeterminate', true)
            }else
            {
                $(".check-full-p").prop('indeterminate', false)
                $(".check-full-p").prop('checked', false);
            }
        }
    });

    $("#frmCargaPershing").submit(function () {
        alert("Se proceden a cargar los pershing seleccionados");
        $.ajax({
            method: "POST",
            dataType: "html",
            type: "html",
            url: $(this).attr('action'),
            data: $(this).serialize(),
            success: function(response)
            {                             
                $("#modal-container").html(response);
                $('#Mresponce').modal('show');
            },
            error: function (jsHXR, textstatus, error) {
                alert("Error : "+ error);
            }
        });
        return false;
    });
   
    $("#OmitidosPershing").click(function () {
        if ($(this).val() > 0)
        {
            $('#pruebaModal').modal('show');
        }     
    });

});

function ActualizaVista()
{
    var data = { instrumento: $('input:radio[name=instrumento]:checked').val(), numFolio: $("#numFolio").val() }
    $.ajax({
        contentType: "application/json",
        dataType: "html",
        type: "html",
        method: "POST",
        data: JSON.stringify(data),
        url: $("#instrumentoCheck").attr('action'),
        success: function (result) {
            $("#View-result-pershing").html(result);
        }
    });
}