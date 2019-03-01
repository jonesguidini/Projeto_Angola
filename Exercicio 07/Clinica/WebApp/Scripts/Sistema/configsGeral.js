// função responsável por abrir o loading (pagina inteira)
function abreLoading() {
    $.LoadingOverlay("show", {
        image: "",
        fontawesome: "fas fa-spinner fa-spin",
        size: 4,
        fontawesomeAnimation: "2000ms rotate_right",
        fontawesomeAutoResize: true,
        fontawesomeResizeFactor: 2,
        fontawesomeOrder: 5,
        fontawesomeColor: "#368ad8",
        backgroundClass: "custom_background",
    });
}

// função responsável por fechar o loading (pagina inteira)
function fechaLoading() {
    $.LoadingOverlay("hide");
}

// redirecionador de página com mensagem de status para ser apresentada via Toast Messages
function redirectWithMessageStatus(url, tipoMsg, mensagem) {
    $.ajax({
        type: "POST",
        data: { tipoMsg: tipoMsg, mensagem: mensagem },
        url: "/custom/AtribuiMensagemStatus",
        dataType: "json",
        success: function (data) {

            window.location.href = data + url;

            // fecha o loading
            // fechaLoading();
        },
        error: function () {
            toastr.error("Erro ao tentar carregar dados.");

            // fecha o loading
            fechaLoading();
        }
    });
}

// carrega mensagem toast geral se houver
function CarregaMensagemToastGeral(status, mensagem) {
    if (status != null && mensagem != null) {
        if (status == "erro") {
            toastr.error(mensagem);
        } else if (status == "sucesso") {
            toastr.success(mensagem);
        }
    }
}

// Formata data informada em formato string e PT para formato padrão
// Parâmetros:
// Data = Data informada
// formato = formato de retorno da data 'pt-br' ou 'null'(em branco) que retornará padrão internacional
function formataPadraoData(data, formato) {
    if (formato == 'pt-br') {
        return (data.substr(0, 10).split('-').reverse().join('/'));
    } else {
        return (data.substr(0, 10).split('/').reverse().join('-'));
    }
}

// atribui retorno para a ultima pagina carregada através do link voltar
function voltarPaginaAnterior() {
    window.history.back();
}

// resumir texto e colocar '...' ao final do tamanho do texto
function resumirTexto(str, size) {
    if (str == undefined || str == 'undefined' || str == '' || size == undefined || size == 'undefined' || size == '') {
        return str;
    }

    var shortText = str;
    if (str.length >= size + 3) {
        shortText = str.substring(0, size).concat('...');
    }
    return shortText;
}   

$(document).ready(function () {

    // habilita tooltip em todas páginas
    $('body').tooltip({ selector: '[data-toggle="tooltip"]' });

    $(document).on("focus", ".datepicker", function () {
        $(this).datepicker({
            language: 'pt-BR',
            orientation: 'bottom',
            todayHighlight: true
        });
    });


    // FUNÇÃO QUE FORÇA CAMEL CASE PARA NOMES EXAMPLE: 'Carlos Alberto'
    String.prototype.toProperCase = function () {
        var arr = this.toLowerCase().split(' ');
        for (var i = 0; i < arr.length; i++) {
            arr[i] = arr[i].charAt(0).toUpperCase() + arr[i].substr(1);
        };
        return arr.join(' ');
    };

    // aplica captalize para os inputs com classe '.capitalize'
    $(".capitalize").on("change", function () {
        var valBase = $(this).val().toProperCase();
        $(this).val(valBase);
    });

});