using NUnit.Framework;
using Solutions;

namespace Solutions.Tests
{
    public class IntervalsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Solutions1Test()
        {
            Assert.AreEqual(Intervals.SumIntervals(new (int, int)[3]), -1);
        }
    }
}