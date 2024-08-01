$(document).ready(function () {

    GetAll();

        $.ajax({
            url: "/Empleado/GetAllCatEntidadFederativa",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (grupos) {
                $.each(grupos.Objects, function (i, grupos) {
                    $("#ddlEstado").append('<option value="' + grupos.Id + '">' + grupos.Estado + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed.' + ex.ErrorMessage);
            }
        });
});

function GetAll() {
    $.ajax({
        url: "/Empleado/GetAllJS",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.Correct) {
                $.each(result.Objects, function (key, item) {
                    html += '<tr>';
                    html += '<td> <a class="btn btn-warning" href="#" onclick="GetById(' + item.Id + '), clearTextBox()">Editar</a></td>';
                    html += '<td>' + item.Id + '</td>';
                    html += '<td>' + item.NumeroNomina + '</td>';
                    html += '<td>' + item.Nombre + '</td>';
                    html += '<td>' + item.ApellidoPaterno + '</td>';
                    html += '<td>' + item.ApellidoMaterno + '</td>';
                    html += '<td>' + item.CatEntidadFederativa.Estado + '</td>';
                    html += '<td><a class="btn btn-danger"  href="#" onclick="Delete(' + item.Id + ')">Eliminar</a></td>';
                    html += '</tr>';
                });
                $('#tabla tbody').html(html);
            }
            else {
                var AlertError = '<div class="alert alert-danger" role="alert">' +
                    'No se encontro ningun registro. Error:' + result.errorMenssage +
                    '</div>';

                $('#tabla').hide();
                $('#data').html(AlertError);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function CreateModal() {

    var Id = $('#txtIdEmpleado').val();
    if (Id == "") {
        Id = 0;
    }
    else {
        Id = $('#txtIdEmpleado').val();
    }


    var NumeroNomina = $('#txtNumeroNomina').val();
    var Nombre = $('#txtNombre').val();
    var ApellidoPaterno = $('#txtApellidoPaterno').val();
    var ApellidoMaterno = $('#txtApellidoMaterno').val();
    var CatEntidadFederativa = $('#ddlEstado').val();
    var data = {
        Id: Id,
        NumeroNomina: NumeroNomina,
        Nombre: Nombre,
        ApellidoPaterno: ApellidoPaterno,
        ApellidoMaterno: ApellidoMaterno,
        CatEntidadFederativa: { Id: CatEntidadFederativa }
    }
    return data;
}
function Guardar() {
    var txtIdEmpleado = $("#txtIdEmpleado").val();
    var URL = "";
    if (txtIdEmpleado == "") {
        URL = "/Empleado/Add"
    }
    else {
        URL = "/Empleado/Update"
    }

    var empleado = CreateModal();
    $.ajax({
        url: URL,
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(empleado),

        success: function (result) {
            GetAll();
            $('#exampleModal').modal('hide');
            alert("Se agrego correctamente.");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function GetById(id) {
    $.ajax({
        url: "/Empleado/GetById",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: { 'id': id },
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.Id);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#ddlEstado').val(result.Object.CatEntidadFederativa.Id);
            $('#exampleModal').modal('show');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function Delete(id) {
    var ans = confirm("Seguro que desea eliminar el registro?");
    if (ans) {
        $.ajax({
            url: "/Empleado/Delete",
            type: "GET",
            dataType: "json",
            data: { 'id': id },
            success: function (result) {
                GetAll();
                alert("Se elimino correctamente.");
            },
            error: function (ex) {
                alert('Failed.' + ex.ErrorMessage);
            }
        });
    }
}
function clearTextBox() {
    $('#txtIdEmpleado').val("");
    $('#txtNumeroNomina').val("");
    $('#txtNombre').val("");
    $('#txtApellidoPaterno').val("");
    $('#txtApellidoMaterno').val("");
    $("#ddlEstado").val("");

}

