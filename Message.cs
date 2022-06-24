using FlatSharp.Attributes;

[FlatBufferTable]
public class Message : object
{
    [FlatBufferItem(0)]
    public virtual int Id { get; set; }

    [FlatBufferItem(1)]
    public virtual string Source { get; set; }

    [FlatBufferItem(2)]
    public virtual string Symbol { get; set; }

    [FlatBufferItem(3)]
    public virtual IList<Field> Body { get; set; }
}
