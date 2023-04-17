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
    // Obtiene la fecha del sistema y la presenta en el txt
    let now = new Date();
    $("#txtFechaInicio").val(now.toISOString().split('T')[0]);

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
    $("#btnCancelar").click(function () {
        Cancelar();
    });

    $("#btnEliminar").click(function () {
        Procesar('DELETE');
    });

    //Lena el combo de empleados
    LlenarComboEmpleado();
    //Lena el combo de vehiculos
    LlenarComboVehiculo();




    LlenarTablaAlquiler("http://localhost:62556/Api/Empleado", "#tblAlquiler");

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



// Fucion para manipular los datos de las filas
function EditarFila(DatosFila) {
    $("#txtCodigoAlquiler").val(DatosFila.find('td:eq(0)').text());
    $("#txtDocumentoCliente").val(DatosFila.find('td:eq(1)').text());
    ConsultarCliente();
    $("#cboEmpleado").val(DatosFila.find('td:eq(2)').text()); 
    $("#cboVehiculo").val(DatosFila.find('td:eq(3)').text());
    $("#txtEstado").val(DatosFila.find('td:eq(4)').text());
    $("#txtFechaInicio").val(DatosFila.find('td:eq(5)').text().split('T')[0]);
    $("#txtFechaFin").val(DatosFila.find('td:eq(6)').text().split('T')[0]);
}

function Consultar() {
    let Documento = $("#txtDocumentoCliente").val();

    $.ajax({
        type: "GET",
        url: "http://localhost:62556/Api/Alquiler?Documento=" + Documento,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Alquiler) {

            $("#txtCodigoAlquiler").val(Alquiler.Codigo);
            $("#txtDocumentoCliente").val(Alquiler.CedulaCliente);

            ConsultarCliente();

            $("#cboEmpleado").val(Alquiler.IDEmpleado);
            $("#cboVehiculo").val(Alquiler.PlacaVehiculo);
            $("#txtEstado").val(Alquiler.Estado);

            let FechaInicio = Alquiler.FechaInicio.split('T')[0];
            $("#txtFechaInicio").val(FechaInicio);
            

            let FechaFin = Alquiler.FechaFin.split('T')[0];
            $("#txtFechaFin").val(FechaFin);

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
        IDEmpleado: Empleado,
        PlacaVehiculo: Vehiculo,
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
            if (Rpta.length < 4) {
                $("#txtCodigoAlquiler").val(Rpta);
            } else {
                $("#dvMensaje").addClass("alert alert-success");
                $("#dvMensaje").html(Rpta);
            }
            //Vuelve y presenta la tabla con los cambios realizados
            LlenarTablaAlquiler("http://localhost:62556/Api/Empleado", "#tblAlquiler");
        },
        error: function (errAlquiler) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errAlquiler.html);
        }
    });
}


