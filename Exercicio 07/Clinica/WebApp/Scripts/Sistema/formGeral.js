// FUNÇÕES JAVASCRIPT

// Limpa formulário (lista de erros)
function cleanForm() {
    $("#lista-msgs-error > div").children().each(function (e) {
        $(this).remove();
    });
}

// remove todos espaços
function removeEspacos(texto) {
    if (texto.value.match(/\s/g)) {
        texto.value = texto.value.replace(/\s/g, '');
    }
}

function removeAcentos(str) {

    // Converte o texto para caixa baixa:
    str = str.toLowerCase();

    // Remove qualquer caractere em branco do final do texto:
    str = str.replace(/^\s+|\s+$/g, '');

    // Lista de caracteres especiais que serão substituídos:
    const from = "ãàáäâẽèéëêìíïîõòóöôùúüûñç·/_,:;";

    // Lista de caracteres que serão adicionados em relação aos anteriores:
    const to = "aaaaaeeeeeiiiiooooouuuunc------";

    // Substitui todos os caracteres especiais:
    for (let i = 0, l = from.length; i < l; i++) {
        str = str.replace(new RegExp(from.charAt(i), 'g'), to.charAt(i));
    }

    // Remove qualquer caractere inválido que possa ter sobrado no texto:
    str = str.replace(/[^a-z0-9 -]/g, '');

    // Substitui os espaços em branco por hífen:
    str = str.replace(/\s+/g, '-');

    return str;
};


// Limpar o formulário por completo
function limparFormularioCadastro() {
    // clean error messages
    cleanForm();

    if ($("#formularioAddRegistro").length > 0) {
        // chama função que limpa todas validações
        $("#formularioAddRegistro").clearValidation();

        // limpar todos campos do formulário
        $("#formularioAddRegistro")[0].reset();
    }

}

// Submete formulário para cadastro ou alteração de algum registro
// Parâmetros:
// typeForm = informa o tipo do evento (POST, GET etc...)
// urlAPiActionForm = Informa a url da ação na API exemplo 'api/delegados'
// data = Dados do formulário serializado em jSON
// urlRetornoLista = Url que redirecionará após a ação de sucesso ou erro
// msgPadraoSucesso =  Mensagem padrão em caso de sucesso (toast message)
// msgPadraoErro =  Mensagem padrão em caso de erro (toast message)
function submitFormularioAddEdit(typeForm, urlAPiActionForm, data, urlRetornoLista, msgPadraoSucesso, msgPadraoErro, callbackFunction = null) {

    $.ajax({
        type: typeForm,
        url: urlAPiActionForm,
        data: data,
        dataType: "json",
        success: function (data, textStatus, XMLHttpRequest) {


            var location = XMLHttpRequest.getResponseHeader('Location');

            if (location != null) {
                urlRetornoLista = location;
            }

            //executa função callback
            if (callbackFunction != null) {
                callbackFunction(data);
            }

            limparFormularioCadastro();
            redirectWithMessageStatus(urlRetornoLista, "sucesso", msgPadraoSucesso);
        },
        error: function () {
            //toastr.error("Erro ao tentar cadastrar delegado.");
            redirectWithMessageStatus(urlRetornoLista, "erro", msgPadraoErro);

            // fecha o loading
            fechaLoading();
        }
    });
}

// CONFIGS JQUERY
$(document).ready(function () {

    // aplica validação a todos campos e select conforme o evento keypress
    $("input, select").on("keypress", function () {
        $(this).validate();
    });

    // MÉTODOS CREADOS PARA VALIDAÇÃO DOS FORMULÁRIOS UTILIZANDO JQUERY VALIDADE ------------------------------------------------------------

    // função para limpar todas validações
    // reF= https://stackoverflow.com/questions/2086287/how-to-clear-jquery-validation-error-messages
    $.fn.clearValidation = function () {
        var v = $(this).validate();
        $('[name]', this).each(function () {
            v.successList.push(this);
            v.showErrors();
        });
        v.resetForm();
        v.reset();
    };

    // valida data informada no padrão PT-BR
    $.validator.addMethod("validaDatePtBr", function (value, element) {
        if (value != "") {
            if (value.length != 10) return false;
            // verificando data
            var data = value;
            var dia = data.substr(0, 2);
            var barra1 = data.substr(2, 1);
            var mes = data.substr(3, 2);
            var barra2 = data.substr(5, 1);
            var ano = data.substr(6, 4);
            if (data.length != 10 || barra1 != "/" || barra2 != "/" || isNaN(dia) || isNaN(mes) || isNaN(ano) || dia > 31 || mes > 12) return false;
            if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && dia == 31) return false;
            if (mes == 2 && (dia > 29 || (dia == 29 && ano % 4 != 0))) return false;
            if (ano < 1900) return false;
        }
        return true;
    }, "Informe uma data válida");  // Mensagem padrão


    // valida CPF
    $.validator.addMethod("cpfValido", function (value, element) {
        value = jQuery.trim(value);

        value = value.replace('.', '');
        value = value.replace('.', '');
        cpf = value.replace('-', '');
        while (cpf.length < 11) cpf = "0" + cpf;
        var expReg = /^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$/;
        var a = [];
        var b = new Number;
        var c = 11;
        for (i = 0; i < 11; i++) {
            a[i] = cpf.charAt(i);
            if (i < 9) b += (a[i] * --c);
        }
        if ((x = b % 11) < 2) { a[9] = 0 } else { a[9] = 11 - x }
        b = 0;
        c = 11;
        for (y = 0; y < 10; y++) b += (a[y] * c--);
        if ((x = b % 11) < 2) { a[10] = 0; } else { a[10] = 11 - x; }

        var retorno = true;
        if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10]) || cpf.match(expReg)) retorno = false;

        return this.optional(element) || retorno;

    }, "Informe um CPF válido");


    // valida se valor passado é um arrayVazio
    $.validator.addMethod("validaUfsPreenchidas", function (value, element) {
        if (value === "[]") {
            return false;
        }
        return true;
    }, "Informe pelo menos uma UF");  // Mensagem padrão

    // ação de salvar registro após clicar no botão
    $("#btSalvaRegistro").on("click", function () {
        var validator = $('#formularioAddRegistro').validate();

        if (!$('#formularioAddRegistro').valid()) {
            // coloca o foco no primeiro campo inválido
            $("#formularioAddRegistro").find("input.error").first().focus();
        } else {
            // submete o formulário
            $('#formularioAddRegistro').submit();
        }
    });

});

