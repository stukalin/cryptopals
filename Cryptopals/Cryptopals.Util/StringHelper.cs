namespace Cryptopals.Util
{
    using System.Globalization;

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
    }
}
