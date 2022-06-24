using FlatSharp.Attributes;

[FlatBufferEnum(typeof(byte))]
public enum Color : byte { Red = 1, Green, Blue }