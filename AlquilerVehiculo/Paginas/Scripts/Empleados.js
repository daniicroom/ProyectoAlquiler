
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
    LlenarComboCargo();
});

function LlenarComboCargo() {
    LlenarComboServicio("http://localhost:62556/api/Cargo", "#cboCargo", "", false);
}


function Consultar() {
    let Documento = $("#txtDocumento").val();

    $.ajax({
        type: "GET",
        url: "http://localhost:62556/api/Empleado?Documento=" + Documento,
        contentType: "application/json",
        data: null,
        dataType: "json",
        success: function (Empleado) {

            $("#txtNombre").val(Empleado.Nombres);
            $("#txtApellidos").val(Empleado.Apellidos);
            $("#cboCargo").val(Empleado.IDCargoEmpleado);

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
    let IdCargoEmpleado = $("#cboCargo").val();


    DatosEmpleado = {

        Documento: Documento,
        Nombres: Nombres,
        Apellidos: Apellidos,
        IDCargoEmpleado: IdCargoEmpleado

    }
    $.ajax({
        type: Comando,
        url: "http://localhost:62556/api/Empleado",
        contentType: "application/json",
        data: JSON.stringify(DatosEmpleado),
        dataType: "json",
        success: function (Rpta) {
            $("#dvMensaje").addClass("alert alert-success");
            $("#dvMensaje").html(Rpta);

        },
        error: function (errEmpleados) {
            $("#dvMensaje").addClass("alert alert-danger");
            $("#dvMensaje").html(errEmpleados.html);
        }
    });
}