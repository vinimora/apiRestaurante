function inserirContato() {
    $.ajax({
        url: '/App/InserirContato',
        type: 'POST',

        data: {
            NOME: $('#formContato .NOME').val(),
            EMAIL: $('#formContato .EMAIL').val(),
            TELEFONE: $('#formContato .TELEFONE').val(),
            MENSAGEM: $('#formContato .MENSAGEM').val()
        },
    })
    .done(function () {
        alert("Itens inclusos com sucesso!");
        console.log("success");
    })
    .fail(function () {
        console.log("error");
    })
    .always(function () {
        console.log("complete");
    });
}