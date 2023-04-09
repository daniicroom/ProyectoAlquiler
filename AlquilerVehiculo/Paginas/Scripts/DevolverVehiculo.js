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
    let Cantidad = DatosFila[4];
    let ValorUnitario = DatosFila[5];

    oTabla.row('.selected').remove().draw(false);
    MostrarActualizar(false);
}

// PENDIENTE
function AgregarItem() {
    //Agrega un ítem a la tabla tblFactura
    let CodTipoProducto = $("#cboTipoProducto").val();
    let TipoProducto = $("#cboTipoProducto option:selected").text();
    let CodigoProducto = $("#txtCodigoProducto").val();
    let Producto = $("#cboProducto option:selected").text();
    let Cantidad = $("#txtCantidad").val();
    let ValorUnitario = $("#txtValorUnitario").val();

    //Agrega los items a la tabla
    oTabla.row.add([CodTipoProducto, TipoProducto, CodigoProducto, Producto, Cantidad, ValorUnitario]).draw(false);
    TotalFactura += (Cantidad * ValorUnitario);
    $("#txtTotalCompra").val(FormatoMiles(TotalFactura));
}


// PENDIENTE
// Se graba el alquiler
function Registrar() {
    //Capturamos los datos del cliente y el empleado
    let DocumentoCliente = $("#txtDocumento").val();
    let IdEmpleado = $("#cboEmpleado").val();
    //Capturar los datos de la tabla, que corresponden al detalle de la factura
    var fieldNames = [], DEtalleFActura = [];
    oTabla.settings().columns()[0].forEach(function (index) {
        fieldNames.push($(oTabla.column(index).header()).text().replace(/ /g, ""));
    });
    oTabla.rows().data().toArray().forEach(function (row) {
        var item = {};
        row.forEach(function (content, index) {
            item[fieldNames[index]] = content;
        });
        DEtalleFActura.push(item);
    });


    let DatosFactura = {
        Numero: 0,
        Documento: DocumentoCliente,
        Fecha: "1900/01/01",
        CodigoEmpleado: IdEmpleado,
        DEtalleFActura
    }
    $.ajax({
        type: "POST",
        url: "http://localhost:50007/Api/Facturacion",
        contentType: "application/json",
        data: JSON.stringify(DatosFactura),
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

function CalcularTotalPagar() {

}
