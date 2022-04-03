function solve(arr) {
    let longestSequence = [];


    for (let i = 0; i < arr.length; i++) {

        let currentEl = arr[i];
        let currentSequence = [currentEl];

        for (let j = i + 1; j < arr.length; j++) {
            let nextEl = arr[j];

            if (nextEl === currentEl) {
                currentSequence.push(nextEl);
            } else {
                break;
            }
        }
        if (currentSequence.length > longestSequence.length) {
            longestSequence = currentSequence;
        }
    }
console.log(longestSequence.join(' '));
}

solve([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);

solve([1, 1, 1, 2, 3, 1, 3, 3]);

