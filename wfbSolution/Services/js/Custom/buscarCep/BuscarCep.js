function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('txtAddress').value = ("");
    document.getElementById('txtNeighborhood').value = ("");
    document.getElementById('txtUf').value = ("");
    document.getElementById('txtCity').value = ("");
}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        debugger;
        //Atualiza os campos com os valores.
        document.getElementById('txtAddress').value = (conteudo.logradouro);
        document.getElementById('txtNeighborhood').value = (conteudo.bairro);
        document.getElementById('txtUf').value = (conteudo.uf);
        document.getElementById('txtCity').value = (conteudo.localidade);
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
            document.getElementById('txtAddress').value = "...";
            document.getElementById('txtNeighborhood').value = "...";
            document.getElementById('txtUf').value = "...";
            document.getElementById('txtCity').value = "...";

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