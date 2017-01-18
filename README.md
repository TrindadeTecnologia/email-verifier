# Trindade.EmailVerifier

Email verifier created to validate emails through configured rules. Today, the project has the following validations.

- EmailAddressAttribute of System.ComponentModel.DataAnnotations to validate the sintax that indicates a string if has a valid format.
- Using ARSoft.Tools.Net.Dns to validate domain's MX of email. The idea here is use any cache's architecture to save whitedomains and invalid domains for multiple validations in a period of time.
- Using a regex to validate some rule based in a string.

Example:

```cs
var emailVerifier = new EmailVerifier();

// Adding default rules:
emailVerifier.AddRule(DefaultRules.SintaxRule);
emailVerifier.AddRule(DefaultRules.MxRule);

string emailToBeValidated = "paulofoliveira@outlook.com";

bool result = emailVerifier.IsValid(emailToBeValidated);

Console.WriteLine($"Result = { result }");

```
You can create your custom rule inheriting IEmailRule class. You'll have to implement two methods. IsValid and IsValidAsync. Both, returns a boolean value that indicates if the informed address value is valid or not. Fdxa1a
