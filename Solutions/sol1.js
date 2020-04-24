/* eslint-disable */
function sumIntervals(intervals){
  const result = intervals
    .sort(function(a, b){
      if (a[0] < b[0]) return -1;
      if (a[0] > b[0]) return 1;
      return 0;
    })
    .reduce(function(acc, interval) {
      if (interval[1] > acc.top) {
        acc.total += interval[1] - Math.max(interval[0], acc.top);
      }
      acc.top = Math.max(interval[1], acc.top);
      return acc;
    }, {total: 0, top: -Infinity})
		.total;
	return result
}

module.exports = sumIntervals
