using NUnit.Framework;
using Solutions;
using System;
using System.Collections.Generic;

namespace Solutions.Tests
{
    public class SumIntervals1_UnitTest
    {
        List<(int, int)[]> noOverlaps = new List<(int, int)[]>();
        List<(int, int)[]> overlaps = new List<(int, int)[]>();

        [SetUp]
        public void Setup()
        {
            #region non overlapping intervals
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
            #endregion
        
            #region overlapping intervals
            overlaps.Add(new (int, int)[2]
            {
                (1, 5),
                (1, 5)
            });
            overlaps.Add(new (int, int)[2]
            {
                (1, 5),
                (5, 10)
            });
            overlaps.Add(new (int, int)[5]
            {
                (1, 4),
                (3, 6),
                (5, 8),
                (7, 10),
                (9, 12)
            });
            overlaps.Add(new (int, int)[5]
            {
                (1, 4),
                (3, 6),
                (5, 8),
                (7, 10),
                (9, 12)
            });
            overlaps.Add(new (int, int)[3]
            {
                (1, 4),
                (7, 10),
                (3, 5)
            });
            overlaps.Add(new (int, int)[4]
            {
                (1, 20),
                (2, 19),
                (5, 15),
                (8, 12)
            });
            overlaps.Add(new (int, int)[5]
            {
                (1, 5),
                (10, 20),
                (1, 6),
                (16, 19),
                (5, 11)
            });
            overlaps.Add(new (int, int)[5]
            {
                (2, 3),
                (2, 6),
                (2, 4),
                (2, 9),
                (2, 5)
            });
            #endregion
        }

        [Test]
        public void NonOverlappingTest()
        {
            // SumIntervals1
            foreach(var intervals in overlaps)
            {
                Assert.AreEqual(Intervals.SumIntervals(intervals), Intervals.SumIntervals1(intervals));
            } 
        }

        [Test]
        public void OverlappingTest()
        {
            // SumIntervals1
            foreach(var intervals in noOverlaps)
            {
                Assert.AreEqual(Intervals.SumIntervals(intervals), Intervals.SumIntervals1(intervals));
            }
        }

        [Test]
        public void RandomTest()
        {
            for(var i = 0; i < 100; i++)
            {
                List<(int, int)[]> list = new List<(int, int)[]>();
                Random random = new Random();
                int randomNumber = random.Next(1, 20);
                (int, int)[] intervals = new (int, int)[randomNumber];
                for(var j = randomNumber; j > 0 ; j--)
                {
                    var x = random.Next(-500, 499);
                    var y = random.Next(x + 1, 500);
                    intervals[j - 1].Item1 = x < y ? x : y;
                    intervals[j - 1].Item2 = x > y ? x : y;
                }
                Assert.AreEqual(Intervals.SumIntervals(intervals), Intervals.SumIntervals1(intervals));
            }
        }
    }
}