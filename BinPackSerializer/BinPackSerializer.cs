using BinaryPack;

namespace SerializerBenchmarks.BinPackSerializer;

public static class BinPackSerializer
{
    public static byte[] Serialize(MessageBin messageBin)
    {
        return BinaryConverter.Serialize(messageBin);
    }

    public static MessageBin Deserialize(byte[] buffer)
    {
        return BinaryConverter.Deserialize<MessageBin>(buffer);
    }
}