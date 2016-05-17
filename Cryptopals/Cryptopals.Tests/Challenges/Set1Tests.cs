namespace Cryptopals.Tests.Challenges
{
    using System;

    using Cryptopals.Util;

    using NUnit.Framework;

    [TestFixture]
    public class Set1Tests
    {
        [Test]
        public void Challenge1()
        {
            var s = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            var base64 = Convert.ToBase64String(s.ParseHex());

            Assert.That("SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t", Is.EqualTo(base64));
        }
    }
}
