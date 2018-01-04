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
        
    //populate dependent list
    var trList = $('#tbodyDiv').children();
    
    for (var i = 0; i < trList.length; i++) {        
        var elem = trList[i];
        
        var id = elem.children[0].textContent == "-" ? 0 : elem.children[0].textContent;

        var Dependent = {
            Id: id,
            Name: elem.children[1].textContent,
            IdEmployee: obj.Id
        };

        obj.DepedentList.push(Dependent)
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
    $("#inputDependentName").val("");
    $('#ModalDependent').modal('toggle');
}

function SaveDependent() {
    var name = $("#inputDependentName").val();

    if(ValidateDependent(name))
    {
        CheckIfTableAlreadyExist();

        var htmlLine = "<tr><td>-</td><td>" + name + "</td>";
        htmlLine += "<td class='text-center'><button class='btn btn-danger btn-xs' title='Excluir' onclick='DeleteDependent(this)'>";
        htmlLine += "<i class='fa fa-times fa-4g'></i></button>";
        htmlLine += "</td></tr>"
        $( "#tbodyDiv" ).append(htmlLine);

        CloseModal();
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

function DeleteDependent(elem) {        
    elem.parentElement.parentElement.remove();   
}

function CheckIfTableAlreadyExist() {    
    var element = $("#originalTableDependentDiv")[0];

    var tableExist = element.children.length > 0 && element.children[0].localName != "span";

    if(!tableExist) 
    {
        var htmlTable = "<table class='table table-bordered table-striped table-hover'><thead class='thead-dark'><tr class='header-row'><th style='width: 10%'>Id</th><th style='width: 80%'>Nome</th><th style='width: 10%' class='text-center'>Ações</th></tr></thead><tbody id='tbodyDiv'></tbody></table>";
        $("#originalTableDependentDiv").html(htmlTable);
    }    
}

    
