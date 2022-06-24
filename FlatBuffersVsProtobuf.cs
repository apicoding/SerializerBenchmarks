using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using SerializerBenchmarks.FlatBuffersSerializer;
using SerializerBenchmarks.ProtobufSerializer;

namespace SerializerBenchmarks;

[SimpleJob(RuntimeMoniker.CoreRt60)]
[RPlotExporter]
public class FlatBuffersVsProtobuf
{
    private MessageFb _messageFb;
    private MessagePb _messagePb;

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
    }

    [Benchmark]
    public byte[] FbSerialize() => FlatBuffersSerializer.FlatBuffersSerializer.Serialize(_messageFb);

    [Benchmark]
    public byte[] PbSerialize() => ProtobufSerializer.ProtobufSerializer.Serialize(_messagePb);
}