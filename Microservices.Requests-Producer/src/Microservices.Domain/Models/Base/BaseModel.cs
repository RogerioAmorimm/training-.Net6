
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Microservices.Domain.Models.Base
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {

        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; private set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseModel;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(BaseModel a, BaseModel b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseModel a, BaseModel b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
