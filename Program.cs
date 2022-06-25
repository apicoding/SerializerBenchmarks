using BenchmarkDotNet.Running;
using SerializerBenchmarks;
using SerializerBenchmarks.CustomSerializer;

//MessageCust message = new()
//{
//    Body = new Dictionary<string, string>()
//   {
//        { "key1", "value1" },
//        { "key2", "value2" },
//        { "key3", "value1" },
//        { "key4", "value2" },
//        { "key5", "value1" },
//        { "key6", "value2" },
//        { "key7", "value1" },
//        { "key8", "value2" },
//        { "key9", "value1" },
//        { "key10", "value2" },
//        { "key11", "value2" }
//   }
//};

//var size = GetSize(message.Body);

//Console.WriteLine("DONE");


//unsafe int GetSize(object obj)
//{
//    RuntimeTypeHandle th = obj.GetType().TypeHandle;
//    return *(*(int**)&th + 1);
//}

//var ser = CustomSerializer.Serialize2(message);

//var newMessage = CustomSerializer.Deserialize(ser);



var summary = BenchmarkRunner.Run<FlatBuffers_Vs_Protobuf_Vs_Utf8Json>();
