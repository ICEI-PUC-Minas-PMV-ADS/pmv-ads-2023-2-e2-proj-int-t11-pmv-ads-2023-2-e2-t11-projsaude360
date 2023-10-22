$(document).ready(function () {
    $('#frmConcluirCadastro').submit(function () {
        event.preventDefault();

        var inputs = []

        var cadastro = {
            nome: document.getElementById("nome").value,
            login: document.getElementById("login").value,
            genero: document.getElementById("genero").value,
            dataNascimento: document.getElementById("dataNascimento").value,
            email: document.getElementById("email").value,
            telefone: document.getElementById("telefone").value,
            senha: document.getElementById("senha").value
        }

        var nome = document.getElementById("nome").value;
        var login = document.getElementById("login").value;
        var genero = document.getElementById("genero").value;
        var dataNascimento = document.getElementById("dataNascimento").value;
        var email = document.getElementById("email").value;
        var telefone = document.getElementById("telefone").value;
        var senha = document.getElementById("senha").value;

        console.log(nome)

        if (nome != "" && nome != undefined) {
            inputs.push({ Id: nome });
        }
        if (login != "" && login != undefined) {
            inputs.push({ Id: login });
        }
        if (genero != "" && genero != undefined) {
            inputs.push({ Id: genero });
        }
        if (dataNascimento != "" && dataNascimento != undefined) {
            inputs.push({ Id: dataNascimento });
        }
        if (email != "" && email != undefined) {
            inputs.push({ Id: email });
        }
        if (telefone != "" && telefone != undefined) {
            inputs.push({ Id: telefone });
        }
        if (senha != "" && senha != undefined) {
            inputs.push({ Id: senha });
        }



        console.log("deu certo")

        $.ajax({
            url: "/Cadastro/Create?handler=teste",
            type: 'POST',
            headers: { RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() },
            contentType: 'application/json',
            dataType: 'json',
            //data: {
            //    login: "lucas",
            //},
            data: JSON.stringify(cadastro),
            beforeSend: function () {
                $('#frmConcluirCadastro input[type="submit"]').attr('disabled', true);
            },
            success: function () {
                $(location).attr('href', '../Index');
            },
            error: function (e) {
                $('#frmConcluirAtendimento input[type="submit"]').attr('disabled', false);
                alert("Erro ao cadastrar atendimento!")
                console.log(e.responseJSON)
                console.log(e);
            },
        });

    });
    
})

function criar() {
    console.log("qwqw")
}



