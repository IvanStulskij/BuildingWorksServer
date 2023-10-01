using System.Runtime.Serialization;

namespace BuildingWorks.Common.Exceptions;

[Serializable]
public class EntityNotExistException : Exception
{
    public EntityNotExistException() { }
    public EntityNotExistException(string message) : base(message) { }
    public EntityNotExistException(string message, Exception inner) : base(message, inner) { }

    protected EntityNotExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}