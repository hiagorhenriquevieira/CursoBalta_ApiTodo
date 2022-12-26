using System;

namespace Todo.Domain.Entities
{
    public abstract class EntidadeBase : IEquatable<EntidadeBase>
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(EntidadeBase? other)
        {
           return Id == other?.Id;
        }
    }
}