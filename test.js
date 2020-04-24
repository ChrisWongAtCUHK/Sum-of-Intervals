const sumIntervals = require('./kata')

const intervalsList = [
	[
   [1, 2],
   [6, 10],
   [11, 15]
	],
	[
		[1, 4],
		[7, 10],
		[3, 5]
	],
	[
   [1, 5],
   [10, 20],
   [1, 6],
   [16, 19],
   [5, 11]
	],
	[[1, 5]],
	[[1, 5], [6, 10]]
]

intervalsList.forEach((intervals) => {
	console.log(sumIntervals(intervals))
})

