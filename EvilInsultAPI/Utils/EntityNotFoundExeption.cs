using System.Runtime.Serialization;

namespace EvilInsultAPI.Utils
{
    [Serializable]
    internal class EntityNotFoundExeption : Exception
    {
        public EntityNotFoundExeption() { }
        public EntityNotFoundExeption(string message) : base(message) { }
        public EntityNotFoundExeption(string? message, Exception? innerException) : base(message, innerException) { }
        protected EntityNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
