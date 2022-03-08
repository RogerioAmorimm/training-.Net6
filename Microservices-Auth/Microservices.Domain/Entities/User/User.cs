
using Microservices.Domain.Entities.Base;
using System;

namespace Microservices.Domain.Entities.User
{
    public class User : BaseEntity
    {
        public User()
        {

        }
        public User(Guid id):base(id)
        {

        }

        public string UserName { get; private set; }
        public string Email { get; private set; }

    }
}
