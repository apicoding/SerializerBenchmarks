using Apex.Serialization;

namespace SerializerBenchmarks.ApexSerializerHelper;

public static class ApexSerializerHelper
{
    private static IBinary _serializer;

    public static void Initialize()
    {
        _serializer = Binary.Create(new Settings().MarkSerializable(typeof(MessageAp)));
    }

    public static byte[] Serialize(MessageAp messageBin)
    {
        using var stream = new MemoryStream();
        _serializer.Write(messageBin, stream);
        return stream.ToArray();
    }

    public static MessageAp Deserialize(byte[] buffer)
    {
        using var stream = new MemoryStream(buffer);
        return _serializer.Read<MessageAp>(stream);
    }
}