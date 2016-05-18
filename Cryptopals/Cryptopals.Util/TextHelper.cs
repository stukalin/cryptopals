namespace Cryptopals.Util
{
    using System;
    using System.Linq;

    using Cryptopals.Util.Entities;

    public static class TextHelper
    {
        public static float CalculateEnglishChars(this string text)
        {
            Func<char, float> weight = delegate(char c)
                {
                    c = char.ToLower(c);
                    if ('a' <= c && c <= 'z')
                    {
                        return 1;
                    }

                    if (char.IsPunctuation(c))
                    {
                        return 0.25f;
                    }

                    if (char.IsWhiteSpace(c))
                    {
                        return 0.1f;
                    }

                    return -1;
                };
            return text.Select(char.ToLower).Sum(weight);
        }

        public static TextAnalyzerResult FindSingleCharKey(string source)
        {
            var byteSourse = source.ParseHex();
            var maxChar = (char)0x0;
            float maxScore = 0;

            for (char c = maxChar; c < (char)0xff; c++)
            {
                var score = byteSourse.Xor((byte)c).Decode().CalculateEnglishChars();
                if (score > maxScore)
                {
                    maxScore = score;
                    maxChar = c;
                }
            }

            return new TextAnalyzerResult()
                       {
                           EncodedString = source,
                           Key = new []{ (byte)maxChar },
                           Score = maxScore
                       };
        }
    }
}
