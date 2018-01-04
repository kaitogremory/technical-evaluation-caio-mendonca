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
         ShowErrorMessage(errorThrown, status);
     })
     .always(function (xhr, status) {         
         
     });
}

function Edit(id) {
    window.location = "EmployeeRegister/Index/" + id;        
}

function ConfirmDelete(id) {
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
                    Delete(id);
                }
            },
            Nao:
            {
                text: 'Não'
            }
        }
    });
}

function Delete(id) {
    $.ajax({
        url: serviceBase + "Employee/Delete",
        data: { idEmployee: id },        
        dataType: "json",
    })
     .done(function (json) {
         ShowSucessMessage(json.register.message);
     })
     .fail(function (xhr, status, errorThrown) {
         ShowErrorMessage(errorThrown, status);
     })
     .always(function (xhr, status) {

     });
}

function ShowErrorMessage(errorThrown, status) {
    $.alert({
        title: 'Erro!',
        content: 'Ocorreu um erro! Entre em contato com o suporte técnico.',
        type: 'red',
        theme: 'material'
    });

    console.log("Error: " + errorThrown);
    console.log("Status: " + status);
}

function ShowSucessMessage(msg) {
    $.alert({
        title: 'Sucesso!',
        content: msg,
        type: 'green',
        theme: 'material'
    });
}