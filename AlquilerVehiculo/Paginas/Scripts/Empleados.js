
$(document).ready(function () {

    //Registrar los botones para responder al evento click
    $("#btnIngresar").click(function () {
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

});

function LlenarComboCargo() {
    LlenarComboServicio("http://localhost:62556/Api/Cargo", "#cboCargo", "", true);
}


function Consultar() {
    let Documento = $("#txtDocumento").val();

    $.ajax({
        type: "GET",
        url: "http://localhost:62556/Api/Empleado?Documento=" + Documento,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Empleado) {

            $("#txtNombre").val(Empleado.Nombres);
            $("#txtApellidos").val(Empleado.Apellidos);
            $("#cboCargo").val(Empleado.IdCargoEmpleado);

        },
        error: function (errPaises) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errEmpleados.html);
        }
    });
}


function Procesar(Comando) {
    let Documento = $("#txtDocumento").val();
    let Nombres = $("#txtNombre").val();
    let Apellidos = $("#txtApellidos").val();
    let Cargo = $("#cboCargo").val();


    DatosEmpleado = {

        Documento: Documento,
        Nombres: Nombres,
        Apellidos: Apellidos,
        IdCargoEmpleado: IdCargoEmpleado

    }
    $.ajax({
        type: Comando,
        url: "http://localhost:62556/Api/Empleado",
        contentType: "application/json",
        data: JSON.stringify(DatosEmpleado),
        dataType: "json",
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Rpta);

        },
        error: function (errPaises) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errEmpleados.html);
        }
    });
}