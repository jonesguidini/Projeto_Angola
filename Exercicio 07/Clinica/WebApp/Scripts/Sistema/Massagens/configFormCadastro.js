// FUNÇÕES JAVASCRIPT  ------------------------------------------------------------

function verificaSePodeAdicionarNovaMassagem() {
    var valorAtual = $(".horario_principal").val();

    return (valorAtual != "" && valorAtual == "30");
}

function adicionarNovoAgendamento() {

    if (verificaSePodeAdicionarNovaMassagem()) {
        $('.button-add-massagem').parent().parent().addClass('hide');
        var contador = parseInt($('#contador').val()) + 1;
        var html = '<div class="agendamento"><hr class="hr-div-info"><div class="row"><div class="col-lg-2"><div class="form-group"><label for="Data" class="required">Data</label><input type="text" name="Data[' + contador + ']" class="form-control datepicker input_data" id="Data" placeholder="__/__/____"></div></div><div class="col-lg-2"><div class="form-group"><label for="Hora" class="required">Horário</label><select class="form-control input_hora" id="HoraLista" name="Hora[' + contador + ']"><option value="">-Selecione-</option><option value="08:00">08:00</option><option value="08:30">08:30</option><option value="09:00">09:00</option><option value="09:30">09:30</option><option value="10:00">10:00</option><option value="10:30">10:30</option><option value="11:00">11:00</option><option value="11:30">11:30</option><option value="12:00">12:00</option><option value="12:30">12:30</option><option value="13:00">13:00</option><option value="13:30">13:30</option><option value="14:00">14:00</option><option value="14:30">14:30</option><option value="15:00">15:00</option><option value="15:30">15:30</option><option value="16:00">16:00</option><option value="16:30">16:30</option><option value="17:00">17:00</option></select></div></div><div class="col-lg-2"><div class="form-group"><label for="Duracao" class="Duracao required">Duração (minutos)</label> <br /> <select class="form-control input_duracao" id="HoraLista" name="Duracao[' + contador +']"><option value="30">30</option></select></div></div><div class="col-lg-2"><div class="form-group"><button class="btn btn-danger button-remove-massagem" onclick="removerNovaMassagem()" type="button"><i class="fas fa-times"></i></button></div></div></div></div>';
        $('#outros_agendamentos').append(html);
        $('#contador').val(contador);
    }
}

function verificaHorarioAgendamento() {
    var valorAtual = $(".horario_principal").val();
    if (verificaSePodeAdicionarNovaMassagem()) {
        $(".button-add-massagem").removeClass("disabled");
    } else {
        $(".button-add-massagem").addClass("disabled");
    }
}

function removerNovaMassagem() {
    $(".button-remove-massagem").parent().parent().parent().parent().remove();
    $('.button-add-massagem').parent().parent().removeClass('hide');
    $(".horario_principal").removeAttr("disabled");
    var contador = parseInt($('#contador').val());
    $('#contador').val(contador - 1);
}

function carregarFormularioAgendamento() {

    abreLoading();

    // carrega lista de clientes
    $.ajax({
        type: "GET",
        url: "http://localhost:4444/api/massagens/retornaListaClientes",
        dataType: "json",
        success: function (data) {

            // cria lista de options através da lista de dados (DATA)
            for (var key in data) {
                var o = new Option(key, key);
                $(o).html(data[key]);
                $("#CodClienteList").append(o);
            }

            // fecha o loading
            fechaLoading();
        },
        error: function () {
            CarregaMensagemToastGeral('erro', 'Houve algum problema ao trazer a lista de clientes');

            // fecha o loading
            fechaLoading();
        }
    });

    //carrega lista de horários
    $.ajax({
        type: "GET",
        url: "http://localhost:4444/api/massagens/horariospossiveis",
        dataType: "json",
        success: function (data) {

            // cria lista de options através da lista de dados (DATA)
            for (var key in data) {
                var o = new Option(key, key);
                $(o).html(data[key]);
                $("#HoraLista").append(o);
            }

            // fecha o loading
            fechaLoading();
        },
        error: function () {
            CarregaMensagemToastGeral('erro', 'Houve algum problema ao trazer a lista de horários para agendamento');

            // fecha o loading
            fechaLoading();
        }
    });
}


function configuraFormReagendamentoMassagem(codMassagem) {
    // carrega lista de clientes
    $.ajax({
        type: "GET",
        url: "http://localhost:4444/api/massagens/" + codMassagem,
        dataType: "json",
        success: function (data) {

            $("#CodClienteList").val(data["CodCliente"]);

            var dataFormatada = formataPadraoData(data.DataHoraMassagem, 'pt-br');
            $("#Data").val(dataFormatada);
            $("#HoraLista").val(data.DataHoraMassagem.substr(11, 5));

            if (data["Duracao"] == 30) {
                $("#Duracao30").prop('checked', true);
            } else {
                $("#Duracao60").prop('checked', true);
            }

            // fecha o loading
            fechaLoading();
        },
        error: function () {
            CarregaMensagemToastGeral('erro', 'Houve algum problema ao trazer a lista de clientes');

            // fecha o loading
            fechaLoading();
        }
    });
}

function limpaDropDownListByIde(ideSelect) {
    $('#' + ideSelect)
        .find('option')
        .remove()
        .end()
        .append('<option value>-Selecione-</option>');
}

function formataDataHora(data, hora) {
    var dataRef = data.split("/");
    var novaData = dataRef[2] + "-" + dataRef[1] + "-" + dataRef[0];
    var horaRef = hora.split(":");
    var novaHora = horaRef[0] + ":" + horaRef[1] + ":00";
    return novaData + "T" + novaHora;
}

// CONFIGS Jquery
$(document).ready(function () {

    // MASCARAS INPUTS  ------------------------------------------------------------
    $('form#formularioAddRegistro').on('submit', function (event) {
        $('#CodClienteList').each(function () {
            $(this).rules("add",
                {
                    required: true,
                    messages: {
                        required: "Selecione um cliente"
                    }
                });
        });

        //Add validation rule for dynamically generated name fields
        $('.input_data').each(function () {
            $(this).rules("add",
                {
                    required: true,
                    messages: {
                        required: "Informe a data"
                    }
                });
        });
        //Add validation rule for dynamically generated email fields
        $('.input_hora').each(function () {
            $(this).rules("add",
                {
                    required: true,
                    messages: {
                        required: "Informe a hora"
                    }
                });
        });

        //Add validation rule for dynamically generated email fields
        $('.input_duracao').each(function () {
            $(this).rules("add",
                {
                    required: true,
                    messages: {
                        required: "Informe a duração",
                    }
                });
        });
    });

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
        focusInvalid: true,
        submitHandler: function (form) {

            // serializa o formulário inteiro na variável data
            var data = $('#formularioAddRegistro').serializeArray();
            var codCliente = $("#CodClienteList").val();
            var tempoMassagem = 0;
            var codMassagem = $("#CodMassagem").val();

            // Config CADASTRO ou ALTERAÇÃO
            if (codMassagem != undefined && codMassagem != null && codMassagem > 0) {
                var urlRetornoLista = "Clinica/Massagem/listar";
                var typeForm = "PUT";
                var msgPadraoSucesso = "Massagem reagendada com sucesso.";
                var msgPadraoErro = "Erro ao tentar reagendar massagem.";
                var urlAPiActionForm = "http://localhost:4444/api/massagens/reagendar/" + codCliente;

                data = data[0];

                // submete formulário (cadastro ou alteração)
                submitFormularioAddEdit(typeForm, urlAPiActionForm, data, urlRetornoLista, msgPadraoSucesso, msgPadraoErro);

            } else {

                $.ajax({
                    type: "GET",
                    url: "http://localhost:4444/api/massagens/validaTempoMassagemCliente/" + codCliente + "/" + tempoMassagem,
                    dataType: "json",
                    success: function (result) {

                        if (result == false) {
                            CarregaMensagemToastGeral('erro', 'Este cliente já tem uma hora e meia de massagem para este mês.');
                        }
                        else {

                            // serializa o formulário inteiro na variável data
                            var data = $('#formularioAddRegistro').serializeArray();

                            var obj = [
                                {
                                    "CodCliente": 2,
                                    "CodMassagem": 0,
                                    "DataHoraMassagem": formataDataHora(data[2]["value"], data[3]["value"]),
                                    "Duracao": data[4]["value"]
                                }
                            ];

                            if (data[5] != undefined) {
                                var massagemB = {
                                    "CodCliente": 2,
                                    "CodMassagem": 0,
                                    "DataHoraMassagem": formataDataHora(data[5]["value"], data[6]["value"]),
                                    "Duracao": data[7]["value"]
                                };
                                obj.push(massagemB);
                            }


                            data = obj;

                            var codCliente = $("#CodClienteList").val();
                            var typeForm = "POST";
                            var msgPadraoSucesso = "Massagem agendada com sucesso.";
                            var msgPadraoErro = "Erro ao tentar agendar massagem.";
                            var urlRetornoLista = "Clinica/Massagem/listar";
                            var urlAPiActionForm = "http://localhost:4444/api/massagens/agendar";


                            var codMassagem = $("#CodClienteList").val();

                            // submete formulário (cadastro ou alteração)
                            submitFormularioAddEdit(typeForm, urlAPiActionForm, data, urlRetornoLista, msgPadraoSucesso, msgPadraoErro);
                        }

                    },
                    error: function () {
                        CarregaMensagemToastGeral('erro', 'Houve algum erro ao agendar/reagendar essa massagem');
                    }
                });


            }

        }
    });
});