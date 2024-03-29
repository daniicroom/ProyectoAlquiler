﻿var oTabla = $("#tblDevolucion").DataTable();

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

    LlenaTablaServicio("http://madasolutions-001-site1.etempurl.com/Api/Devolucion", "#tblDevolucion");

});


// Fucion para manipular los datos de las filas
function EditarFila(DatosFila) {
    $("#txtCodigoDevolucion").val(DatosFila.find('td:eq(0)').text());
    $("#txtCodigoAlquiler").val(DatosFila.find('td:eq(1)').text());
    $("#txtFechaDevolucion").val(DatosFila.find('td:eq(3)').text().split('T')[0]);
    $("#txtDocumentoEmpleado").val(DatosFila.find('td:eq(2)').text());
    ConsultarEmpleado();

    let TotalPagar = DatosFila.find('td:eq(4)').text();
    $("#txtTotalPagar").val(FormatoMiles(TotalPagar));
}

// Aquí se realiza la consulta del cliente a traves del documento
function ConsultarEmpleado() {
    let Documento = $("#txtDocumentoEmpleado").val();
    $.ajax({
        type: "GET",
        url: "http://madasolutions-001-site1.etempurl.com/Api/Empleado?Documento=" + Documento,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Empleado) {
            $("#txtNombreEmpleado").val(Empleado.Nombres + " " +
                Empleado.Apellidos);
        },
        error: function (errEmpleados) {
            $("#txtNombreEmpleado").val(errEmpleados.html);
        }
    });
}


function Consultar() {
    let CodigoAlquiler = $("#txtCodigoAlquiler").val();

    $.ajax({
        type: "GET",
        url: "http://madasolutions-001-site1.etempurl.com/api/Devolucion/GetDevolucionByAlquiler?idAlquiler=" + CodigoAlquiler,
        contentType: "application/json",
        data: null,
        dataType: "json",
        async: false,
        success: function (Devolucion) {

            $("#txtCodigoDevolucion").val(Devolucion.Codigo);
            $("#txtCodigoAlquiler").val(Devolucion.CodigoAlquiler);
            $("#txtFechaDevolucion").val(Devolucion.FechaDevolucion.split('T')[0]);
            $("#txtDocumentoEmpleado").val(Devolucion.IDEmpleadoRecibe);

            ConsultarEmpleado();
            
            $("#txtTotalPagar").val(FormatoMiles(Devolucion.TotalPagar));
           
        },
        error: function (errDevolverVehiculo) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errDevolverVehiculo.html);
        }
    });
}


function Procesar(Comando) {

    let Codigo = $("#txtCodigoDevolucion").val();
    CalcularTotalPagar();
    let CodigoAlquiler = $("#txtCodigoAlquiler").val();
    let IDEmpleadoRecibe = $("#txtDocumentoEmpleado").val();
    ConsultarEmpleado();
    let FechaDevolucion = $("#txtFechaDevolucion").val();
    let TotalPagar = $("#txtTotal").val();


    DatosDevolucion = {
        Codigo: Codigo,
        CodigoAlquiler: CodigoAlquiler,
        IDEmpleadoRecibe: IDEmpleadoRecibe,
        FechaDevolucion: FechaDevolucion,
        TotalPagar: TotalPagar,
    }
    $.ajax({
        type: Comando,
        url: "http://madasolutions-001-site1.etempurl.com/Api/Devolucion",
        contentType: "application/json",
        data: JSON.stringify(DatosDevolucion),
        dataType: "json",
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Rpta);
            //Vuelve y presenta la tabla con los cambios realizados
            LlenaTablaServicio("http://madasolutions-001-site1.etempurl.com/Api/Devolucion", "#tblDevolucion");
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
        url: "http://madasolutions-001-site1.etempurl.com/Api/Devolucion?idAlquiler=" + CodigoAlquiler,
        success: function (Rpta) {
            valorDia = Rpta.Precio;
            let now = new Date();
            FechaInicial = new Date(Rpta.FechaInicial);
            var dias = parseInt((now - FechaInicial) / (24 * 3600 * 1000))
            let totalPagar = valorDia * dias;
            $("#txtTotalPagar").val(FormatoMiles(totalPagar));
            $("#txtTotal").val(totalPagar);

        },
        error: function (Error) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(Error);
        }
    });
}







