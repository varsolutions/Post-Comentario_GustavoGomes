document.querySelector("body").onkeyup = (envet) => {
    ContandoCaracteres()
};

$(document).ready(function () {
    var html = "";
    $.ajax({
        url: "http://localhost:51853/Comentario/postagens",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            for (var i = 0; i < response.length; i++) {
                html +=
                    '<div class="postagens" id="postagens">' +
                    '<div class="informacao">' +
                    '<p class="name" id="name">@' + response[i].usuario + '</p>' +
                    '<p class="date" id="date">' + response[i].data + '</p>' +
                    '</div>' +
                    '<div class="conteudo" id="conteudo">' +
                    '<p>' +
                    response[i].comentario +
                    '</p>' +
                    '</div>' +
                    '</div>';

            }
            $("#Comentario").first().after(html)

        },
        error: function (request, message, error) {
            console.log(error, message);
        }


    })
});



function ContandoCaracteres() {
    var comentario = $('#comentario').val();
    var caracter = document.getElementById("caracter")

    if (comentario.trim().length >= 1) {
        document.getElementById("caracter").innerText = comentario.length
        if (comentario.length >= 2201) {
            caracter.style.color = "red"

        }
        else {
            caracter.style.color = "#797979de"
        }
    }
    else {
        document.getElementById("caracter").innerText = 0

    }


}

function publicar() {
    var comentario = $('#comentario').val();
    var comentarioEspacoes = comentario.trim().length
    var Usuario = $('#Username').val()
    

    // validando se o usuario colocou só espaços ou deixou vazio o seu comentário
    if (comentario >= 1 || comentarioEspacoes >= 1) {


        if (comentario.trim().length >= 15 || comentarioEspacoes >= 15) {

            if (comentario.length <= 2200) {
                if(comentario.trim().length >= 4){

                    var request = {
                        "usuario": $("#Username").val(),
                        "comentario": $("#comentario").val()
                    }
    
                    $.ajax({
                        url: "http://localhost:51853/comentario",
                        type: "POST",
                        data: JSON.stringify(request),
                        contentType: "application/json",
                        success: function (response) {
                            alert("Comentario Publicado com sucesso")
                            window.location.href = "index.html"
    
                        },
                        error: function (request, message, error) {
                            alert("Estamos com um problema em nosso sistema. Tente mais tarde.")
                        }
                    })
                }
            }
            else {
                alert("digite um cometário de no maximo 2200 carateres")
            }
        }
        else {
            alert("digite um cometário de no minimo 15 carateres")
        }
    }
    else {
        alert("Digite seu comentário")
    }
}



