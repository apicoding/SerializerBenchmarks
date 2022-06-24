using BenchmarkDotNet.Running;
using SerializerBenchmarks;

var summary = BenchmarkRunner.Run<FlatBuffersVsProtobuf>();

/*
// FlatBuffers sample
MessageFb messageFb = new()
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

byte[] bufferFb = FlatBuffersSerializer.Serialize(messageFb);
var newMessageFb = FlatBuffersSerializer.Deserialize(bufferFb);

Console.WriteLine($"FlatBuffers done");


// Protobuf-net sample
MessagePb messagePb = new()
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


byte[] bufferPb = ProtobufSerializer.Serialize(messagePb);
var newMessagePb = ProtobufSerializer.Deserialize(bufferPb);
*/

Console.WriteLine($"FlatBuffers done");

