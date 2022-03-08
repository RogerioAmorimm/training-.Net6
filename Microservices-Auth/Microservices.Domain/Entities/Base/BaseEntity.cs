
using System;

namespace Microservices.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {

        }

        protected BaseEntity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
