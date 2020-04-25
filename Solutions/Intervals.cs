using System;
using System.Linq;

namespace Solutions
{
    public class Intervals
    {
        /// <summary>
        /// Javascript default solution
        /// </summary>
        /// <returns></returns>
        public static int SumIntervals((int, int)[] intervals)
        {
            var sorted = intervals.OrderBy(interval => interval.Item1).ToArray<(int, int)>();
            var length = sorted.Length;
            for(var i = 1 ; i < length; i++)
            {
                if(sorted[i - 1].Item1 <= sorted[i].Item1 && sorted[i].Item1 <= sorted[i - 1].Item2)
                {
                    sorted[i - 1].Item2 = sorted[i - 1].Item2 > sorted[i].Item2 ? sorted[i - 1].Item2 : sorted[i].Item2;

                    // as javascript splice
                    var beforeI = new (int, int)[i];
                    Array.Copy(sorted, 0, beforeI, 0, i);

                    var afterI = new (int, int)[sorted.Length - i - 1];
                    Array.Copy(sorted, i + 1, afterI, 0, sorted.Length - i - 1);

                    sorted = beforeI.Concat(afterI).ToArray<(int, int)>();
                    length--;
                    i--;
                }
            }

            return sorted.Select(interval => interval.Item2 - interval.Item1).Sum();
        }

        /// <summary>
        /// Simulate Javascript best practice solution
        /// </summary>
        /// <returns></returns>
        public static int SumIntervals1((int, int)[] intervals)
        {
            var sorted = intervals.OrderBy(interval => interval.Item1).ToArray<(int, int)>();

            return sorted.Aggregate(
                new { Total = 0, Top = int.MinValue},
                (acc, interval) => 
                {
                    var total = acc.Total;
                    var top = acc.Top;
                    if(interval.Item2 > acc.Top)
                    {
                        var max = interval.Item1 > acc.Top ? interval.Item1 : acc.Top;
                        total += interval.Item2 - max;
                    }
                    top = interval.Item2 > acc.Top ? interval.Item2 : acc.Top;
                    return new { Total = total, Top = top};
                }
            ).Total;
        }
    }
}
