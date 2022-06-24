using ProtoBuf;

namespace SerializerBenchmarks.ProtobufSerializer;

public static class ProtobufSerializer
{
    public static byte[] Serialize(MessagePb messagePb)
    {
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, messagePb);
        return stream.ToArray();
    }

    public static MessagePb Deserialize(byte[] buffer)
    {
        using var stream = new MemoryStream(buffer);
        return Serializer.Deserialize<MessagePb>(stream);
    }
}