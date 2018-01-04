function Save() {
    $.alert({
        title: 'Sucesso!',
        content: 'Funcionário salvo com sucesso!',
        type: 'green',
        theme: 'material',
        onDestroy: function () {
            GoBack();
        },
    });    
}

function GoBack() {
    window.history.back();
}