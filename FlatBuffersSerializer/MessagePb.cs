using FlatSharp.Attributes;

namespace SerializerBenchmarks.FlatBuffersSerializer
{
    [FlatBufferTable]
    public class MessageFb : object
    {
        [FlatBufferItem(0)]
        public virtual IList<FieldFb> Body { get; set; }
    }
}