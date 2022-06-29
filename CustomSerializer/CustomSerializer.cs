using System.Text;

namespace SerializerBenchmarks.CustomSerializer;

public static class CustomSerializer
{
    private const char Separator = (char)0x1E;

    public static string Serialize(MessageCust messageCust)
    {
        var sb = new StringBuilder();

        foreach (var it in messageCust.Body)
        {
            sb.Append(it.Key);
            sb.Append(':');
            sb.Append(it.Value);
            sb.Append(Separator);
        }

        return sb.ToString();
    }

    public static MessageCust Deserialize(string buffer)
    {
        var fields = buffer.Split(Separator);
        var messageCust = new MessageCust();
        messageCust.Body = new Dictionary<string, string>();

        foreach (var field in fields)
        {
            if (!string.IsNullOrEmpty(field))
            {
                var kv = field.Split(':', 2);

                if (kv.Length != 2)
                {
                    return null;
                }

                messageCust.Body.Add(kv[0], kv[1]);
            }
        }

        return messageCust;
    }
}