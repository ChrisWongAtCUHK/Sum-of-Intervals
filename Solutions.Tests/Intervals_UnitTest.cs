using NUnit.Framework;
using Solutions;
using System.Collections.Generic;

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
            var noOverlaps = new List<(int, int)[]>();
            noOverlaps.Add(new (int, int)[1]
            {
                (1, 5)
            });

            noOverlaps.Add(new (int, int)[2]
            {
                (1, 5),
                (6, 10)
            });

            noOverlaps.Add(new (int, int)[3]
            {
                (11, 15),
                (6, 10),
                (1, 2)
            });

            foreach(var intervals in noOverlaps)
            {
                Assert.AreEqual(Intervals.SumIntervals(intervals), Intervals.SumIntervals1(intervals));
            } 
        }
    }
}