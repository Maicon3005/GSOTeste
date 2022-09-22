using FluentValidation;
using System;

namespace GerenciadorDeClientes.API.Application.DTOs.Validations
{
    public class ClientDTOValidator : AbstractValidator<ClientDTO>
    {
        public ClientDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome deve ser informado!");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .WithMessage("O CPF deve ser informado!");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("A data de nascimento deve ser informada!");
        }

    }
}
