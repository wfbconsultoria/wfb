function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('Body_Content_txtAddress').value = ("");
    document.getElementById('Body_Content_txtNeighborhood').value = ("");
    document.getElementById('Body_Content_txtUf').value = ("");
    document.getElementById('Body_Content_txtCity').value = ("");
}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        debugger;
        //Atualiza os campos com os valores.
        document.getElementById('Body_Content_txtAddress').value = (conteudo.logradouro);
        document.getElementById('Body_Content_txtNeighborhood').value = (conteudo.bairro);
        document.getElementById('Body_Content_txtUf').value = (conteudo.uf);
        document.getElementById('Body_Content_txtCity').value = (conteudo.localidade);
    } 
    else {
        //CEP não Encontrado.
        limpa_formulário_cep();
        alert("CEP não encontrado.");
    }
}

function pesquisacep(valor) {

    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            document.getElementById('Body_Content_txtAddress').value = "...";
            document.getElementById('Body_Content_txtNeighborhood').value = "...";
            document.getElementById('Body_Content_txtUf').value = "...";
            document.getElementById('Body_Content_txtCity').value = "...";

            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

        }
        else {
            //cep é inválido.
            limpa_formulário_cep();
            alert("Formato de CEP inválido.");
        }
    }
    else {
        //cep sem valor, limpa formulário.
        limpa_formulário_cep();
    }
};