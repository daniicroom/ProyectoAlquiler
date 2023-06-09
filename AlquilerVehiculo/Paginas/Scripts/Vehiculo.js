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
    LlenaTablaServicio("http://madasolutions-001-site1.etempurl.com/Api/Vehiculo/GetTable", "#tblVehiculo");
});



function LlenarComboSede() {
    LlenarComboServicio("http://madasolutions-001-site1.etempurl.com/Api/Sede", "#cboSede", "", true);
}

function LlenarComboMarca() {
    LlenarComboServicio("http://madasolutions-001-site1.etempurl.com/Api/Marca", "#cboMarca", "", true);
}

function LlenarComboGama() {
    LlenarComboServicio("http://madasolutions-001-site1.etempurl.com/Api/Gama", "#cboGama", "", true);
}

function LlenarComboColor() {
    LlenarComboServicio("http://madasolutions-001-site1.etempurl.com/Api/Color", "#cboColor", "", false);
}

function LlenarComboTipoVehiculo() {
    LlenarComboServicio("http://madasolutions-001-site1.etempurl.com/Api/TipoVehiculo", "#cboTipoVehiculo", "", false);
}


// Fucion para manipular los datos de las filas
function EditarFila(DatosFila) {
    $("#txtPlaca").val(DatosFila.find('td:eq(0)').text());
    $("#txtDescripcion").val(DatosFila.find('td:eq(1)').text());
    $("#txtEstado").val(DatosFila.find('td:eq(2)').text());
    $("#cboSede").val(DatosFila.find('td:eq(3)').text());
    $("#cboMarca").val(DatosFila.find('td:eq(5)').text());
    $("#cboGama").val(DatosFila.find('td:eq(7)').text());
    $("#cboColor").val(DatosFila.find('td:eq(9)').text());
    $("#cboTipoVehiculo").val(DatosFila.find('td:eq(11)').text());
    $("#txtPrecio").val(DatosFila.find('td:eq(13)').text());
}



function Consultar() {
    let Placa = $("#txtPlaca").val();

    $.ajax({
        type: "GET",
        url: "http://madasolutions-001-site1.etempurl.com/Api/Vehiculo?Placa=" + Placa,
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
            $("#cboTipoVehiculo").val(Vehiculo.IDTipoVehiculo);
            $("#txtPrecio").val(Vehiculo.Precio);
            
            
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
    let Estado = $("#txtEstado").val();

    if (Estado == null) {
        Estado = "DISPONIBLE";
    }

    
    let IdSede = $("#cboSede").val();
    let IdMarca = $("#cboMarca").val();
    let IdGama = $("#cboGama").val();
    let IdColor = $("#cboColor").val();
    let IdTipoVehiculo = $("#cboTipoVehiculo").val();
    let Precio = $("#txtPrecio").val();
    

    DatosVehiculo = {
        Placa: Placa,
        Descripcion: Descripcion,
        Estado: Estado,
        IdSede: IdSede,
        IdMarca: IdMarca,
        IdGama: IdGama,
        IdColor: IdColor,
        IdTipoVehiculo: IdTipoVehiculo,
        Precio: Precio,
        
    }
    $.ajax({
        type: Comando,
        url: "http://madasolutions-001-site1.etempurl.com/Api/Vehiculo",
        contentType: "application/json",
        data: JSON.stringify(DatosVehiculo),
        dataType: "json",
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Rpta);

            //Vuelve y presenta la tabla con los cambios realizados
            LlenaTablaServicio("http://madasolutions-001-site1.etempurl.com/Api/Vehiculo/GetTable", "#tblVehiculo");
        },
        error: function (errVehiculo) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errVehiculo.html);
        }
    });
}
