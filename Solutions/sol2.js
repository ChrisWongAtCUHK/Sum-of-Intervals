/* eslint-disable */
function sumIntervals(intervals){
  var numbers = [];
  intervals.forEach( function(interval) {
    for (var i = interval[0] ; i < interval[1] ; i++) {
      if (numbers.indexOf(i) == -1) numbers.push(i);
    }
  });
  return numbers.length;
}

let intervals = [[-139,97],[5,211],[70,487],[231,455],[25,402],[429,460],[-157,263],[419,472],[-174,487],[54,410]]
console.log(sumIntervals(intervals))

module.exports = sumIntervals
