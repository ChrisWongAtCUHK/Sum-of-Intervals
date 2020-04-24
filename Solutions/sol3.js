/* eslint-disable */
function sumIntervals(intervals) {
  const ranges = new Set();
  
  intervals.forEach(([start, end]) => {
    for (let i = start; i < end; i++) ranges.add(i);
  });
  
  return ranges.size;
}
