using System.Runtime.InteropServices;
using BenchmarkDotNet.Running;
using SerializerBenchmarks;
using SerializerBenchmarks.CustomSerializer;

MessageCust message = new()
{
    Body = new Dictionary<string, string>()
   {
        { "key1", "value1:value2" },
        { "key2", "value1:value2|test" },
        { "key3", "value1:value2|test" },
        { "key4", "value1:value2test" },
        { "key5", "value1:value2test" },
        { "key6", "value1:value2|test" },
        { "key7", "value1:value2test" }
   }
};

var ser = CustomSerializer.Serialize(message);

var newMessage = CustomSerializer.Deserialize(ser);

Console.WriteLine("DONE");

//var summary = BenchmarkRunner.Run<FlatBuffers_Vs_Protobuf_Vs_Utf8Json>();
