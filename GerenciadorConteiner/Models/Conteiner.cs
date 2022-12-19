using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("CONTEINERS")]
    public class Conteiner
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Cliente { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        public string NumeroConteiner { get; set; }

        public TipoEnum Tipo { get; set; }
        public StatusEnum Status { get; set; }
        public CategoriaEnum Categoria { get; set; }

        public enum TipoEnum { TIPO_20, TIPO_40 }
        public enum StatusEnum { CHEIO, VAZIO }
        public enum CategoriaEnum { IMPORTACAO, EXPORTACAO }

        public FluentValidation.Results.ValidationResult ValidateConteiner(IValidator<Conteiner> _validator)
        {
            return _validator.Validate(this);
        }
    }

    public class ConteinerValidator : AbstractValidator<Conteiner>
    {
        public ConteinerValidator()
        {
            RuleFor(conteiner => conteiner.NumeroConteiner)
                .NotNull().WithMessage("O NÚMERO DO CONTÊINER deve ser preenchido")
                .Must(conteiner => ValidarNumeroConteiner(conteiner)).WithMessage("O NÚMERO DO CONTÊINER deve começar com 4 caracters e terminar com 7 digitos númericos");
        }

        public bool ValidarNumeroConteiner(string numeroConteiner)
        {
            if(numeroConteiner != null && numeroConteiner.Length == 11)
            {
                //Ex: TEST1234567
                var letras = numeroConteiner.Substring(0, 4);
                var numeros = numeroConteiner.Substring(4, 7);

                var eValido = true;

                letras.ToCharArray().ToList().ForEach(letra =>
                {
                    eValido = char.IsLetter(letra) && eValido;
                });

                numeros.ToCharArray().ToList().ForEach(numero =>
                {
                    eValido = char.IsDigit(numero) && eValido;
                });

                return eValido;
            }

            return false;
        }
    }
}
