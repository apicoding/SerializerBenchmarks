using Utf8Json;

namespace SerializerBenchmarks.Utf8JsonSerializer
{
    public static class Utf8JsonSerializer
    {
        public static byte[] Serialize(MessageUj messageUj)
        {
            return JsonSerializer.Serialize(messageUj);
        }

        public static MessageUj Deserialize(byte[] buffer)
        {
            return JsonSerializer.Deserialize<MessageUj>(buffer);
        }
    }
}
