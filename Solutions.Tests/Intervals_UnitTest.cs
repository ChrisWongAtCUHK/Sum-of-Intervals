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
        public void NonOverlappingTest()
        {
            (int, int)[] intervals = new (int, int)[3];
            intervals[0].Item1 = 11;
            intervals[0].Item2 = 15;

            intervals[1].Item1 = 6;
            intervals[1].Item2 = 10;

            intervals[2].Item1 = 1;
            intervals[2].Item2 = 2;

            Assert.AreEqual(Intervals.SumIntervals(intervals), 9);
        }
    }
}