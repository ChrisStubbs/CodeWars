//https://www.codewars.com/kata/57814d79a56c88e3e0000786/train/csharp
/*
Instructions
Output
Past Solutions
For building the encrypted string:
Take every 2nd char from the string, then the other chars, that are not every 2nd char, and concat them as new String.
Do this n times!

Examples:

"This is a test!", 1 -> "hsi  etTi sats!"
"This is a test!", 2 -> "hsi  etTi sats!" -> "s eT ashi tist!"
Write two methods:

string Encrypt(string text, int n)
string Decrypt(string encryptedText, int n)
For both methods:
If the input-string is null or empty return exactly this value!
If n is <= 0 then return the input text.
*/
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeWars
{
    public class Kata
    {

        public static string Encrypt(string text, int n)
        {
            if (text == null) return null;

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
            if (encryptedText == null) return null;
            for (int i = 0; i < n; i++)
            {
                encryptedText = DoDecrypt(encryptedText);
            }
            return encryptedText;
        }

        private static string DoDecrypt(string encryptedText)
        {
            var charArray = encryptedText.ToCharArray();
            var decryptArray = new List<char>();

            var mid = (charArray.Length / 2);
            var evens = charArray.Take(mid).ToArray();
            var odds = charArray.Skip(mid).Take(charArray.Length - mid).ToArray();

            var e = 0;
            var o = 0;

            for (var i = 1; i <= charArray.Length; i++)
            {
                if (i%2 == 0)
                {
                    decryptArray.Add(evens[e]);
                    e++;
                }
                else
                {
                    decryptArray.Add(odds[o]);
                    o++;
                }
            }

            return string.Join("",decryptArray);
        }
    }

    [TestFixture]
    public class SimpleEncryptionTests
    {
        [Test]
        public void EncryptExampleTests()
        {
            Assert.AreEqual("This is a test!", Kata.Encrypt("This is a test!", 0));
            Assert.AreEqual("hsi  etTi sats!", Kata.Encrypt("This is a test!", 1));
            Assert.AreEqual("s eT ashi tist!", Kata.Encrypt("This is a test!", 2));
            Assert.AreEqual(" Tah itse sits!", Kata.Encrypt("This is a test!", 3));
            Assert.AreEqual("This is a test!", Kata.Encrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", Kata.Encrypt("This is a test!", -1));
            Assert.AreEqual("hskt svr neetn!Ti aai eyitrsig", Kata.Encrypt("This kata is very interesting!", 1));
        }

        [Test]
        public void DecryptExampleTests()
        {
            Assert.AreEqual("This is a test!", Kata.Decrypt("This is a test!", 0));
            Assert.AreEqual("This is a test!", Kata.Decrypt("hsi  etTi sats!", 1));
            Assert.AreEqual("This is a test!", Kata.Decrypt("s eT ashi tist!", 2));
            Assert.AreEqual("This is a test!", Kata.Decrypt(" Tah itse sits!", 3));
            Assert.AreEqual("This is a test!", Kata.Decrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", Kata.Decrypt("This is a test!", -1));
            Assert.AreEqual("This kata is very interesting!", Kata.Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));
        }

        [Test]
        public void EmptyTests()
        {
            Assert.AreEqual("", Kata.Encrypt("", 0));
            Assert.AreEqual("", Kata.Decrypt("", 0));
        }

        [Test]
        public void NullTests()
        {
            Assert.AreEqual(null, Kata.Encrypt(null, 0));
            Assert.AreEqual(null, Kata.Decrypt(null, 0));
            Assert.AreEqual(null, Kata.Decrypt(null, 5));
            Assert.AreEqual(null, Kata.Encrypt(null, 5));
            Assert.AreEqual(null, Kata.Encrypt(null, 0));
        }

    }
}
