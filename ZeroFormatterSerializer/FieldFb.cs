using ZeroFormatter;

namespace SerializerBenchmarks.ZeroFormatterSerializer
{
    [ZeroFormattable]
    public class FieldZf : object
    {
        [Index(0)]
        public virtual string Name { get; set; }

        [Index(1)]
        public virtual string Value { get; set; }
    }
}
