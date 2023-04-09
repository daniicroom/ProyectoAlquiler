var oTabla = $("#tblDevolucion").DataTable();

$(document).ready(function () {
    // Obtiene la fecha del sistema y la presenta en el txt
    let now = new Date();
    $("#txtFechaDevolucion").val(now.toISOString().split('T')[0]);   //PENDIENTE LO DE LA HORA

    //Registrar los botones para responder al evento click
    $("#btnBuscar").click(function () {
        ConsultarEmpleado();
    });

    $("#btnRegistrar").click(function () {
        Registrar();
    });

    $("#btnActualizar").click(function () {
        Actualizar();
    })
    $("#btnEliminar").click(function () {
        Eliminar();
    });

    $("#btnConsultar").click(function () {
        Consultar();
    });

});



// Aquí se realiza la consulta del cliente a traves del documento
function ConsultarEmpleado() {
    let Documento = $("#txtDocumento").val();
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
            $("#txtNombreEmpleado").val(errEmpleado);
        }
    });
}









// PENDIENTE
function Eliminar() {
    //Borra una fila de la tabla
    let DatosFila = oTabla.row('.selected').data();

    oTabla.row('.selected').remove().draw(false);
    MostrarActualizar(false);
}

// PENDIENTE
function AgregarItem() {
    //Agrega un ítem a la tabla tblFactura
    let Codigo = $("#txtCodigoDevolucion").val();
    let CodigoAlquiler = $("#txtCodigoAlquiler").val();
    let Empleado = $("#txtNombreEmpleado").val();
    let FechaDevolucion = $("#txtFechaDevolucion").val();
    let TotalPagar = $("#txtTotalPagar").val();

    //Agrega los items a la tabla
    oTabla.row.add([Codigo, CodigoAlquiler, Empleado, FechaDevolucion, TotalPagar]).draw(false);
}


// PENDIENTE
// Se graba el alquiler
function Registrar() {

    var devolucion = {
        Codigo : 0,
        CodigoAlquiler : $("#txtCodigoAlquiler").val(),
        IDEmpleadoRecibe : $("#txtDocumento").val(),
        FechaDevolucion : $("#txtFechaDevolucion").val(),
        TotalPagar : $("#txtTotalPagar").val()
    }
    $.ajax({
        type: "POST",
        url: "http://localhost:62556/Api/Devolucion",
        contentType: "application/json",
        data: JSON.stringify(devolucion),
        dataType: "json",
        success: function (Rpta) {
            $("#txtCodigoDevolucion").val(Rpta);
            //Limpiar();
        },
        error: function (Error) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(Error);
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
