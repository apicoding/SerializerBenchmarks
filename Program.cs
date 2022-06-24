// See https://aka.ms/new-console-template for more information

using FlatSharp;

// FlatSharp supports enums, but makes you promise not to change the underlying type.

// Tables are flexible objects meant to allow schema changes. Numeric properties can have default values,
// and all properties can be deprecated. Each index may only be used once, so once the "Parent" property is
// deprecated, index 2 cannot be used again by a different property.

// Structs are really fast, but may only contain scalars and other structs. Structs
// cannot be versioned, so use only when you're sure the schema won't change.

Message message = new();

message.Source = "XLTST";
message.Symbol = "EUR=";

message.Body = new List<Field>
    {
        new() { Name = "key1", Value = "value1" },
        new() { Name = "key2", Value = "value2" }
    };

int maxBytesNeeded = FlatBufferSerializer.Default.GetMaxSize(message);
byte[] buffer = new byte[maxBytesNeeded];
int bytesWritten = FlatBufferSerializer.Default.Serialize(message, buffer);


Console.WriteLine("Serialization done with FlatBuffers");

Message p = FlatBufferSerializer.Default.Parse<Message>(buffer);

Console.WriteLine("Deserialization done with FlatBuffers");