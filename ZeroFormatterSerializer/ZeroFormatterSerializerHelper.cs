namespace SerializerBenchmarks.ZeroFormatterSerializer
{
    public static class ZeroFormatterSerializerHelper
    {
        public static byte[] Serialize(MessageZf messageBin)
        {
            return ZeroFormatter.ZeroFormatterSerializer.Serialize(messageBin);
        }

        public static MessageZf Deserialize(byte[] buffer)
        {
            return ZeroFormatter.ZeroFormatterSerializer.Deserialize<MessageZf>(buffer);
        }
    }
}