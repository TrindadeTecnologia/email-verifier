# Trindade.EmailVerifier123

Verificador de e-mails criado para validar endereços de e-mail a partir de regras pré definidas.
O projeto hoje conta com duas regras para validação:
- Usando EmailAddressAttribute do System.ComponentModel.DataAnnotations para validação de sintaxe que indica que a string informada possui ao menos um formato de e-mail valido, que seja pelo menos a@b.com
- Usando o ARSoft.Tools.Net.Dns para validação MX do domínio de e-mail informado que valida se o e-mail informado possui ao menos serviço MX configurado.
- Usando um Regex pré definido que valida se o endereço é valido ou não.

Exemplo:

```cs
var emailVerifier = new EmailVerifier();

// Adicionando regras default:
emailVerifier.AddRule(new DefaultRule());
emailVerifier.AddRule(new MxRule());
emailVerifier.AddRule(new RegexRule("Regex"));

string emailToBeValidated = "paulofoliveira@outlook.com";

bool result = emailVerified.IsValid(emailToBeValidated);

Console.WriteLine($"Resultado = { result }");

```

<img src="http://trindade-ci.eastus.cloudapp.azure.com:8080/job/EmailVerifier/badge/icon" />
