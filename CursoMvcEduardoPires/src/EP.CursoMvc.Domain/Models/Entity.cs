using System;
using DomainValidation.Validation;

namespace EP.CursoMvc.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public ValidationResult ValidationResult { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public abstract bool EhValido();
    }
}
