namespace Cryptopals.Tests.Challenges
{
    using System;
    using System.IO;

    using Cryptopals.Util;
    using Cryptopals.Util.Entities;

    using NUnit.Framework;

    [TestFixture]
    public class Set1Tests
    {
        /// <summary>
        /// Convert hex to base64.
        /// The string:
        /// 49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d
        /// Should produce:
        /// SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t
        /// </summary>
        [Test]
        public void Challenge1()
        {
            var s = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            var base64 = Convert.ToBase64String(s.ParseHex());

            Assert.That(base64, Is.EqualTo("SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t"));
        }

        /// <summary>
        /// Fixed XOR
        /// Write a function that takes two equal-length buffers and produces their XOR combination.
        /// If your function works properly, then when you feed it the string:
        /// 1c0111001f010100061a024b53535009181c
        /// ... after hex decoding, and when XOR'd against:
        /// 686974207468652062756c6c277320657965
        /// ... should produce:
        /// 746865206b696420646f6e277420706c6179
        /// </summary>
        [Test]
        public void Challenge2()
        {
            var xored = "1c0111001f010100061a024b53535009181c".ParseHex().Xor("686974207468652062756c6c277320657965".ParseHex());
            Assert.That(xored.ToHexString(), Is.EqualTo("746865206b696420646f6e277420706c6179"));
        }

        /// <summary>
        /// Single-byte XOR cipher
        /// The hex encoded string:
        /// 1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736
        /// ... has been XOR'd against a single character. Find the key, decrypt the message.
        /// </summary>
        [Test]
        public void Challenge3()
        {
            var source = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";

            var result = TextHelper.FindSingleCharKey(source);

            Console.WriteLine("My char is " + result.Key.Decode());
            Console.WriteLine("Decoded text is then: " + result.DecodedString());

            Assert.That(result.Key.Decode(), Is.EqualTo("X"));
        }

        /// <summary>
        /// Detect single-character XOR
        /// One of the 60-character strings in this file (4.txt) has been encrypted by single-character XOR.
        /// Find it.
        /// </summary>
        [Test]
        public void Challenge4()
        {
            var source = File.ReadAllLines(Path.Combine(TestContext.CurrentContext.TestDirectory, @"data\4.txt"));

            var maxscore = new TextAnalyzerResult();

            foreach (var s in source)
            {
                var result = TextHelper.FindSingleCharKey(s);
                if (result.Score > maxscore.Score)
                {
                    maxscore = result;
                }
            }

            Console.WriteLine("The encoded line is " + maxscore.EncodedString);
            Console.WriteLine("My char is " + maxscore.Key.Decode());
            Console.WriteLine("Decoded text is then: " + maxscore.DecodedString());

            Assert.That(maxscore.EncodedString, Is.EqualTo("7b5a4215415d544115415d5015455447414c155c46155f4058455c5b523f"));
        }
    }
}
