// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var tabela = $('#tabelaLoot').DataTable({

        'aoColumnDefs': [{
            'bSortable': false,
            'aTargets': ['nosort']
        }],
        "order": [],
        "processing": true,
        "orderClasses": false,
        "oLanguage": {

        }
    });


});

$(document).ready(function () {
    $('#tabelaLootsBoss').DataTable({

        'aoColumnDefs': [{
            'bSortable': false,
            'aTargets': ['nosort']
        }],
        "order": [],
        "processing": true,
        "oLanguage": {
         
        }
    });

});

$(document).ready(function () {
    $('#tabelaLootQuantidade').DataTable({

        'aoColumnDefs': [{
            'bSortable': false,
            'aTargets': ['nosort']
        }],
        "order": [],
        "processing": true
    });

});


$(document).ready(function () {
    $('#tabelaBossQuantidade').DataTable({

        'aoColumnDefs': [{
            'bSortable': false,
            'aTargets': ['nosort']
        }],
        "order": [],
        "processing": true
    });

});



$(document).ready(function () {
    $('#tabelaLootQuantidadeBoss').DataTable({

        'aoColumnDefs': [{
            'bSortable': false,
            'aTargets': ['nosort']
        }],
        "order": [],
        "processing": true
    });

});

$(document).ready(function () {
    $('#tabelaPlayerTop').DataTable({

        'aoColumnDefs': [{
            'bSortable': false,
            'aTargets': ['nosort']
        }],
        "order": [],
        "processing": true
    });

});


$(document).ready(function () {

   
}
);



