namespace SerializerBenchmarks.Utf8JsonSerializer
{
    public class MessageUj
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Symbol { get; set; }
        public Dictionary<string, string> Body { get; set; }
    }
}