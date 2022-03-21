

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Microservices.Dto.Base
{
    public abstract class BaseDto
    {
        protected BaseDto()
        {
            Errors = new List<string>();
        }

        [JsonIgnore]
        [XmlIgnore]
        public ICollection<string> Errors { get; set; }

        public void AddError(string error)
        {
            if (!Errors.Contains(error))
                Errors.Add(error);
        }
        public void AddError(IEnumerable<string> errors)
        {
            foreach (var error in errors) AddError(error);
        }
        public virtual bool IsValid() => Errors == null || !Errors.Any();

    }
}
