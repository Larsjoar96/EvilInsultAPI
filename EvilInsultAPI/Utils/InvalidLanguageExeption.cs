using System.Runtime.Serialization;

namespace EvilInsultAPI.Utils
{
    [Serializable]
    internal class InvalidLanguageExeption : Exception
    {
        public InvalidLanguageExeption() { }
        public InvalidLanguageExeption(string message) : base(message) { }
        public InvalidLanguageExeption(string? message, Exception? innerException) : base(message, innerException) { }
        protected InvalidLanguageExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
