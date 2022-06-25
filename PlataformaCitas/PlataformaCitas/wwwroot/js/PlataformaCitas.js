function BuscarFecha(Id) {
    var value = $("#iBusqueda").val();
    if (value == "") {
        alert("Seleccione una Fecha");
        return
    }

    const hoy = Date.now()
    const ValidaFecha = formatDate(hoy);

    if (value < ValidaFecha) {
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
            console.log(data);
        }, error: function (xhr, status, error) {
            console.log(error)
        }
    })

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