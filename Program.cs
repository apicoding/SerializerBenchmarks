using BenchmarkDotNet.Running;
using SerializerBenchmarks;

var summary = BenchmarkRunner.Run<FlatBuffers_Vs_Protobuf_Vs_Utf8Json>();
