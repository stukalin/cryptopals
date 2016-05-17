namespace Cryptopals.Util
{
    using System;
    using System.Linq;
    using System.Text;

    public static class BytesHelper
    {
        public static string Decode(this byte[] bytes)
        {
            return new string(bytes.Select(Convert.ToChar).ToArray());
        }

        public static string ToHexString(this byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x"));
            }

            return sb.ToString();
        }
    }
}
