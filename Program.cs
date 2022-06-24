
using SerializerBenchmarks.FlatBuffersSerializer;

Message message = new()
{
    Source = "XLTST",
    Symbol = "EUR=",

    Body = new List<Field>
    {
        new() { Name = "key1", Value = "value1" },
        new() { Name = "key2", Value = "value2" }
    }
};

byte[] fbBuffer = FlatBuffersTool.Serialize(message);

var messageDeser = FlatBuffersTool.Deserialize(fbBuffer);

Console.WriteLine("Done");