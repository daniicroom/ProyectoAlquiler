var oTabla = $("#tblAlquiler").DataTable();

$(document).ready(function () {
    // Obtiene la fecha del sistema y la presenta en el txt
    let now = new Date();
    $("#txtFechaInicio").val(now.toISOString().split('T')[0]);  

    //Registrar los botones para responder al evento click
    $("#btnBuscar").click(function () {
        ConsultarCliente();
    });

    $("#btnRegistrar").click(function () {
        Registrar('POST');
    });

    $("#btnActualizar").click(function () {
        Actualizar('PUT');
    })
    $("#btnConsultar").click(function () {
        Consultar();
    });
    $("#btnCancelar").click(function () {
        Cancelar();
    });

    $("#btnEliminar").click(function () {
        Eliminar('DELETE');
    });

    //Lena el combo de empleados
    LlenarComboEmpleado();
    //Lena el combo de vehiculos
    LlenarComboVehiculo();


    //Prepara la edición de la tabla
    $('#tblAlquiler tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            EditarFila($(this).closest('tr'));
        }
    });

    LlenarTablaAlquiler();
});

function LlenarComboEmpleado() {
    LlenarComboServicio("http://localhost:62556/Api/Empleado", "#cboEmpleado", "", false);
}

function LlenarComboVehiculo() {
    LlenarComboServicio("http://localhost:62556/Api/Vehiculo", "#cboVehiculo", "", false);
}

function LlenarTablaAlquiler() {
    LlenaTablaServicio("http://localhost:62556/Api/Alquiler", "#tblAlquiler");
}


// Aquí se realiza la consulta del cliente a traves del documento
function ConsultarCliente() {
    let Documento = $("#txtDocumentoCliente").val();
    $.ajax({
        type: "GET",
        url: "http://localhost:62556/Api/Cliente?Documento=" + Documento,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Cliente) {
            $("#txtNombreCliente").val(Cliente.Nombres + " " +
                Cliente.Apellidos);
        },
        error: function (errCliente) {
            $("#txtNombreCliente").val(errCliente);
        }
    });
}



/*
function ActualizarBotones(valor) {
    if (valor) {
        $("#btnRegistrar").show();
        $("#btnActualizar").show();
        $("#btnEliminar").show();
        $("#btnConsultar").show();
        $("#btnLimpiar").hide();
    }
    else {
        $("#btnRegistrar").hide();
        $("#btnActualizar").hide();
        $("#btnEliminar").hide();
        $("#btnConsultar").hide();
        $("#btnLimpiar").show();

    }
}


function Eliminar() {
    //Borra una fila de la tabla
    oTabla.row('.selected').remove().draw(false);
    ActualizarBotones(true);

}

function Limpiar() {
    oTabla.clear().draw(false);

    $("#txtDocumentoCliente").val("");
    $("#txtNombreCliente").val("");

    /*$("#txtCodigoAlquiler").val(0);
    $("#txtDocumentoCliente").val("");
    $("#txtNombreCliente").val("");
    $("#cboEmpleado").val("");
    $("#cboVehiculo").val("");
    $("#txtEstado").val("");
    $("#txtFechaInicio").val("");
    $("#txtFechaFin").val("");
}

function Cancelar() {
    
    ActualizarBotones(true);
}

function EditarFila(DatosTabla) {
    
    ActualizarBotones(false);

    $("#txtCodigoAlquiler").val(DatosTabla.find('td:eq(0)').text());
    $("#txtDocumentoCliente").val(DatosTabla.find('td:eq(1)').text());
    ConsultarCliente();

    $("#cboEmpleado").val(DatosTabla.find('td:eq(2)').text());
    $("#cboVehiculo").val(DatosTabla.find('td:eq(3)').text());
    $("#txtEstado").val(DatosTabla.find('td:eq(4)').text());
    $("#txtFechaInicio").val(DatosTabla.find('td:eq(5)').text());
    $("#txtFechaFin").val(DatosTabla.find('td:eq(6)').text());
    
}


// Se graba el alquiler
function Registrar() {
    //Capturamos los datos del cliente y el empleado
    let DocumentoCliente = $("#txtDocumento").val();
    let IdEmpleado = $("#cboEmpleado").val();
    //Capturar los datos de la tabla
    var fieldNames = [], tblAlquiler = [];
    oTabla.settings().columns()[0].forEach(function (index) {
        fieldNames.push($(oTabla.column(index).header()).text().replace(/ /g, ""));
    });
    oTabla.rows().data().toArray().forEach(function (row) {
        var item = {};
        row.forEach(function (content, index) {
            item[fieldNames[index]] = content;
        });
        tblAlquiler.push(item);
    });

    let DatosAlquiler = {
        tblAlquiler
    }
    $.ajax({
        type: "POST",
        url: "http://localhost:62556/Api/Alquiler",
        contentType: "application/json",
        data: JSON.stringify(DatosAlquiler),
        dataType: "json",
        success: function (Rpta) {
            $("#txtCodigoAlquiler").val(Rpta);
            Limpiar();
        },
        error: function (Error) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(Error);
        }
    });
}
*/

function Consultar() {
    let CedulaCliente = $("#txtDocumentoCliente").val();

    $.ajax({
        type: "GET",
        url: "http://localhost:62556/Api/Alquiler?CedulaCliente=" + DocumentoCliente,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Alquiler) {

            $("#txtCodigoAlquiler").val(Alquiler.Codigo);
            $("#txtDocumentoCliente").val(Alquiler.DocumentoCliente);
            ConsultarCliente();
            // DUDAS AQUI
            $("#cboEmpleado").val(Alquiler.IdEmpleado);
            $("#cboVehiculo").val();
            $("#txtEstado").val(Alquiler.Estado);
            $("#txtFechaInicio").val(Alquiler.FechaInicio);
            $("#txtFechaFin").val(Alquiler.FechaFin);


        },
        error: function (errAlquiler) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errAlquiler.html);
        }
    });
}


function Procesar(Comando) {

    let Codigo = $("#txtCodigoAlquiler").val();
    let DocumentoCliente = $("#txtDocumentoCliente").val();
    ConsultarCliente();
    let Empleado = $("#cboEmpleado").val();
    let Vehiculo = $("#cboVehiculo").val();
    let Estado = $("#txtEstado").val();
    let FechaInicio = $("#txtFechaInicio").val();
    let FechaFin = $("#txtFechaFin").val();

    

    DatosAlquiler = {
        Codigo: Codigo,
        CedulaCliente: DocumentoCliente,
        IDEmpleado: 1,
        PlacaVehiculo: GHJH32,
        EstadoAlquiler: Estado,
        FechaInicio: FechaInicio,
        FechaFin: FechaFin,

    }
    $.ajax({
        type: Comando,
        url: "http://localhost:62556/Api/Alquiler",
        contentType: "application/json",
        data: JSON.stringify(DatosAlquiler),
        dataType: "json",
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Rpta);
            //Vuelve y presenta la tabla con los cambios realizados
            LlenarTablaAlquiler();
        },
        error: function (errAlquiler) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errAlquiler.html);
        }
    });
}


