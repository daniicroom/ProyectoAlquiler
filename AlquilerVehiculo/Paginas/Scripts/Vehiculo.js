var oTabla = $("#tblVehiculo").DataTable();

$(document).ready(function () {

    //Me permite manipular las filas se debe haber declarado antes var oTabla
    $('#tblVehiculo tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            oTabla.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            EditarFila($(this).closest('tr'));
        }
    });


    //Registrar los botones para responder al evento click
    $("#btnRegistrar").click(function () {
        Procesar("POST");
    });
    $("#btnActualizar").click(function () {
        Procesar("PUT");
    });
    $("#btnEliminar").click(function () {
        Procesar("DELETE");
    });
    $("#btnConsultar").click(function () {
        Consultar();
    });

    LlenarComboSede();
    LlenarComboMarca();
    LlenarComboGama();
    LlenarComboColor();
    LlenarComboTipoVehiculo();

    //Llenar la tabla con la informacion de los vehiculos
    LlenaTablaServicio();


    //REVISAR
    //LlenarTablaVehiculoServ();


});



function LlenarComboSede() {
    LlenarComboServicio("http://localhost:62556/api/Sede", "#cboSede", "", true);
}

function LlenarComboMarca() {
    LlenarComboServicio("http://localhost:62556/api/Marca", "#cboMarca", "", true);
}

function LlenarComboGama() {
    LlenarComboServicio("http://localhost:62556/api/Gama", "#cboGama", "", true);
}

function LlenarComboColor() {
    LlenarComboServicio("http://localhost:62556/api/Color", "#cboColor", "", false);
}

function LlenarComboTipoVehiculo() {
    LlenarComboServicio("http://localhost:62556/api/TipoVehiculo", "#cboTipoVehiculo", "", false);
}


// Fucion para manipular los datos de las filas
function EditarFila(DatosFila) {
    $("#txtDescripcion").val(DatosFila.find('td:eq(1)').text());
    $("#txtEstado").val(DatosFila.find('td:eq(2)').text());
    $("#cboSede").val(DatosFila.find('td:eq(3)').text());
    $("#cboMarca").val(DatosFila.find('td:eq(4)').text());
    $("#cboGama").val(DatosFila.find('td:eq(5)').text());
    $("#cboColor").val(DatosFila.find('td:eq(6)').text());
    $("#txtPrecio").val(DatosFila.find('td:eq(7)').text());
    $("#cboTipoVehiculo").val(DatosFila.find('td:eq(8)').text());
}


function LlenarTablaVehiculoServ() {
    LlenaTablaServicio("http://localhost:62556/Api/Vehiculo", "#tblVehiculo");
}

function Consultar() {
    let Placa = $("#txtPlaca").val();

    $.ajax({
        type: "GET",
        url: "http://localhost:62556/Api/Vehiculo?Placa=" + Placa,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Vehiculo) {
            $("#txtDescripcion").val(Vehiculo.Descripcion);
            $("#txtEstado").val(Vehiculo.Estado);
            $("#cboSede").val(Vehiculo.IDSede);
            $("#cboMarca").val(Vehiculo.IDMarca);
            $("#cboGama").val(Vehiculo.IDGama);
            $("#cboColor").val(Vehiculo.IDColor);
            $("#txtPrecio").val(Vehiculo.Precio);
            $("#cboTipoVehiculo").val(Vehiculo.IDTipoVehiculo);
            
        },
        error: function (errVehiculo) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errVehiculo.html);
        }
    });
}


function Procesar(Comando) {
    let Placa = $("#txtPlaca").val();
    let Descripcion = $("#txtDescripcion").val();
    let IdSede = $("#cboSede").val();
    let IdMarca = $("#cboMarca").val();
    let IdGama = $("#cboGama").val();
    let IdColor = $("#cboColor").val();
    let Precio = $("#txtPrecio").val();
    let IdTipoVehiculo = $("#cboTipoVehiculo").val();

    DatosVehiculo = {
        Placa: Placa,
        Descripcion: Descripcion,
        IdSede: IdSede,
        IdMarca: IdMarca,
        IdGama: IdGama,
        IdColor: IdColor,
        Precio: Precio,
        IdTipoVehiculo: IdTipoVehiculo
    }
    $.ajax({
        type: Comando,
        url: "http://localhost:62556/Api/Vehiculo",
        contentType: "application/json",
        data: JSON.stringify(DatosVehiculo),
        dataType: "json",
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Rpta);
            //Vuelve y presenta la tabla con los cambios realizados
            LlenaTablaServicio();
        },
        error: function (errVehiculo) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errVehiculo.html);
        }
    });
}
