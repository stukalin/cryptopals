﻿namespace Cryptopals.Tests
{
    using Cryptopals.Util;

    using NUnit.Framework;

    [TestFixture]
    public class BytesHelperTests
    {
        [Test]
        public void ParseHexTest_PassArray_GetString()
        {
            var s = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            var res = s.ParseHex();

            Assert.That(res.ToHexString(), Is.EqualTo(s));
        }
    }
}
