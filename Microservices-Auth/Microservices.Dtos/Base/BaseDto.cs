
using System.Collections.Generic;

namespace Microservices.Dtos.Base
{
    public abstract class BaseDto
    {
        public BaseDto()
        {
            Erros ??= new List<string>();
        }

        public List<string> Erros;
        public bool IsValid() => Erros.Count == 0;
    }
}
