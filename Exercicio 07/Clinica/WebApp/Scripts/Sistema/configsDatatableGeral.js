﻿var datatableLanguagePTBR = {
    "sProcessing": "A processar...",
    "sLengthMenu": "Mostrar _MENU_ registros",
    "sZeroRecords": "Não foram encontrados resultados",
    "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
    "sInfoEmpty": "Mostrando de 0 até 0 de 0 registros",
    "sInfoFiltered": "(filtrado de _MAX_ registros no total)",
    "sInfoPostFix": "",
    "sSearch": "Procurar:",
    "sUrl": "",
    "oPaginate": {
        "sFirst": "Primeiro",
        "sPrevious": "Anterior",
        "sNext": "Seguinte",
        "sLast": "Último"
    }
}

function retornaStatusRegistro(data, tipo) {
    var badgeClass = "badge-success";

    if (data == "Desativado") {
        badgeClass = "badge-danger";
    }

    var status = data.slice(0, -1);

    status = tipo == '(a)' ? status + 'a' : status + 'o';

    return "<span class='badge " + badgeClass + "'>" + status + "</span>";
}