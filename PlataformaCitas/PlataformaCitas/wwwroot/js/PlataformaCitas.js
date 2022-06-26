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
            console.log(data);
        }, error: function (xhr, status, error) {
            console.log(error)
        }
    })

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

            LlenarCitas(Id, data.ListaCalendario);

            $("#EnviaCita").empty();
            var Botones = document.getElementById("EnviaCita");                        
            ContModal.innerHTML = "Cita Confirmada";
            var DivCont = "";
            DivCont = "<button type='button' class='btn btn-secondary' data-dismiss='modal'>Cerrar</button>";            
            Botones.innerHTML = DivCont;            
            

            console.log(data);
        }, error: function (xhr, status, error) {
            console.log(error)
        }
    })    
}

function LlenarCitas(Id, data) {
    
    console.log(data);
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
            console.log(data);
        }, error: function (xhr, status, error) {
            console.log(error)
        }
    })

}

function LlenarAgenda(data) {

    console.log(data);
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

