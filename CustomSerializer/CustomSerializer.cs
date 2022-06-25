
using System.Text;

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
            string result = "";

            foreach (var it in messageCust.Body)
            {
                var input = new string[] { result, it.Key, ":", it.Value, "|" };
                result = input.StringJoin();
            }

            return result;
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


        //private static unsafe string Serialize2(MessageCust messageCust)
        //{
        //}
    }
}
