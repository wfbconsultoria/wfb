//Funções Gerais - aplicaveis a todas as páginas

//Mácara de entrada
function Mascara_Entrada(src, mask) {
    var i = src.value.length;
    var saida = mask.substring(0, 1);
    var texto = mask.substring(i)
    if (texto.substring(0, 1) != saida) {
        src.value += texto.substring(0, 1);
    }
}

//Permite digitar somente numeros
function Digitar_Numeros(num) {
    if (document.all)
        var tecla = event.keyCode;
    else if (document.layers)
        var tecla = num.which;
    if (tecla > 47 && tecla < 58)
        return true;
    else {
        if (tecla != 8)
            event.keyCode = 0;
        else
            return true;
    }
}

//Mácara de data
function Formatadata(Campo, teclapres) {
    var tecla = teclapres.keyCode;
    var vr = new String(Campo.value);
    vr = vr.replace("/", "");
    vr = vr.replace("/", "");
    vr = vr.replace("/", "");
    tam = vr.length + 1;
    if (tecla != 8 && tecla != 8) {
        if (tam > 0 && tam < 2)
            Campo.value = vr.substr(0, 2);
        if (tam > 2 && tam < 4)
            Campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 4);
        if (tam > 4 && tam < 6)
            Campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 4) + '/' + vr.substr(4, 8);
    }
}

//abre janelas pop up
function Abrir_PopUp(URL, width, height, top, left) {
    window.open(URL, 'janela', 'width=' + width + ', height=' + height + ', top=' + top + ', left=' + left + ', scrollbars=yes, status=no, toolbar=no, location=no, directories=no, menubar=no, resizable=no, fullscreen=no');
}

//VALIDA CEP
function validaCEP(c) {
    var CEP
    CEP = c.value.replace(/\D+/g, '');

    if (CEP.length != 8) {
        alert('formato co CEP inválido');
        c.value = '';
        return false;
    }
}

//VALIDA cnpj
function validaCNPJ(c) {

    var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais, cnpj = c.value.replace(/\D+/g, '');
    digitos_iguais = 1;
    if (cnpj.length != 14) {
        alert('CNPJ inválido');
        c.value = '';

        return false;
    }

    for (i = 0; i < cnpj.length - 1; i++)
        if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
            digitos_iguais = 0;
            break;
        }
    if (!digitos_iguais) {
        tamanho = cnpj.length - 2
        numeros = cnpj.substring(0, tamanho);
        digitos = cnpj.substring(tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0)) {
            alert('CNPJ inválido');
            c.value = '';

            return false;
        }

        tamanho = tamanho + 1;
        numeros = cnpj.substring(0, tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1)) {
            alert('CNPJ inválido');
            c.value = '';

            return false;
        }
        else {
            // alert('CNPJ  OK !');
            return true;
        }
    }
    else {
        alert('CNPJ inválido');
        c.value = '';

        return false;
    }
}

