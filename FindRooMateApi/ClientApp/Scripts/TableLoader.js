$(document).ready(function () {
    alert("test")
    FillTable()
})

function FillTable() {
    //Http call setting
    const setting = {
        "async": true,
        "crossDomain": true,
        "url": "https://localhost:7164/api/Student/read",
        "method": "GET"
    }
    //Http call
    $.ajax(setting).done(function (response) {
        console.log(response)
        $(function () { //Add data to table
            $.each(response, function (i, item) {
                var $tr = $('<tr>').append(
                    $('<td>').text(item.id),
                    $('<td>').text(item.name),
                    $('<td>').text(item.surname),
                    $('<td>').append($('<button type ="submit" id = "buttonAdd">').text("Shto")),
                    $('<td>').append($('<button type ="submit" id = "buttonDelete">').text("Fshi"))
                ).appendTo('#records_table')
            });
        });
    })
    //Http Add
    $("#records_table").on('click', '#buttonAdd', function () {
        alert("button");
        window.location.href = "file:///C:/Users/Perdorues/source/repos/FindRooMate/FindRooMateApi/ClientApp/Pages/StudentAdd.html"
    });

    //Submmit form
    $('#myForm').on('click', '#id-button', function (e) {
        e.preventDefault()
        alert("tesyt")

        let name = $("#fname").val();
        let surname = $("#lname").val();

        console.log(name + " " + surname);

        //Http post setting
        const setting = {
            "async": true,
            "crossDomain": true,
            "url": "https://localhost:7164/api/Student/create?name=" + name + "&surname=" + surname,
            "method": "POST"
        };
        $.ajax(setting).done(function (response) {
            console.log(response)
        })


    });
}