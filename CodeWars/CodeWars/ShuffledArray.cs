namespace CodeWars
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    public class Kata1
    {
        public int[] ShuffledArray(int[] shuffled)
        {

            for (var i = 0; i < shuffled.Length; i++)
            {
                var list = shuffled.ToList();
                var item = list[i];

                list.RemoveAt(i);

                var sum = list.Sum();

                if (sum == item)
                {
                    return list.OrderBy(x => x).ToArray();
                }
            }
            
            return shuffled;

        }
    }

    [TestFixture]
    public class ShuffledArrayTests
    {
        [Test]
        public void BasicTests()
        {
            var kata = new Kata1();

            Assert.AreEqual(new int[] { 1, 2, 3, 6 }, kata.ShuffledArray(new int[] { 1, 12, 3, 6, 2 }));

            Assert.AreEqual(new int[] { -5, -3, 2, 7 }, kata.ShuffledArray(new int[] { 1, -3, -5, 7, 2 }));

            Assert.AreEqual(new int[] { -1, -1, 2, 2 }, kata.ShuffledArray(new int[] { 2, -1, 2, 2, -1 }));

            Assert.AreEqual(new int[] { -3 }, kata.ShuffledArray(new int[] { -3, -3 }));


        }

    }
}