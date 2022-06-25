using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using SerializerBenchmarks.ApexSerializerHelper;
using SerializerBenchmarks.BinPackSerializer;
using SerializerBenchmarks.CustomSerializer;
using SerializerBenchmarks.FlatBuffersSerializer;
using SerializerBenchmarks.ProtobufSerializer;
using SerializerBenchmarks.Utf8JsonSerializer;
using SerializerBenchmarks.ZeroFormatterSerializer;

namespace SerializerBenchmarks
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [RPlotExporter]
    public class FlatBuffers_Vs_Protobuf_Vs_Utf8Json
    {
        private MessageFb _messageFb;
        private MessagePb _messagePb;
        private MessageUj _messageUj;
        private MessageBin _messageBin;
        private MessageZf _messageZf;
        private MessageAp _messageAp;
        private MessageCust _messageCust;

        [GlobalSetup]
        public void Setup()
        {
            // FlatBuffers message
            _messageFb = new()
            {
                Body = new List<FieldFb>
                {
                    new() { Name = "key1", Value = "value1" },
                    new() { Name = "key2", Value = "value2" },
                    new() { Name = "key3", Value = "value3" },
                    new() { Name = "key4", Value = "value4" },
                    new() { Name = "key5", Value = "value5" },
                    new() { Name = "key6", Value = "value6" },
                    new() { Name = "key7", Value = "value7" },
                    new() { Name = "key8", Value = "value8" },
                    new() { Name = "key9", Value = "value9" },
                    new() { Name = "key10", Value = "value10" }
                }
            };

            // Protobuf-net message
            _messagePb = new()
            {
                Body = new Dictionary<string, string>()
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                    { "key3", "value1" },
                    { "key4", "value2" },
                    { "key5", "value1" },
                    { "key6", "value2" },
                    { "key7", "value1" },
                    { "key8", "value2" },
                    { "key9", "value1" },
                    { "key10", "value2" }
                }
            };

            _messageUj = new()
            {
                Body = new Dictionary<string, string>()
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                    { "key3", "value1" },
                    { "key4", "value2" },
                    { "key5", "value1" },
                    { "key6", "value2" },
                    { "key7", "value1" },
                    { "key8", "value2" },
                    { "key9", "value1" },
                    { "key10", "value2" }
                }
            };

            _messageBin = new()
            {
                Body = new Dictionary<string, string>()
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                    { "key3", "value1" },
                    { "key4", "value2" },
                    { "key5", "value1" },
                    { "key6", "value2" },
                    { "key7", "value1" },
                    { "key8", "value2" },
                    { "key9", "value1" },
                    { "key10", "value2" }
                }
            };

            _messageZf = new()
            {
                Body = new List<FieldZf>
                {
                    new() { Name = "key1", Value = "value1" },
                    new() { Name = "key2", Value = "value2" },
                    new() { Name = "key3", Value = "value3" },
                    new() { Name = "key4", Value = "value4" },
                    new() { Name = "key5", Value = "value5" },
                    new() { Name = "key6", Value = "value6" },
                    new() { Name = "key7", Value = "value7" },
                    new() { Name = "key8", Value = "value8" },
                    new() { Name = "key9", Value = "value9" },
                    new() { Name = "key10", Value = "value10" }
                }
            };

            // Apex
            ApexSerializerHelper.ApexSerializerHelper.Initialize();

            _messageAp = new()
            {
                Body = new Dictionary<string, string>()
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                    { "key3", "value1" },
                    { "key4", "value2" },
                    { "key5", "value1" },
                    { "key6", "value2" },
                    { "key7", "value1" },
                    { "key8", "value2" },
                    { "key9", "value1" },
                    { "key10", "value2" }
                }
            };

            // Custom
            _messageCust = new()
            {
                Body = new Dictionary<string, string>()
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                    { "key3", "value1" },
                    { "key4", "value2" },
                    { "key5", "value1" },
                    { "key6", "value2" },
                    { "key7", "value1" },
                    { "key8", "value2" },
                    { "key9", "value1" },
                    { "key10", "value2" }
                }
            };
        }

        [Benchmark]
        public byte[] FbSerialize() => FlatBuffersSerializer.FlatBuffersSerializer.Serialize(_messageFb);

        [Benchmark]
        public byte[] PbSerialize() => ProtobufSerializer.ProtobufSerializer.Serialize(_messagePb);

        [Benchmark]
        public byte[] UjSerialize() => Utf8JsonSerializer.Utf8JsonSerializer.Serialize(_messageUj);

        [Benchmark]
        public byte[] BinSerialize() => BinPackSerializer.BinPackSerializer.Serialize(_messageBin);

        [Benchmark]
        public byte[] ZeroSerialize() => ZeroFormatterSerializerHelper.Serialize(_messageZf);

        [Benchmark]
        public byte[] ApexSerialize() => ApexSerializerHelper.ApexSerializerHelper.Serialize(_messageAp);

        [Benchmark]
        public string CustSerialize() => CustomSerializer.CustomSerializer.Serialize(_messageCust);

        [Benchmark]
        public string CustSerialize2() => CustomSerializer.CustomSerializer.Serialize2(_messageCust);
    }
}