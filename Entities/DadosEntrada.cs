using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Formatador_CPF_CNPJ.Entities
{
    public class DadosEntrada : IValidatableObject
    {
        [RegularExpression(@"^\d{11}$|^\d{14}$", ErrorMessage = "O valor deve conter 11 dígitos (para CPF) ou 14 dígitos para CNPJ.")]
        public required string Valor { get; set; }

        public bool Cpf { get; set; } = false;
        public bool Cnpj { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Cpf && Cnpj)
                yield return new ValidationResult("Declare apenas um dos campos ('cpf' ou 'cnpj') como 'true'.", [nameof(Cpf), nameof(Cnpj)]);

            if (!Cpf && !Cnpj)
                yield return new ValidationResult("Declare 'cpf' ou 'cnpj' como 'true'.", [nameof(Cpf), nameof(Cnpj)]);
        }
    }
}
