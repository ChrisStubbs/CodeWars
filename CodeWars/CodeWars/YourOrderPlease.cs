using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace CodeWars
{
	public class YourOrderPlease
	{
		public static string Order(string words)
		{
			if (string.IsNullOrEmpty(words)) return words;

			var wordSplit = words.Split(' ');
			var wordArray = new string[wordSplit.Length];

			foreach (var word in wordSplit)
			{
				var position = int.Parse(Regex.Match(word, @"\d+").Value);
				wordArray[position - 1] = word;
			}

			return string.Join(" ", wordArray);
		}
	}

	[TestFixture]
	public class YourOrderPleaseTests
	{
		[Test, Description("Sample Tests")]
		public void SampleTest()
		{
			Assert.AreEqual("Thi1s is2 3a T4est", YourOrderPlease.Order("is2 Thi1s T4est 3a"));
			Assert.AreEqual("Fo1r the2 g3ood 4of th5e pe6ople", YourOrderPlease.Order("4of Fo1r pe6ople g3ood th5e the2"));
			Assert.AreEqual("", YourOrderPlease.Order(""));
		}
	}
}


