/* eslint-disable */
const { expect } = require('chai')
const sumIntervals = require('./kata')
Array.prototype.shuffle = function(){
  var ran1, ran2, tmp;
  for(var i=0; i<this.length*2; i++){
    ran1 = Math.floor(Math.random()*this.length);
    ran2 = Math.floor(Math.random()*this.length);
    tmp = this[ran1]
    this[ran1] = this[ran2];
    this[ran2] = tmp;
  }
  return this;
}

describe('sumIntervals', function(){
  
  it('should return the correct sum for non overlapping intervals', function(){
    var noOverlaps = [
      [
        [1,5]
      ],
      [
        [1,5],
        [6,10]
      ],
      [
        [11, 15],
        [6, 10],
        [1,2]
      ],
    ];
    noOverlaps.shuffle();
    var sol;
    for(var i=0; i<noOverlaps.length; i++){
      sol = solution(noOverlaps[i]);
      expect(sumIntervals(noOverlaps[i])).eql(sol); 
    }
  });
  
  it('should return the correct sum for overlapping intervals', function(){
    var overlaps = [
      [
        [1,5],
        [1,5]
      ],
      [
        [1,5],
        [5,10]
      ],
      [
        [1,4],
        [3,6],
        [5,8],
        [7,10],
        [9,12]
      ],
      [
        [1,4],
        [7, 10],
        [3, 5]
      ],
      [
        [1,20],
        [2,19],
        [5,15],
        [8,12]
      ],
      [
        [1,5],
        [10, 20],
        [1, 6],
        [16, 19],
        [5, 11]
      ],
      [
        [2, 3],
        [2, 6],
        [2, 4],
        [2, 9],
        [2, 5]
      ]
    ];
    overlaps.shuffle();
    var sol;
    for(var i=0; i<overlaps.length; i++){
      sol = solution(overlaps[i]);
      expect(sumIntervals(overlaps[i])).eql(sol); 
    }    
  });
  
});
function solution(_intervals){
  var intervals = _intervals.slice();
  intervals = intervals.sort(function(a, b){
    return a[0] - b[0];
  });
  for(var i=1; i<intervals.length; i++){
    if(intervals[i-1][0] <= intervals[i][0] && intervals[i][0] <= intervals[i-1][1]){
      intervals[i-1][1] = Math.max(intervals[i-1][1], intervals[i][1]);
      intervals.splice(i--, 1);
    }
  }
  return intervals.map(function(e){
    return e[1] - e[0];
  })
  .reduce(function(a, b){
    return a + b;
  });  
}

const randint = (a, b) => a + ~~(Math.random() * (b - a + 1));

describe("Random tests", function() {
  it("Tests", function() {
    for (let i = 0; i < 100; i++) {
      let a = [];
      for (let j = randint(1, 20); j; j--) {
        let x = randint(-500, 499),
            y = randint(x + 1, 500);
        a.push(x < y ? [x, y] : [y, x]);
      }
      let result = solution(a);
      expect(sumIntervals(a)).eql(result);
    }
  });
});
