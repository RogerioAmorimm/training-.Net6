
using Microservices.Domain.Entities.Base;

namespace Microservices.Domain.Entities.Token
{
    public class Token : BaseEntity
    {

        public Token(string value)
        {
            Value = value;
        }
        public string Value{ get; private set; }
    }
}
