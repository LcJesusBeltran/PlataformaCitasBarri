function BuscarFecha(Id) {
    var value = $("#iBusqueda").val();
    if (value == "") {        
        alert("Seleccione una Fecha");
        return
    }

    const hoy = Date.now()
    const ValidaFecha = formatDate(hoy);

    if (value < ValidaFecha) {
        $("#lCitas").empty();
        alert("Favor de seleccionar una fecha mayor al dia de hoy")
        return
    }

    $.ajax({
        url: "https://localhost:44364/Home/BuscarDisponibilidad",
        dataType: 'JSON',
        type: 'POST',        
        data: {
            fecha: value.toString(),
            Id: Id
        }, success: function (data) {
            LlenarCitas(Id,data.ListaCalendario);
            /*console.log(data);*/
        }, error: function (xhr, status, error) {
            console.log(error)
        }
    })
}

function BuscarFechaManual(Id) {
    var value = $("#iBusqueda").val();
    if (value == "") {
        alert("Seleccione una Fecha");
        return
    }

    const hoy = Date.now()
    const ValidaFecha = formatDate(hoy);

    if (value < ValidaFecha) {
        $("#lCitas").empty();
        alert("Favor de seleccionar una fecha mayor al dia de hoy")
        return
    }

    $.ajax({
        url: "https://localhost:44364/Home/BuscarDisponibilidad",
        dataType: 'JSON',
        type: 'POST',
        data: {
            fecha: value.toString(),
            Id: Id
        }, success: function (data) {            
            LlenarCitasManual(Id, data.ListaCalendario);
            /*console.log(data);*/
        }, error: function (xhr, status, error) {
            console.log(error)
        }
    })
}



function ArmaFuncionCitaManual(Id, IdHoraCita) {
    //Descripcion
    $("#EnviaCita").empty();
    $("#ContModal").empty();
    var ContModal = document.getElementById("ContModal");
    var InputCont = "";
    InputCont = "<input data-val='true' data-val-required='Valor Requerido.' id='iNombre' name='iNombre' type='text' maxlength='100' class='form-control' autocomplete='false' placeholder='Nombre de Paciente' />";
    InputCont += "<br/>"
    InputCont += "<input data-val='true' data-val-required='Valor Requerido.' id='iCorreo' name='iCorreo' type='text' maxlength='100' class='form-control' autocomplete='false' placeholder='Correo de Paciente'/>"; 

    ContModal.innerHTML = InputCont;
    var Botones = document.getElementById("EnviaCita");
    var DivCont = "";
    DivCont = "<button type='button' class='btn btn-secondary' data-dismiss='modal'>Cancelar</button>";
    DivCont += "<button type='button' class='btn btn-primary' OnClick='EnviarCitaManual(" + Id + "," + IdHoraCita + ")'>Aceptar</button>";
    Botones.innerHTML = DivCont;
}


function ArmaFuncionCita(Id, IdHoraCita) {
    //Descripcion
    $("#EnviaCita").empty();
    var Botones = document.getElementById("EnviaCita");    
    var DivCont = "";    
    DivCont = "<button type='button' class='btn btn-secondary' data-dismiss='modal'>Cancelar</button>";
    DivCont += "<button type='button' class='btn btn-primary' OnClick='EnviarCita(" + Id + "," + IdHoraCita + ")'>Aceptar</button>";
    Botones.innerHTML = DivCont;
}

function EnviarCitaManual(Id, IdHoraCita) {

    var iNombre = $("#iNombre").val();
    var iCorreo = $("#iCorreo").val();
    if (iCorreo === '' || iNombre === '') {
        alert("Debe de llenar los campos nombre y correo");
        return
    }

    var fecha = $("#iBusqueda").val();
    var ContModal = document.getElementById("ContModal");
    ContModal.innerHTML = "Procesando.."
    $.ajax({
        url: "https://localhost:44364/Home/CrearCitaManual",
        dataType: 'JSON',
        type: 'POST',
        data: {
            fecha: fecha,
            Id: Id,
            IdHoraCita: IdHoraCita,
            Nombre: iNombre,
            Correo: iCorreo
        }, success: function (data) {

            if (data.bError === false) {
                LlenarCitasManual(Id, data.ListaCalendario);
                ContModal.innerHTML = "Cita Confirmada";
            }
            else {
                ContModal.innerHTML = "No pudimos Confirmar tu Cita";
            }

            $("#EnviaCita").empty();
            var Botones = document.getElementById("EnviaCita");
            var DivCont = "";
            DivCont = "<button type='button' class='btn btn-secondary' data-dismiss='modal'>Cerrar</button>";
            Botones.innerHTML = DivCont;


            /*console.log(data);*/
        }, error: function (xhr, status, error) {
            console.log(error)
        }
    })
}

function EnviarCita(Id, IdHoraCita) {
    var fecha = $("#iBusqueda").val();
    var ContModal = document.getElementById("ContModal");
    ContModal.innerHTML = "Procesando.."
    $.ajax({
        url: "https://localhost:44364/Home/CrearCita",
        dataType: 'JSON',
        type: 'POST',
        data: {
            fecha: fecha,
            Id: Id,
            IdHoraCita: IdHoraCita
        }, success: function (data) {

            if (data.bError === false) {
                LlenarCitas(Id, data.ListaCalendario);
                ContModal.innerHTML = "Cita Confirmada";
            }
            else {
                ContModal.innerHTML = "No pudimos Confirmar tu Cita";
            }

            $("#EnviaCita").empty();
            var Botones = document.getElementById("EnviaCita");
            var DivCont = "";
            DivCont = "<button type='button' class='btn btn-secondary' data-dismiss='modal'>Cerrar</button>";
            Botones.innerHTML = DivCont;          
            

            /*console.log(data);*/
        }, error: function (xhr, status, error) {
            console.log(error)
        }
    })    
}

function LlenarCitas(Id, data) {
    
    /*console.log(data);*/
    $("#lCitas").empty();
    var ContCitas = document.getElementById("lCitas");
    var DivCont = "";
    for (var i = 0; i < data.length; i++) {        
        DivCont = "";
        if (data[i].IdCalendario === null) {
            DivCont = "<div class='border mt-1 d-flex flex-row btn cta-aux p-2' data-toggle='modal' data-target='#exampleModal' OnClick='ArmaFuncionCita(" + Id + "," + data[i].IdHoraCita + ")'>";
        }
        else {
            DivCont = "<div class='border mt-1 d-flex flex-row btn bg-info text-white p-2'>";
        }
        DivCont += "<div class='w-50'>" + data[i].Descripcion + "</div>";
        DivCont += "<div class='w-50'>" + data[i].Estatus + "</div>";
        DivCont += "</div>";
        
        ContCitas.innerHTML += DivCont;
    }
}

function LlenarCitasManual(Id, data) {

    /*console.log(data);*/
    $("#lCitas").empty();
    var ContCitas = document.getElementById("lCitas");
    var DivCont = "";
    for (var i = 0; i < data.length; i++) {
        DivCont = "";
        if (data[i].IdCalendario === null) {
            DivCont = "<div class='border mt-1 d-flex flex-row btn cta-aux p-2' data-toggle='modal' data-target='#exampleModal' OnClick='ArmaFuncionCitaManual(" + Id + "," + data[i].IdHoraCita + ")'>";
            DivCont += "<div class='w-50'>Hora Libre</div>";
        }
        else {
            DivCont = "<div class='border mt-1 d-flex flex-row btn bg-info text-white p-2'>";
            DivCont += "<div class='w-50'>" + data[i].NombreCompleto + "</div>";
        }
        DivCont += "<div class='w-50'>" + data[i].Descripcion + "</div>";
        DivCont += "<div class='w-50'>" + data[i].Estatus + "</div>";
        DivCont += "</div>";

        ContCitas.innerHTML += DivCont;
    }
}

function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [year, month, day].join('-');
}

function LimpiarCita() {
    $("#lCitas").empty();
}

function BuscarAgenda(Id) {
    var value = $("#iBusqueda").val();
    const hoy = Date.now()
    const ValidaFecha = formatDate(hoy);
    if (value == "") {
        value = ValidaFecha;
        $("#iBusqueda").val(value);
    }

    $.ajax({
        url: "https://localhost:44364/Home/BuscarDisponibilidad",
        dataType: 'JSON',
        type: 'POST',
        data: {
            fecha: value.toString(),
            Id: Id
        }, success: function (data) {
            LlenarAgenda(data.ListaCalendario);
            /*console.log(data);*/
        }, error: function (xhr, status, error) {
            console.log(error)
        }
    })

}

function LlenarAgenda(data) {

    //console.log(data);
    $("#lCitas").empty();
    var ContCitas = document.getElementById("lCitas");
    var DivCont = "";
    for (var i = 0; i < data.length; i++) {
        DivCont = "";
        if (data[i].IdCalendario === null) {
            DivCont = "<div class='border mt-1 d-flex flex-row btn cta-aux2 p-2'>";
            DivCont += "<div class='w-50'>Hora Libre</div>";
        }
        else {            
            DivCont = "<div class='border mt-1 d-flex flex-row btn bg-info text-white p-2'>";
            DivCont += "<div class='w-50'>" + data[i].NombreCompleto + "</div>";
        }        
        DivCont += "<div class='w-50'>" + data[i].Descripcion + "</div>";
        DivCont += "<div class='w-50'>" + data[i].Estatus + "</div>";
        DivCont += "</div>";

        ContCitas.innerHTML += DivCont;
    }
}

