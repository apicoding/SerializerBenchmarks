using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using SerializerBenchmarks.ApexSerializerHelper;
using SerializerBenchmarks.BinPackSerializer;
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

        [GlobalSetup]
        public void Setup()
        {
            // FlatBuffers message
            _messageFb = new()
            {
                Id = 1,
                Source = "XLTST",
                Symbol = "EUR=",

                Body = new List<FieldFb>
                {
                    new() { Name = "key1", Value = "value1" },
                    new() { Name = "key2", Value = "value2" }
                }
            };

            // Protobuf-net message
            _messagePb = new()
            {
                Id = 1,
                Source = "XLTST",
                Symbol = "EUR=",

                Body = new Dictionary<string, string>()
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                }
            };

            _messageUj = new()
            {
                Id = 1,
                Source = "XLTST",
                Symbol = "EUR=",

                Body = new Dictionary<string, string>()
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                }
            };

            _messageBin = new()
            {
                Id = 1,
                Source = "XLTST",
                Symbol = "EUR=",

                Body = new Dictionary<string, string>()
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                }
            };

            _messageZf = new()
            {
                Id = 1,
                Source = "XLTST",
                Symbol = "EUR=",

                Body = new List<FieldZf>
                {
                    new() { Name = "key1", Value = "value1" },
                    new() { Name = "key2", Value = "value2" }
                }
            };

            // Apex
            ApexSerializerHelper.ApexSerializerHelper.Initialize();

            _messageAp = new()
            {
                Id = 1,
                Source = "XLTST",
                Symbol = "EUR=",

                Body = new Dictionary<string, string>()
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
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
    }
}