using ProtoBuf;

namespace SerializerBenchmarks.ProtobufSerializer;

[ProtoContract]
public class MessagePb
{
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string Source { get; set; }

    [ProtoMember(3)]
    public string Symbol { get; set; }

    [ProtoMember(4)]
    public Dictionary<string, string> Body { get; set; }
}