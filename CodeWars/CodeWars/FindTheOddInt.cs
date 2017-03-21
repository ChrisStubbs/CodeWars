using System.Linq;

namespace CodeWars
{
    using NUnit.Framework;

    public class FindTheOddInt
    {
        public static int FindIt(int[] seq)
        {
            var distinct = seq.Distinct();
            foreach (var i in distinct)
            {
                if (seq.Count(x => x == i) % 2 != 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FindIt2(int[] seq)
        {
           return seq.Where(x => seq.Count(z => z == x) % 2 == 1).ToList()[0];
        }
    }


    [TestFixture]
    public class FinsTheOddIntTest
    {
        [Test]
        public void TestFindIt()
        {
            Assert.AreEqual(5, FindTheOddInt.FindIt(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
        }

        [Test]
        public void TestFindIt2()
        {
            Assert.AreEqual(5, FindTheOddInt.FindIt2(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
        }
    }

}

