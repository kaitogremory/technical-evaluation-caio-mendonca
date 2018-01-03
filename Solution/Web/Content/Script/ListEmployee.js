$(document).ready(function () {
    GetEmployeeTable();   
});

function GetEmployeeTable() {    
    $.ajax({
        url: serviceBase + "Employee/GetEmployeeTable",
        //data: { id: 123 },
        type: "GET",
        dataType: "json",
    })
     .done(function (json) {                  
         $('#tableBlockDiv').html(json.register.tableHtml);
     })
     .fail(function (xhr, status, errorThrown) {         
         alert("Sorry, there was a problem!");
         console.log("Error: " + errorThrown);
         console.log("Status: " + status);
         console.dir(xhr);
     })
     .always(function (xhr, status) {         
         
     });
}