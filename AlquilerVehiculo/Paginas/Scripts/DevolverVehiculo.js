var oTabla = $("#tblDevolucion").DataTable();

$(document).ready(function () {
    // Obtiene la fecha del sistema y la presenta en el txt
    let now = new Date();
    $("#txtFechaDevolucion").val(now.toISOString().split('T')[0]);

    //Registrar los botones para responder al evento click
    $("#btnBuscar").click(function () {
        ConsultarEmpleado();
    });

    $("#btnRegistrar").click(function () {
        Procesar('POST');
    });

    $("#btnActualizar").click(function () {
        Procesar('PUT');
    })
    $("#btnEliminar").click(function () {
        Procesar('DELETE');
    });

    $("#btnConsultar").click(function () {
        Consultar();
    });

    //Prepara la edición de la tabla
    $('#tblDevolucion tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            EditarFila($(this).closest('tr'));
        }
    });

    LlenarTablaDevolucion("http://localhost:62556/Api/Devolucion", "#tblDevolucion");

});


// Aquí se realiza la consulta del cliente a traves del documento
function ConsultarEmpleado() {
    let Documento = $("#txtDocumentoEmpleado").val();
    $.ajax({
        type: "GET",
        url: "http://localhost:62556/Api/Empleado?Documento=" + Documento,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Empleado) {
            $("#txtNombreEmpleado").val(Empleado.Nombres + " " +
                Empleado.Apellidos);
        },
        error: function (errEmpleado) {
            $("#txtNombreEmpleado").val(errEmpleados);
        }
    });
}


function Consultar() {
    let CodigoAlquiler = $("#txtCodigoAlquiler").val();

    $.ajax({
        type: "GET",
        url: "http://localhost:62556/Api/Devolucion?CodigoAlquiler=" + CodigoAlquiler,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Devolucion) {

            $("#txtCodigoDevolucion").val(Devolucion.Codigo);
            $("#txtCodigoAlquiler").val(Devolucion.CodigoAlquiler);
            $("#txtFechaDevolucion").val(Devolucion.FechaDevolucion);
            $("#txtDocumentoEmpleado").val(Devolucion.Documento);

            ConsultarEmpleado();

            $("#txtNombreEmpleado").val(Devolucion.IDEmpleadoRecibe);
            $("#txtTotalPagar").val(Devolucion.TotalPagar);

        },
        error: function (errDevolucion) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errDevolucion.html);
        }
    });
}


function Procesar(Comando) {

    let Codigo = $("#txtCodigoDevolucion").val();
    let CodigoAlquiler = $("#txtCodigoAlquiler").val();

    ConsultarEmpleado();

    let IDEmpleadoRecibe = $("#cboEmpleado").val();
    let FechaDevolucion = $("#txtFechaDevolucion").val();
    let TotalPagar = $("#txtTotalPagar").val();


    DatosDevolucion = {
        Codigo: Codigo,
        CodigoAlquiler: CodigoAlquiler,
        IDEmpleadoRecibe: Empleado,
        FechaDevolucion: FechaDevolucion,
        TotalPagar: TotalPagar,
 

    }
    $.ajax({
        type: Comando,
        url: "http://localhost:62556/Api/Devolucion",
        contentType: "application/json",
        data: JSON.stringify(DatosDevolucion),
        dataType: "json",
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Rpta);
            //Vuelve y presenta la tabla con los cambios realizados
            LlenarTablaDevolucion("http://localhost:62556/Api/Devolucion", "#tblDevolucion");
        },
        error: function (errDevolucion) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errDevolucion.html);
        }
    });
}


function CalcularTotalPagar() {
    let CodigoAlquiler = $("#txtCodigoAlquiler").val();
    $.ajax({
        type: "GET",
        url: "http://localhost:62556/Api/Devolucion?idAlquiler=" + CodigoAlquiler,
        success: function (Rpta) {
            valorDia = Rpta.Precio;
            let now = new Date();
            FechaInicial = new Date(Rpta.FechaInicial);
            var dias = parseInt((now - FechaInicial) / (24 * 3600 * 1000))
            $("#txtTotalPagar").val(valorDia * dias);
        },
        error: function (Error) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(Error);
        }
    });
}




function Eliminar() {
    //Borra una fila de la tabla
    let DatosFila = oTabla.row('.selected').data();

    oTabla.row('.selected').remove().draw(false);
    //MostrarActualizar(false);
}






