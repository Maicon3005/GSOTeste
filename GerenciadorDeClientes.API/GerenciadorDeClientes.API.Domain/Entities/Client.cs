using GerenciadorDeClientes.API.Domain.Validations;
using System;

namespace GerenciadorDeClientes.API.Domain.Entities
{
    public sealed class Client
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; } 

        public Client(string name, string cpf, DateTime birthDate)
        {
            Validation(name, cpf, birthDate);
        }

        public Client(int id, string name, string cpf, DateTime birthDate)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero");
            Id = id;
            Validation(name, cpf, birthDate);
        }

        private void Validation(string name, string cpf, DateTime birthDate) 
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Favor informe o nome!");
            DomainValidationException.When(string.IsNullOrEmpty(cpf), "Favor informe o cpf!");

            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;  
        }
    }
}
