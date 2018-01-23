$(document).ready(function () {
    $("#selectFecha").change(function () {
        MuestraTablaContratosAGenerar();
    });

    MuestraTablaContratosAGenerar();

    $("#frmGenContratos").submit(function () {

        var data = { 'fecha': $("#selectFecha").val() }
        var nFilas = $("#example tr").length;

        if (nFilas > 1)
        {
            $.ajax({
                method: "POST",
                dataType: "html",
                type: "html",
                url: $(this).attr('action'),
                data: data,
                success: function (response) {
                    if (JSON.parse(response) != '') {
                        window.open(JSON.parse(response), '_self ');
                        MuestraTablaContratosAGenerar();
                    }
                },
                error: function (jsHXR, textstatus, error) {
                    alert("Error : " + error);
                }
            });
        } else
        {
            alert("No Existen Contratos a generar en la fecha Indicada.");
        }
       

        return false;
    });
});


function MuestraTablaContratosAGenerar()
{
    var fecha = $("#selectFecha").val();
    var data = {"fecha" : fecha};
    if(fecha != null)
    {
        $.ajax({
            url: 'BodyTablaContratos',
            method: "POST",
            dataType: "html",
            type: "html",
            data: data,
            success: function (result) {
                $("#bodytblContratos").html(result);
            }
        });
    }
}



