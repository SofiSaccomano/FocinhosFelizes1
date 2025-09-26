let tamanhoFonte = 100; // percentual inicial (100% = tamanho padrão)

function aumentarFonte() {
    if (tamanhoFonte < 200) { // limite máximo de 200%
        tamanhoFonte += 10;
        document.body.style.fontSize = tamanhoFonte + "%";
    }
}

function diminuirFonte() {
    if (tamanhoFonte > 50) { // limite mínimo de 50%
        tamanhoFonte -= 10;
        document.body.style.fontSize = tamanhoFonte + "%";
    }
}


function toggleContraste() {
    document.body.classList.toggle("contraste");
}
