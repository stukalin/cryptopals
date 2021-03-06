﻿namespace Cryptopals.Tests
{
    using System.Linq;

    using Cryptopals.Util;

    using NUnit.Framework;

    [TestFixture]
    public class StringHelperTests
    {
        [Test]
        public void ParseTest_PassString_GetArray()
        {
            var s = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            var res = s.ParseHex();

            Assert.That(s.Length / 2, Is.EqualTo(res.Length));
            Assert.That(res.First(), Is.EqualTo(0x49));
            Assert.That(res.Last(), Is.EqualTo(0x6d));
        }
    }
}
