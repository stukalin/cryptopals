namespace Cryptopals.Util
{
    using System.Globalization;
    using System.Linq;

    public static class StringHelper
    {
        /// <summary>
        /// converts string containing encoded bytes into bytearray
        /// </summary>
        public static byte[] ParseHex(this string hexstring)
        {
            byte[] result = new byte[hexstring.Length / 2];

            for (int i = 0; i < hexstring.Length; i += 2)
            {
                result[i / 2] = byte.Parse(hexstring.Substring(i, 2), NumberStyles.HexNumber);
            }

            return result;
        }

        public static byte[] ToBytes(this string s)
        {
            return s.Select(a => (byte)a).ToArray();
        }
    }
}
