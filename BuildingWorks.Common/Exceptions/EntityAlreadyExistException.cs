using System.Runtime.Serialization;

namespace BuildingWorks.Common.Exceptions;

[Serializable]
public class EntityAlreadyExistException : Exception
{
    public EntityAlreadyExistException() { }
    public EntityAlreadyExistException(string message) : base(message) { }
    public EntityAlreadyExistException(string message, Exception inner) : base(message, inner) { }

    protected EntityAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}