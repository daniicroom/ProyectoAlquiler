var oTabla = $("#tblReserva").DataTable();

$(document).ready(function () {
    // Obtiene la fecha del sistema y la presenta en el txt
    
    //Registrar los botones para responder al evento click
    $("#btnBuscar").click(function () {
        ConsultarCliente();
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
    $('#tblReserva tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            EditarFila($(this).closest('tr'));
        }
    });

    LlenarComboEmpleado();
    LlenarComboTipoVehiculo();

    LlenarTablaReserva();
});


function LlenarComboEmpleado() {
    LlenarComboServicio("http://localhost:62556/Api/Empleado", "#cboEmpleado", "", false);
}

function LlenarTablaReserva() {
    LlenaTablaServicio("http://localhost:62556/Api/Reserva", "#tblReserva");
}

function LlenarComboTipoVehiculo() {

    LlenarComboServicio("http://localhost:62556/Api/TipoVehiculo", "#cboTipoVehiculo", "", false);
    LlenarComboVehiculo();
}

function LlenarComboVehiculo() {

    let Codigo = $("#cboTipoVehiculo").val();
    if (Codigo >= 0) {
        let sURL = "http://localhost:62556/Api/Vehiculo/GetComboVehiculosXTipo?Codigo=" + Codigo
        LlenarComboServicio(sURL, "#cboVehiculo", "", false);
    }
}

function LlenarComboVehiculoAll() {

    let Codigo = $("#cboTipoVehiculo").val();
    if (Codigo >= 0) {
        let sURL = "http://localhost:62556/Api/Vehiculo";
        LlenarComboServicio(sURL, "#cboVehiculo", "", false);
    }
}

// Fucion para manipular los datos de las filas
function EditarFila(DatosFila) {
    $("#txtCodigoReserva").val(DatosFila.find('td:eq(0)').text());
    $("#txtFechaInicio").val(DatosFila.find('td:eq(6)').text().split('T')[0]);
    $("#txtFechaFin").val(DatosFila.find('td:eq(7)').text().split('T')[0]);
    $("#cboEmpleado").val(DatosFila.find('td:eq(2)').text());
    $("#cboTipoVehiculo").val(DatosFila.find('td:eq(3)').text());
    LlenarComboVehiculoAll();
    $("#cboVehiculo").val(DatosFila.find('td:eq(4)').text());
    $("#txtDocumentoCliente").val(DatosFila.find('td:eq(1)').text());
    ConsultarCliente();
    $("#txtEstadoReserva").val(DatosFila.find('td:eq(5)').text());
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


function Consultar() {
    let CedulaCliente = $("#txtDocumentoCliente").val();
    LlenaTablaServicio("http://localhost:62556/Api/Reserva?CedulaCliente=" + CedulaCliente, "#tblReserva");

    $("#txtCodigoReserva").val("");
    $("#txtFechaInicio").val("");
    $("#txtFechaFin").val("");

    /*
    $.ajax({
        type: "GET",
        url: "http://localhost:62556/Api/Reserva?CedulaCliente=" + CedulaCliente,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Reserva) {

            
            $("#cboTipoVehiculo").val(Reserva.IDTipoVehiculo);
            LlenarComboVehiculo();
            $("#txtCodigoReserva").val(Reserva.Codigo);
            $("#txtFechaInicio").val(Reserva.FechaInicio.split('T')[0]);
            $("#txtFechaFin").val(Reserva.FechaFin.split('T')[0]);
            $("#cboEmpleado").val(Reserva.IDEmpleado);
            ConsultarCliente();

            $("#cboVehiculo").val(Reserva.PlacaVehiculo);
            $("#txtDocumentoCliente").val(Reserva.CedulaCliente);
            ConsultarCliente();
            $("#txtEstadoReserva").val(Reserva.EstadoReserva);
            
            
        },
        error: function (errReserva) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errReserva.html);
        }
    });*/
}


function Procesar(Comando) {

    let Codigo = $("#txtCodigoReserva").val();
    let CedulaCliente = $("#txtDocumentoCliente").val();
    let IDEmpleado = $("#cboEmpleado").val();
    let IDTipoVehiculo = $("#cboTipoVehiculo").val();
    let PlacaVehiculo = $("#cboVehiculo").val();
    let EstadoReserva = $("#txtEstadoReserva").val();
    let FechaInicio = $("#txtFechaInicio").val();
    let FechaFin = $("#txtFechaFin").val();

    DatosReserva = {
        Codigo: Codigo,
        CedulaCliente: CedulaCliente,
        IDEmpleado: IDEmpleado,
        IDTipoVehiculo: IDTipoVehiculo,
        PlacaVehiculo: PlacaVehiculo,
        EstadoReserva: EstadoReserva,
        FechaInicio: FechaInicio,
        FechaFin: FechaFin


    }
    $.ajax({
        type: Comando,
        url: "http://localhost:62556/Api/Reserva",
        contentType: "application/json",
        data: JSON.stringify(DatosReserva),
        dataType: "json",
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Rpta);
            //Vuelve y presenta la tabla con los cambios realizados
            LlenarTablaReserva();
        },
        error: function (errReserva) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errReserva.html);
        }
    });
}









