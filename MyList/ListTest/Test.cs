using NUnit.Framework;
using StringExtantion;

namespace ListTest
{
    [TestFixture]
    public class Test
    {
        [Test]
        public static void TestContains()
        {
            var list = new List.List();

            int from = 0;
            int to = 3;
            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            for (int i = from; i <= to; i++)
            {
                Assert.True(list.Contains(i));
            }
            Assert.False(list.Contains(list.Contains(5)));

        }

        [Test]
        public static void TestAddFirstValue()
        {
            var list = new List.List();
            int value = 10;
            list.Add(value);

            Assert.AreEqual(value, (int)list[0]);
        }

        [Test]
        public static void TestAddFourValues()
        {
            var list = new List.List();

            int from = 0;
            int to = 3;
            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            for (int i = from; i <= to; i++)
            {
                Assert.AreEqual(i, (int)list[i]);
            }

        }

        [Test]
        public static void TestAddFifyhValues()
        {
            var list = new List.List();

            int from = 0;
            int to = 4;
            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(to, (int)list[to]);
        }

        [Test]
        public static void TestCountFirstValue()
        {
            var list = new List.List { 10 };

            int expectedResult = 1;

            Assert.AreEqual(expectedResult, list.Count);
        }

        [Test]
        public static void TestCountFourValues()
        {
            var list = new List.List();

            int from = 0;
            int to = 3;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            int expectedResult = to + 1;

            Assert.AreEqual(expectedResult, list.Count);
        }

        [Test]
        public static void TestCountFifyhValues()
        {
            var list = new List.List();

            int from = 0;
            int to = 4;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            int expectedResult = to + 1;

            Assert.AreEqual(expectedResult, list.Count);
        }

        [Test]
        public static void TestRemove()
        {
            var list = new List.List();

            int from = 0;
            int to = 4;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            list.Remove(5);
            list.Remove(1);

            int expectedResult = 4;

            Assert.AreEqual(expectedResult, list.Count);
        }

        [Test]
        public static void TestRemoveAt()
        {
            var list = new List.List();

            int from = 0;
            int to = 4;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            list.RemoveAt(0);

            int expectedResult = 4;

            Assert.AreEqual(expectedResult, list.Count);
        }

        [Test]
        public static void TestClear()
        {
            var list = new List.List();

            int from = 0;
            int to = 8;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            list.Clear();

            int expectedResult = 0;

            Assert.AreEqual(expectedResult, list.Count);
        }

        [Test]
        public static void TestIEnumetator()
        {
            var list = new List.List();
            int from = 0;
            int to = 4;

            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            bool result = false;

            foreach (var i in list)
            {
                result = true;
            }
            
            result = false;

            foreach (var i in list)
            {
                result = true;
            }

            Assert.True(result);
        }

        [Test]
        public static void TestStringExtantions()
        {
            string test = "1jhhbj2kjjj3lh4d5";
            List.List list = test.GetListIntegers();

            foreach (var item in list)
            {
                Assert.AreEqual(item.GetType(), typeof(int));
            }
        }
    }
}

