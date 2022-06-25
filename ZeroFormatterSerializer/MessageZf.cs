using ZeroFormatter;

namespace SerializerBenchmarks.ZeroFormatterSerializer
{
    [ZeroFormattable]
    public class MessageZf
    {
        [Index(0)]
        public virtual IList<FieldZf> Body { get; set; }
    }
}