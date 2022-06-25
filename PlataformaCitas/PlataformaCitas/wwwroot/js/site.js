// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function testApi()
{
    alert("alerta");

    $.ajax({
        url: 'https://localhost:44321/api/values',
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log(data);
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    })

    return false;


}

function exampleRequestJQuery() {

    var value = "GK76KPlO2kjjaqWzri8eQ5AqUEMzXs0O";
    alert(value);

    $.ajax({
        url: 'https://reserve.elcid.com.mx/ElCidInterval/api/Token/',
        method: 'POST',
        dataType: 'json',
        data: {
            token: value
        },
        success: function (data) {
            console.log(data);
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    })

    return false;
}