using FlatSharp.Attributes;

namespace SerializerBenchmarks.FlatBuffersSerializer;

[FlatBufferTable]
public class FieldFb : object
{
    [FlatBufferItem(0)]
    public virtual string Name { get; set; }

    [FlatBufferItem(1)]
    public virtual string Value { get; set; }
}