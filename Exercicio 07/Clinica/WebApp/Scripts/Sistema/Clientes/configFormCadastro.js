// FUNÇÕES JAVASCRIPT  ------------------------------------------------------------

// carrega formulário de alteração com os dados vindo do banco de dados
function loadFormAlterarCliente(codCliente) {

    abreLoading();

    $.ajax({
        type: "GET",
        url: "http://localhost:4444/api/Clientes/" + codCliente,
        dataType: "json",
        success: function (data) {

            // função que atualiza os inputs com os dados certos
            preencheInputsFormularioCliente(data);

            // fecha o loading
            fechaLoading();
        },
        error: function () {
            redirectWithMessageStatus("Cliente/lista", "erro", "O Cliente solicitado não existe.");

            // fecha o loading
            fechaLoading();
        }
    });
}

function preencheInputsFormularioCliente(data) {

    $("#CodCliente").val(data["CodCliente"]);
    $("#Nome").val(data["Nome"]);
    $("#Telefone").val(data["Telefone"]);
    $("#Celular").val(data["Celular"]);
    $("#CPF").val(data["CPF"]);
    $("#Sobrenome").val(data["Sobrenome"]);
    $("#Endereco").val(data["Endereco"]);
   
}

// configura a mascara para o campo telefone conforme for inserido tel celular ou fixo
function configMascaraTelefoneFixOuCelular(event) {
    var $element = $('#' + this.id);
    $(this).off('blur');
    $element.unmask();
    if (this.value.replace(/\D/g, '').length > 10) {
        $element.mask("(00) 00000-0000");
    } else {
        $element.mask("(00) 0000-00009");
    }
    $(this).on('blur', configMascaraTelefoneFixOuCelular);
}

function limpaDropDownListByIde(ideSelect) {
    $('#' + ideSelect)
        .find('option')
        .remove()
        .end()
        .append('<option value>-Selecione-</option>');
}

// CONFIGS Jquery
$(document).ready(function () {

    // MASCARAS INPUTS  ------------------------------------------------------------

    // Mascara CPF
    $("#CPF").mask("999.999.999-99");

    // Mascara Telefone Fixo ou Celular
    $('#Telefone').each(function (i, el) {
        $('#' + el.id).mask("(00) 00000-0000");
    });

    // Mascara dinâmica para telefone
    $('#Telefone').on('blur', configMascaraTelefoneFixOuCelular);


    // APLICA VALIDAÇÃO PARA CADASTRO DE Cliente  ------------------------------------------------------------
    $("#formularioAddRegistro").validate({
        // desativa a mesagem padrão (embaixo do input) para ser utilizado outra forma (lista de mensagens neste caso)
        errorPlacement: function (error, element) {
            var divListaErros = $('#lista-msgs-error').find('div');
            error.appendTo(divListaErros);
            error.addClass('alert alert-danger w-100');  // add a class to the wrapper
        },
        // configura classes de erro para o input e a label do input
        highlight: function (element) {
            $(element).parent().addClass("error");
            $(element).addClass("error");
        },
        unhighlight: function (element) {
            $(element).parent().removeClass("error");
            $(element).removeClass("error");
        },
        rules: {
            Nome: {
                required: true,
                minlength: 3,
                maxlength: 50
            },
            Celular: {
                required: true,
            },
            CPF: {
                required: true,
            },
            Endereco: {
                required: true
            },
            
        },
        messages: {
            Nome: {
                required: 'Informe o nome do Cliente',
                minlength: 'O nome deve conter no mínimo 10 caracteres',
                maxlength: 'O nome deve conter no máximo 50 caracteres',
                remote: 'Já existe um Cliente cadastrado com esse nome'
            },
            Sobrenome: {
                required: 'Informe o nome do Cliente',
                minlength: 'O nome deve conter no mínimo 10 caracteres',
                maxlength: 'O nome deve conter no máximo 50 caracteres',
                remote: 'Já existe um Cliente cadastrado com esse nome'
            },
            Celular: {
                required: 'Informe o número do telefone celular completo'
            },
            CPF: {
                required: 'Informe o CPF',
                remote: 'Já existe um Cliente cadastrado com esse CPF'
            },
            Endereco: {
                required: 'Informe o endereço completo'
            },
        },
        focusInvalid: true,
        submitHandler: function (form) {
            // serializa o formulário inteiro na variável data
            var data = $('#formularioAddRegistro').serializeArray();

            // abre o loading
            abreLoading();

            var CodCliente = $("#CodCliente").val();
            var typeForm = "POST";
            var msgPadraoSucesso = "Cliente cadastrado com sucesso.";
            var msgPadraoErro = "Erro ao tentar cadastrar Cliente.";
            var urlRetornoLista = "Clinica/Cliente/listar";
            var urlAPiActionForm = "http://localhost:4444/api/clientes/cadastrar";

            // Config CADASTRO ou ALTERAÇÃO
            if (CodCliente != undefined && CodCliente != null && CodCliente > 0) {
                typeForm = "PUT";
                msgPadraoSucesso = "Cliente alterado com sucesso.";
                msgPadraoErro = "Erro ao tentar alterar Cliente.";
                urlAPiActionForm = "http://localhost:4444/api/clientes/alterar/" + CodCliente;
            }

            // submete formulário (cadastro ou alteração)
            submitFormularioAddEdit(typeForm, urlAPiActionForm, data, urlRetornoLista, msgPadraoSucesso, msgPadraoErro);

        }
    });

});





