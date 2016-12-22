# Trindade.EmailVerifier

Verificador de e-mails criado para validar endereços de e-mail apartir de regras definidas no verificador.
O projeto hoje conta com duas regras para validação:
- Usando EmailAddressAttribute do System.ComponentModel.DataAnnotations para validação de sintaxe que indica que a string informada possui ao menos um formato de e-mail valido, que seja pelo menos a@b.com
- Usando o ARSoft.Tools.Net.Dns para validação MX do domínio de e-mail informado que valida se o e-mail informado possui ao menos serviço MX configurado.
