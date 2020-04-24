const sumIntervals = (intervals = []) => {
	let shallowClone = [...intervals]
	let sum = 0
	let length = shallowClone.length

	for(let i = 0; i < length; i++) {
		let interval = shallowClone[i]

		for(let j = i + 1; j < length; j++) {
			// there is an overlap
			if(shallowClone[j][0] < interval[1]) {
				if(shallowClone[j][0] < interval[0]) {
					// change the start
					interval[0] = shallowClone[j][0]
				}
				// change the end
				interval[1] = shallowClone[j][1]

				// remove element on the fly
				shallowClone.splice(j, 1)
				length--
			}
		}
		sum += interval[1] - interval[0]
	}

	return sum
}

module.exports = sumIntervals
