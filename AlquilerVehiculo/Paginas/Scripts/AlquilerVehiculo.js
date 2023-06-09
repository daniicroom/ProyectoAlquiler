var oTabla = $("#tblAlquiler").DataTable();

$(document).ready(function () {
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
    $("#btnConsultar").click(function () {
        Consultar();
    });

    $("#btnEliminar").click(function () {
        Procesar('DELETE');
    });

    //Lena el combo de empleados
    LlenarComboEmpleado();
    //Lena el combo de vehiculos
    LlenarComboTipoVehiculo();

    LlenarTablaAlquiler();

});

function LlenarComboEmpleado() {
    //LlenarComboServicio("http://localhost:62556/Api/Empleado", "#cboEmpleado", "", false);
    LlenarComboServicio("http://madasolutions-001-site1.etempurl.com/Api/Empleado", "#cboEmpleado", "", false);
}

function LlenarTablaAlquiler() {
    LlenaTablaServicio("http://madasolutions-001-site1.etempurl.com/Api/Alquiler", "#tblAlquiler");
}

function LlenarComboTipoVehiculo() {

    LlenarComboServicio("http://madasolutions-001-site1.etempurl.com/Api/TipoVehiculo", "#cboTipoVehiculo", "", false);
}

function LlenarComboVehiculo() {

    let Codigo = $("#cboTipoVehiculo").val();
    let Cedula = $("#txtDocumentoCliente").val();
    if (Codigo >= 0) {
        let sURL = "http://madasolutions-001-site1.etempurl.com/Api/Vehiculo/GetComboVehiculosXTipoCliente?Codigo=" + Codigo + "&Cedula="+Cedula
        LlenarComboServicio(sURL, "#cboVehiculo", "", false);
    }
}

// Aquí se realiza la consulta del cliente a traves del documento
function ConsultarCliente() {
    let Documento = $("#txtDocumentoCliente").val();
    $.ajax({
        type: "GET",
        url: "http://madasolutions-001-site1.etempurl.com/Api/Cliente?Documento=" + Documento,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Cliente) {
            $("#txtNombreCliente").val(Cliente.Nombres + " " +
                Cliente.Apellidos);
            LlenarComboVehiculo();
        },
        error: function (errCliente) {
            $("#txtNombreCliente").val(errCliente);
        }
    });
}



// Funcion para manipular los datos de las filas
function EditarFila(DatosFila) {
    $("#cboTipoVehiculo").val(DatosFila.find('td:eq(3)').text());

    let Codigo = $("#cboTipoVehiculo").val();
    let Placa = DatosFila.find('td:eq(4)').text();
    
    LlenarComboServicio("http://madasolutions-001-site1.etempurl.com/Api/Vehiculo/GetAllComboVehiculosXTipo?Codigo=" + Codigo+"&Placa="+Placa, "#cboVehiculo", "", false);

    $("#txtCodigoAlquiler").val(DatosFila.find('td:eq(0)').text());
    $("#txtDocumentoCliente").val(DatosFila.find('td:eq(1)').text());
    $("#cboEmpleado").val(DatosFila.find('td:eq(2)').text());
    ConsultarCliente();

    $("#txtEstado").val(DatosFila.find('td:eq(5)').text());
    $("#txtFechaInicio").val(DatosFila.find('td:eq(6)').text().split('T')[0]);
    $("#txtFechaFin").val(DatosFila.find('td:eq(7)').text().split('T')[0]);
    $("#cboVehiculo").val(DatosFila.find('td:eq(4)').text());
}

function Consultar() {
    let Documento = $("#txtDocumentoCliente").val();
    LlenaTablaServicio("http://madasolutions-001-site1.etempurl.com/Api/Alquiler?Documento=" + Documento, "#tblAlquiler");
    ConsultarCliente();

    $("#txtCodigoAlquiler").val("");
    $("#txtFechaInicio").val("");
    $("#txtFechaFin").val("");
}


function Procesar(Comando) {

    let Codigo = $("#txtCodigoAlquiler").val();
    let DocumentoCliente = $("#txtDocumentoCliente").val();
    ConsultarCliente();
    let Empleado = $("#cboEmpleado").val();
    let IDTipoVehiculo = $("#cboTipoVehiculo").val();
    let Vehiculo = $("#cboVehiculo").val();
    let Estado = $("#txtEstado").val();
    let FechaInicio = $("#txtFechaInicio").val();
    let FechaFin = $("#txtFechaFin").val();

    DatosAlquiler = {
        Codigo: Codigo,
        CedulaCliente: DocumentoCliente,
        IDEmpleado: Empleado,
        IDTipoVehiculo: IDTipoVehiculo,
        PlacaVehiculo: Vehiculo,
        EstadoAlquiler: Estado,
        FechaInicio: FechaInicio,
        FechaFin: FechaFin,
    }
    $.ajax({
        type: Comando,
        url: "http://madasolutions-001-site1.etempurl.com/Api/Alquiler",
        contentType: "application/json",
        data: JSON.stringify(DatosAlquiler),
        dataType: "json",
        success: function (Rpta) {
            if (Rpta.length < 4) {
                $("#txtCodigoAlquiler").val(Rpta);
            } else {
                $("#dvMensaje").addClass("alert alert-success");
                $("#dvMensaje").html(Rpta);
            }
            //Vuelve y presenta la tabla con los cambios realizados
            LlenarTablaAlquiler("http://madasolutions-001-site1.etempurl.com/Api/Alquiler", "#tblAlquiler");
        },
        error: function (errAlquiler) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errAlquiler.html);
        }
    });
}


