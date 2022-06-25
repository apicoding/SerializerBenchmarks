
using System.Text;
using Mono.Cecil.Cil;

namespace SerializerBenchmarks.CustomSerializer
{
    public static class CustomSerializer
    {
        public static string Serialize(MessageCust messageCust)
        {
            var sb = new StringBuilder();

            foreach (var it in messageCust.Body)
            {
                sb.Append(it.Key);
                sb.Append(':');
                sb.Append(it.Value);
                sb.Append('|');
            }

            return sb.ToString();
        }

        public static string Serialize2(MessageCust messageCust)
        {
            var sb = new StringBuilder();

            var body = messageCust.Body;

            using var keysEnum = body.Keys.GetEnumerator();
            using var valuesEnum = body.Values.GetEnumerator();

            for (var i = 0 ; i < body.Count ; i++)
            {
                keysEnum.MoveNext();
                sb.Append(keysEnum.Current);
                sb.Append(':');
                valuesEnum.MoveNext();
                sb.Append(valuesEnum.Current);
                sb.Append('|');
            }

            return sb.ToString();
        }

        public static MessageCust Deserialize(string buffer)
        {
            var fields = buffer.Split('|');
            var messageCust = new MessageCust();
            messageCust.Body = new Dictionary<string, string>();

            foreach (var field in fields)
            {
                if (!string.IsNullOrEmpty(field))
                {
                    var kv = field.Split(':');
                    messageCust.Body.Add(kv[0], kv[1]);
                }
            }

            return messageCust;
        }
    }
}
