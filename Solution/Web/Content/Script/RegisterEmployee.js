$(document).ready(function () {
    GetDependentTable();   
});

function GetDependentTable() {    
    var idEmployee = $('#inputId').val();

    $.ajax({
        url: serviceBase + "EmployeeRegister/GetDependentTable",    
        data: { idEmployee: idEmployee },
        type: "GET",
        dataType: "json",
    })
     .done(function (json) {                  
         $('#dependentBlockList').html(json.register.tableHtml);
     })
     .fail(function (xhr, status, errorThrown) {
         ShowErrorMessage(errorThrown, status);
     })
     .always(function (xhr, status) {         
         
     });
}

function Save() {
    var jsonObjectString = CreateJSONObject();

    $.ajax({
        url: serviceBase + "EmployeeRegister/Save",
        data: { jsonString: jsonObjectString },
        type: "POST",
        dataType: "json",
    })
     .done(function (json) {
         if (json.success) {
             ShowSaveMessage(json.register.message);
         } else {
             $.alert({
                 title: 'Erro!',
                 content: json.register.message,
                 type: 'red',
                 theme: 'material'
             });
         }
         
     })
     .fail(function (xhr, status, errorThrown) {
         ShowErrorMessage(errorThrown,);
     })
     .always(function (xhr, status) {

     });      
}

function CreateJSONObject() {    
    var obj = {};
    obj.Id = $('#inputId').val();
    obj.Name = $('#inputName').val();
    obj.Email = $('#inputEmail').val();
    obj.Genre = $('#inputGenre :selected').val();
    obj.Birth = $('#inputBirth').val();
    obj.Role = { Id: $('#inputRole :selected').val() };
    obj.DepedentList = [];
    
    if (obj.Role.Id == "") {
        obj.Role.Id = 0;
    }

    var objString = JSON.stringify(obj)

    return objString;
}

function GoBack() {
    window.history.back();
}

function ShowSaveMessage(msg) {
    $.alert({
        title: 'Sucesso!',
        content: msg,
        type: 'green',
        theme: 'material',
        onClose: function () {
            GoBack();
        },
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

function OpenModal() {
    $("#ModalDependent").modal();
}

function CloseModal() {
    $("#ModalDependent").slideUp();  
}

function SaveDependent() {
    var name = $("#inputDependentName").val();

    if(ValidateDependent(name))
    {
        //salvar
    }    
}

function ValidateDependent(name) {
    if(name == "") {
        $.alert({
            title: 'Erro!',
            content: 'O campo nome é obrigatório.',
            type: 'red',
            theme: 'material'
        });

        return false;
    } else {
        return true;
    }
}