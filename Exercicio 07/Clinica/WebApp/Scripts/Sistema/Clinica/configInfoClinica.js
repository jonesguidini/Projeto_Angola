function carregaInfoClinica() {

    abreLoading();

    var codClinica = 1; // *MOCK

    $.ajax({
        type: "GET",
        url: "http://localhost:4444/api/clinicas/1",
        dataType: "json",
        success: function (data) {

            $("#RazaoSocial").html(data.RazaoSocial);
            $("#CNPJ").html(data.CNPJ);
            $("#Telefone").html(data.Telefone);
            $("#Endereco").html(data.Endereco);

            // fecha o loading
            fechaLoading();
        },
        error: function (data) {

            fechaLoading();
        }
    });
}


function carregaDatatable() {

    abreLoading();

    var url_api_lista_regristros = "http://localhost:4444/api/clientes";

    var urlCadastrar = 'cadastrar';

    // botões e html extra datatable
    var htmlElementosDatatable = '<div class="div-options-datatable">';
    htmlElementosDatatable += '<div><a class="dt-button btn btn-info btn-cadastrar-datatable" tabindex="0" aria-controls="clientes" href="' + urlCadastrar + '"><span><i class="fas fa-plus-circle"></i> Cadastrar</span></a></div>';
    //htmlElementosDatatable += '<div class="bt-regs-desativado"> <span class="switch switch-sm"><input type="checkbox" class="switch" id="checkbox-mostrar-registros-desativados" _statusCheckbox_><label for="checkbox-mostrar-registros-desativados">MOSTRAR REGISTROS DESATIVADOS</label></span></div>';


    // CONFIGURA DATATABLE DE clienteS  ------------------------------------------------------------
    var datatable = $(".datatable").DataTable({
        "language": datatableLanguagePTBR,
        dom: '<"toggleStatus">frtip',
        destroy: true,
        "initComplete": function (settings, json) {
            fechaLoading();
        },
        ajax: {
            url: url_api_lista_regristros,
            dataSrc: ""
        },
        columns: [
            {
                data: "Nome",
                render: function (data, type, cliente) {
                    return "<a href='/Clinica/cliente/visualizar/" + cliente.CodCliente + "' >" + resumirTexto(cliente.Nome + " " + cliente.Sobrenome, 50) + "</a>";
                }
            },
            {
                data: "CPF"
            },
            {
                data: "Telefone"
            },
            {
                data: "Celular"
            },
            {
                data: "CodCliente",
                render: function (data, type, cliente) {
                    var botoes = "<a href='/Clinica/cliente/visualizar/" + data + "' class='btn btn-sm btn-warning js-edit'   data-toggle='tooltip' data-placement='top' title='Visualizar'><i class='far fa-eye'></i></a> &nbsp;";
                    botoes += "<a href='/Clinica/cliente/alterar/" + data + "' class='btn btn-sm btn-info js-edit'   data-toggle='tooltip' data-placement='top' title='Editar'><i class='fas fa-edit'></i></a> &nbsp;";
                    botoes += "<button data-CodCliente='" + data + "' class='btn btn-sm btn-danger js-bt-ativardesativar' data-status='excluir' data-toggle='tooltip' data-placement='top' title='Excluir'><i class='far fa-trash-alt'></i></button>";

                    return botoes;
                }
            }
        ],
        columnDefs: [
            {
                className: "align-center",
                targets: [1, 2, 3, 4]
            }
        ]
    });


    // adiciona os elementos html na datatable
    $("div.toggleStatus").html(htmlElementosDatatable);
}

function carregarDadosCliente(codCliente) {
    
    abreLoading();

    $.ajax({
        type: "GET",
        url: "http://localhost:4444/api/clientes/" + codCliente,
        dataType: "json",
        success: function (data) {

            $("#NomeCliente").html(data.Nome + " " + data.Sobrenome);
            $("#CPFCliente").html(data.CPF);
            $("#TelefoneCliente").html(data.Telefone);
            $("#CelularCliente").html(data.Celular);
            $("#EnderecoCliente").html(data.Endereco);

            // fecha o loading
            fechaLoading();
        },
        error: function () {
            redirectWithMessageStatus("Clinica/cliente/listar", "erro", "O cliente solicitado não existe.");

            // fecha o loading
            fechaLoading();
        }
    });

}

// CONFIGS Jquery
$(document).ready(function () {

    $(".datatable, #funcoes-cliente").on("click", ".js-bt-ativardesativar", function () {
        var btAtivarDesativar = $(this);

        var status = $(this).attr("data-status");

        var msgRetorno = "excluído";

        bootbox.confirm({
            message: "Você realmente deseja <b>excluir</b> este cliente?",
            buttons: {
                cancel: {
                    label: '<i class="fa fa-times"></i> Não',
                    className: 'btn-danger'
                },
                confirm: {
                    label: '<i class="fa fa-check"></i> Sim',
                    className: 'btn-success'
                }
            },
            callback: function (result) {
                if (result) {

                    // abre o loading
                    abreLoading();

                    var CodCliente = btAtivarDesativar.data("codcliente");

                    $.ajax({
                        url: "http://localhost:4444/api/clientes/excluir/" + CodCliente,
                        method: "PUT",
                        success: function () {

                            // caso não seja a ação vindo do datatable (vir da pagina visualizar)
                            if (btAtivarDesativar.closest("tr").length == 0) {
                                redirectWithMessageStatus("Clinica/Cliente/Listar", "sucesso", "Cliente " + msgRetorno + " com sucesso.");
                            } else {
                                btAtivarDesativar.closest("tr").remove();
                            }


                            // fecha o loading
                            fechaLoading();

                            toastr.success("Cliente " + msgRetorno + " com sucesso.");
                        },
                        error: function () {
                            toastr.error("Houve algum erro ao tentar excluir o cliente.");

                            // fecha o loading
                            fechaLoading();
                        }
                    });
                }
            }
        });
    });
});