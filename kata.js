const sumIntervals = (intervals = []) => {
	let shallowClone = [...intervals]
	let length = shallowClone.length

	for(let i = 0; i < length; i++) {
		let start = shallowClone[i][0]
		let end = shallowClone[i][1]

		for(let j = i + 1; j < length; j++) {
			let overlap = false

			// overlap
			if(shallowClone[j][0] < start &&
				start < shallowClone[j][1]) {
				// change the start
				start = shallowClone[j][0]
				overlap = true
			}

			//  overlap
			if(shallowClone[j][0] < end &&
				end < shallowClone[j][1]) {
				// change the end
				end = shallowClone[j][1]
				overlap = true
			}

			// overlap
			if(shallowClone[j][0] >= start &&
				shallowClone[j][1] <= end) {
				overlap = true
			}

			if(overlap) {
				// remove element on the fly
				shallowClone.splice(j, 1)
				length--
			}
		}

		if(shallowClone[i][0] !== start || shallowClone[i][1] !== end) {
			shallowClone[i][0] = start
			shallowClone[i][1] = end
			i--
		}
	}

	return shallowClone.reduce((cur, next) => cur + (next[1] - next[0]), 0)
}

module.exports = sumIntervals
