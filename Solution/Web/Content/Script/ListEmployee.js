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

function Edit(id) {
    window.location = "EmployeeRegister/Index/" + id;        
}

function Delete(id) {
    $.confirm({
        title: 'Atenção!',
        content: 'Dejesa realmente excluir este empregado? Essa ação não poderá ser desfeita',
        type: 'orange',
        theme: 'material',
        buttons:
        {
            Sim:
            {
                btnClass: 'btn-primary',
                action: function () {                    
                }
            },
            Nao:
            {
                text: 'Não'
            }
        }
    });
}