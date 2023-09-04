//script para validação dos campos de senha e confirmar senha

    function validationConfirmPassword(password, confirmPassword) {
        //variaveis
        var vpassword = document.getElementById(password).value;
        var vconfirmPassword = document.getElementById(confirmPassword).value;
        //Comparando valores
        if (vpassword != vconfirmPassword) {
            alert('Insira sua confirmação de senha corretamente');
            document.getElementById(confirmPassword).value = '';
        }
    }
