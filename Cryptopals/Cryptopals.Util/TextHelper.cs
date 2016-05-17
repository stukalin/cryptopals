namespace Cryptopals.Util
{
    using System.Linq;

    public static class TextHelper
    {
        public static int CalculateEnglishChars(this string text)
        {
            return text.Select(char.ToLower).Count(lower => 'a' <= lower && lower <= 'z');
        }
    }
}
