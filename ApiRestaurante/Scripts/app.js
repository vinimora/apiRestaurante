
function restartEvents() {
    $(".item-pedido .produto").off('click');
    $(".item-pedido .produto").on('click', function () {
        linha = $(this);
        id = $(linha).find('[campo="id"]').html();
        nome = $(linha).find('[campo="nome"]').html();
        preco = $(linha).find('[campo="preco"]').html();
        console.log(id);
        console.log(nome);
        console.log(preco);
        newitem = $(linha);
        $(linha).remove();
        $(newitem).insertBefore("#tabela-itens-pedido .total-line");
        calcTotal();
        restartEvents();
    });
    $("#tabela-itens-pedido .produto").off('click');
    $("#tabela-itens-pedido .produto").on('click', function () {
        linha = $(this);
        id = $(linha).find('[campo="id"]').html();
        nome = $(linha).find('[campo="nome"]').html();
        preco = $(linha).find('[campo="preco"]').html();
        console.log(id);
        console.log(nome);
        console.log(preco);
        newitem = $(linha);
        $(linha).remove();
        tipinho = $(linha).attr("tipo");
        $(newitem).appendTo(".item-pedido[tipo='" + tipinho + "'] tbody");
        calcTotal();
        restartEvents();
    });
}
restartEvents();

function calcTotal() {
    if ($("#tabela-itens-pedido .produto").length > 0) {
        $("#tabela-itens-pedido .sem-itens").hide();
        $("#tabela-itens-pedido .total-line").show();
        somatotal = 0;
        $("#tabela-itens-pedido .produto [campo=preco]").each(function () {
            somatotal += parseFloat(convertVirgula($(this).html()));
        });
        $("#tabela-itens-pedido .total-line .total").html(convertVirgula(parseFloat(Math.round(somatotal * 100) / 100).toFixed(2) )) ;
    }
    else {
        $("#tabela-itens-pedido .total-line").hide();
        $("#tabela-itens-pedido .sem-itens").show();
    }
}

function convertVirgula(str) {
    return str.replace(",", ".");
}

function montaItemsObj() {
    arrayITems = [];
    $("#tabela-itens-pedido .produto").each(function () {
        linha = $(this);
        id = $(linha).find('[campo="id"]').html();
        nome = $(linha).find('[campo="nome"]').html();
        preco = $(linha).find('[campo="preco"]').html();
        console.log(id);
        console.log(nome);
        console.log(preco);

        arrayITems.push({
            "id": id,
            "nome": nome,
            "valor": preco,
            "quantidade": 1
        });
    });
    return arrayITems;
}
function inserirPedido() {
    $.ajax({
        url: '/App/InserirPedido',
        type: 'POST',

        data: {
            itens: montaItemsObj(),
            idmesa: $("#slcMesa").val()
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

