using ZeroFormatter;

namespace SerializerBenchmarks.ZeroFormatterSerializer;

[ZeroFormattable]
public class MessageZf
{
    [Index(0)]
    public virtual int Id { get; set; }

    [Index(1)]
    public virtual string Source { get; set; }

    [Index(2)]
    public virtual string Symbol { get; set; }

    [Index(3)]
    public virtual IList<FieldZf> Body { get; set; }
}