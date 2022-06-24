using FlatSharp.Attributes;

[FlatBufferTable]
public class Field : object
{
    [FlatBufferItem(0)]
    public virtual string Name { get; set; }

    [FlatBufferItem(1)]
    public virtual string Value { get; set; }
}