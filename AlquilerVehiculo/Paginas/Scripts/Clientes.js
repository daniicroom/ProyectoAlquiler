
$(document).ready(function () {

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
    LlenarComboTipoDocumento();
    LlenarCategoriaLicencia();
});

function LlenarComboTipoDocumento() {
    LlenarComboServicio("http://madasolutions-001-site1.etempurl.com/Api/TipoDocumento", "#cboTipoDocumento", "", false);
}

function LlenarCategoriaLicencia() {
    LlenarComboServicio("http://madasolutions-001-site1.etempurl.com/Api/CategoriaLicencia", "#cboCategoriaLicencia", "", false);
}



function Consultar() {
    let Documento = $("#txtDocumento").val();

    $.ajax({
        type: "GET",
        url: "http://madasolutions-001-site1.etempurl.com/Api/Cliente?Documento=" + Documento,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Cliente) {

            $("#cboTipoDocumento").val(Cliente.TipoDocumento);
            $("#txtNombre").val(Cliente.Nombres);
            $("#txtApellidos").val(Cliente.Apellidos);
            $("#txtDireccion").val(Cliente.Direccion);
            $("#txtEdad").val(Cliente.Edad);
            $("#cboCategoriaLicencia").val(Cliente.IDLicencia);
            $("#txtNumeroLicencia").val(Cliente.NumeroLicencia);
        },
        error: function (errClientes) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errClientes.html);
        }
    });
}


function Procesar(Comando) {
    let Documento = $("#txtDocumento").val();
    let TipoDocumento = $("#cboTipoDocumento").val();
    let Nombres = $("#txtNombre").val();
    let Apellidos = $("#txtApellidos").val();
    let Direccion = $("#txtDireccion").val();
    let Edad = $("#txtEdad").val();
    let NumeroLicencia = $("#txtNumeroLicencia").val();
    let IdLicencia = $("#cboCategoriaLicencia").val();


    DatosCliente = {

        Documento: Documento,
        TipoDocumento: TipoDocumento,
        Nombres: Nombres,
        Apellidos: Apellidos,
        Direccion: Direccion,
        Edad: Edad,
        NumeroLicencia: NumeroLicencia,
        IDLicencia: IdLicencia

    }
    $.ajax({
        type: Comando,
        url: "http://madasolutions-001-site1.etempurl.com/Api/Cliente",
        contentType: "application/json",
        data: JSON.stringify(DatosCliente),
        dataType: "json",
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Rpta);

        },
        error: function (errClientes) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errClientes.html);
        }
    });
}