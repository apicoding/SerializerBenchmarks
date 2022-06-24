using FlatSharp.Attributes;

namespace SerializerBenchmarks.FlatBuffersSerializer;

[FlatBufferTable]
public class MessageFb : object
{
    [FlatBufferItem(0)]
    public virtual int Id { get; set; }

    [FlatBufferItem(1)]
    public virtual string Source { get; set; }

    [FlatBufferItem(2)]
    public virtual string Symbol { get; set; }

    [FlatBufferItem(3)]
    public virtual IList<FieldFb> Body { get; set; }
}