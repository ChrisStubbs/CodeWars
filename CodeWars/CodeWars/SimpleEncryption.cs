using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
//https://www.codewars.com/kata/57814d79a56c88e3e0000786/train/csharp
namespace CodeWars
{
    public class SimpleEncryption
    {

        public static string Encrypt(string text, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var charArray = text.ToCharArray();
                var evens = new List<char>();
                var odds = new List<char>();

                var j = 0;
                foreach (var chr in charArray)
                {
                    j++;
                    if (j % 2 == 0)
                    {
                        evens.Add(chr);
                    }
                    else
                    {
                        odds.Add(chr);
                    }
                    text = string.Concat(string.Join("", evens), string.Join("", odds));
                }
            }
            return text;
        }

        public static string Decrypt(string encryptedText, int n)
        {
            return encryptedText;
        }
    }

    [TestFixture]
    public class SimpleEncryptionTests
    {
        [Test]
        public void EncryptExampleTests()
        {
            Assert.AreEqual("This is a test!", SimpleEncryption.Encrypt("This is a test!", 0));
            Assert.AreEqual("hsi  etTi sats!", SimpleEncryption.Encrypt("This is a test!", 1));
            Assert.AreEqual("s eT ashi tist!", SimpleEncryption.Encrypt("This is a test!", 2));
            Assert.AreEqual(" Tah itse sits!", SimpleEncryption.Encrypt("This is a test!", 3));
            Assert.AreEqual("This is a test!", SimpleEncryption.Encrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", SimpleEncryption.Encrypt("This is a test!", -1));
            Assert.AreEqual("hskt svr neetn!Ti aai eyitrsig", SimpleEncryption.Encrypt("This kata is very interesting!", 1));
        }

    }
}
