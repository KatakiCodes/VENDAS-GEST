using Domain.Enums;
using Domain.Validation;
using System;

namespace Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string password, EUserRole role, bool enabled)
        {
            ValidateDomain(name, password, role, enabled);
        }
        //Construtor para atualização
        public User(Guid id, string name, string password, EUserRole role, bool enabled)
        {
            ValidateDomain(name, password, role, enabled);
            Id = id;
        }

        public string Name { get; private set; }
        public string Password { get; private set; }
        public EUserRole Role { get; private set; }
        public bool Enabled { get; private set; }

        public void Enable()
        {
            this.Enabled = true;
        }
        public void Disable()
        {
            this.Enabled = false;
        }

        public void ValidateDomain(string name, string password, EUserRole role, bool enabled)
        {
            DomainValidationExeption.When(string.IsNullOrEmpty(name), "O nome do utilizador não pode ser vazio ou nulo");
            DomainValidationExeption.When((name.Length < 3), "O nome do utilizador deve possuir no mínimo 3 caractéres");
            DomainValidationExeption.When(string.IsNullOrEmpty(password), "A palavra-passe do utilizador não pode ser vazia ou nula");
            DomainValidationExeption.When(!Enum.IsDefined(typeof(EUserRole), role), "Informe uma função válida para o utilizador");
            Name = name;
            Password = password;
            Role = role;
            Enabled = enabled;
        }
    }
}