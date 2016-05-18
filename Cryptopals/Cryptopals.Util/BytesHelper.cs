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

        public static byte[] Xor(this byte[] a, byte[] b)
        {
            var result = new byte[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                result[i] = (byte)(a[i] ^ b[i % b.Length]);
            }

            return result;
        }

        public static byte[] Xor(this byte[] a, byte b)
        {
            return a.Xor(new []{ b });
        }
    }
}
