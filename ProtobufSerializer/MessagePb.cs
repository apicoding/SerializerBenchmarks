using ProtoBuf;

namespace SerializerBenchmarks.ProtobufSerializer
{
    [ProtoContract]
    public class MessagePb
    {
        [ProtoMember(1)]
        public Dictionary<string, string> Body { get; set; }
    }
}