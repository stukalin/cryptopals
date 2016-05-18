namespace Cryptopals.Util.Entities
{
    public class TextAnalyzerResult
    {
        public byte[] Key { get; set; }

        public float Score { get; set; }

        public string EncodedString { get; set; }

        public string DecodedString()
        {
            return EncodedString.ParseHex().Xor(Key).Decode();
        }
    }
}
