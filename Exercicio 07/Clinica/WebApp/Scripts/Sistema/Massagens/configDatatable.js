function carregaDatatable() {

    abreLoading();

    var url_api_lista_regristros = "http://localhost:50827/api/massagens";

    var urlCadastrar = 'agendar';

    // botões e html extra datatable
    var htmlElementosDatatable = '<div class="div-options-datatable">';
    htmlElementosDatatable += '<div><a class="dt-button btn btn-info btn-cadastrar-datatable" tabindex="0" aria-controls="massagens" href="' + urlCadastrar + '"><span><i class="far fa-calendar-alt"></i> Agendar Massagem</span></a></div>';

    // CONFIGURA DATATABLE DE massagens  ------------------------------------------------------------
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
                data: "Cliente",
                render: function (data, type, Cliente) {
                    return "<a href='/Clinica/Cliente/visualizar/" + data.CodCliente + "' >" + data.Nome + " " + data.Sobrenome + "</a>";
                }
            },
            {
                data: "DataHoraMassagem", // Data
                render: function (data, type, Cliente) {
                    var dataFormatada = formataPadraoData(data, 'pt-br');
                    return dataFormatada;
                }
            },
            {
                data: "DataHoraMassagem", // Hora
                render: function (data, type, Cliente) {
                    
                    return data.substr(11,5);
                }
            },
            {
                data: "Duracao"
            },
            {
                data: "CodMassagem",
                render: function (data, type, massagem) {
                    var botoes = "<a href='/Clinica/massagem/visualizar/" + data + "' class='btn btn-sm btn-warning js-edit' data-toggle='tooltip' data-placement='top' title='Visualizar'><i class='far fa-eye'></i></a> &nbsp;";
                    botoes += "<a href='/Clinica/massagem/reagendar/" + data + "' class='btn btn-sm btn-primary js-edit' data-toggle='tooltip' data-placement='top' title='Reagendar'><i class='far fa-calendar-check'></i></a> &nbsp;";

                    if (verificaSePodeCancelar(massagem['DataHoraMassagem'].substring(0, 10))) {
                        botoes += "<button data-codmassagem='" + data + "' class='btn btn-sm btn-danger js-bt-cancelarMassagem' data-status='excluir' data-toggle='tooltip' data-placement='top' title='Cancelar Massagem'><i class='fas fa-ban'></i></button>";
                    } else {
                        botoes += "<button data-codmassagem='" + data + "' class='btn btn-sm btn-danger disabled' data-status='excluir' data-toggle='tooltip' data-placement='top' title='Cancelar Massagem'><i class='fas fa-ban'></i></button>";
                    }
                    
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


function verificaSePodeCancelar(dataMassagemRef) {
    var dataAtual = Date.parse(new Date().toISOString().substring(0, 10));
    var dataMassagem = Date.parse(dataMassagemRef);
    var contaDifTempo = dataMassagem - dataAtual;
    var diffDias = Math.floor(contaDifTempo / (1000 * 60 * 60 * 24));
    return diffDias >= 1;
}

function carregarDadosMassagem(CodMassagem) {

    abreLoading();

    $.ajax({
        type: "GET",
        url: "http://localhost:50827/api/massagens/" + CodMassagem,
        dataType: "json",
        success: function (data) {

            var cliente = '<a href="/Clinica/Cliente/visualizar/' + data.Cliente.CodCliente +'">' + data.Cliente.Nome + ' ' + data.Cliente.Sobrenome  + '</a>';

            $("#Cliente").html(cliente);

            var dataFormatada = formataPadraoData(data.DataHoraMassagem, 'pt-br');

            $("#Data").html(dataFormatada);
            $("#Hora").html(data.DataHoraMassagem.substr(11, 5));
            $("#Duracao").html(data.Duracao);

            var botaoCancelar = '<button data-codmassagem="1" class="btn btn-danger disabled"><i class="fas fa-ban"></i> Cancelar </button>';

            if (verificaSePodeCancelar(data.DataHoraMassagem.substring(0, 10))) {
                botaoCancelar = '<button data-codmassagem="1" class="btn btn-danger js-bt-cancelarMassagem"><i class="fas fa-ban"></i> Cancelar </button>';
            }

            $("#btCancelarMassagem").html(botaoCancelar);

            // fecha o loading
            fechaLoading();
        },
        error: function () {
            redirectWithMessageStatus("Clinica/massagem/listar", "erro", "A massagem solicitado não existe.");

            // fecha o loading
            fechaLoading();
        }
    });

}

// CONFIGS Jquery
$(document).ready(function () {

    $(".datatable, #funcoes-massagem").on("click", ".js-bt-cancelarMassagem", function () {

        var btAtivarDesativar = $(this);

        var status = $(this).attr("data-status");

        var msgRetorno = "cancelada";

        bootbox.confirm({
            message: "Você realmente deseja <b>cancelar</b> este massagem?",
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

                    var CodMassagem = btAtivarDesativar.data("codmassagem");


                    $.ajax({
                        url: "http://localhost:50827/api/massagens/cancelar/" + CodMassagem,
                        method: "PUT",
                        success: function () {

                            // caso não seja a ação vindo do datatable (vir da pagina visualizar)
                            if (btAtivarDesativar.closest("tr").length == 0) {
                                redirectWithMessageStatus("Clinica/massagem/Listar", "sucesso", "Massagem " + msgRetorno + " com sucesso.");
                            } else {
                                btAtivarDesativar.closest("tr").remove();
                            }


                            // fecha o loading
                            fechaLoading();

                            toastr.success("Massagem " + msgRetorno + " com sucesso.");
                        },
                        error: function () {
                            toastr.error("Houve algum erro ao tentar excluir esta massagem.");

                            // fecha o loading
                            fechaLoading();
                        }
                    });
                }
            }
        });
    });
});