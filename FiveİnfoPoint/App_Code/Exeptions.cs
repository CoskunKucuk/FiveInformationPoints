using System;
using System.Runtime.Serialization;

[Serializable]
public class NodeExeption : Exception
{
    public NodeExeption()
    : base()
    { }

    public NodeExeption(string message)
    : base(message)
    { }

    public NodeExeption(string format, params object[] args)
    : base(string.Format(format, args))
    { }

    public NodeExeption(string message, Exception innerException)
    : base(message, innerException)
    { }

    public NodeExeption(string format, Exception innerException, params object[] args)
    : base(string.Format(format, args), innerException)
    { }

    protected NodeExeption(SerializationInfo info, StreamingContext context)
    : base(info, context)
    { }
}

