function magicSum(arr, n) {
    let arrayOfNumbers = arr;
    let num = n;
    let arrayLength = arrayOfNumbers.length;
    
    for (let i = 0; i < arrayLength; i++) {
        let currentNum = arrayOfNumbers[i];

        for (let j = i + 1; j < arrayLength; j++) {
            let nextNum = arrayOfNumbers[j];

            if (currentNum + nextNum === num) {
                console.log(currentNum + ' ' + nextNum);
            }
        }
    }
}
magicSum([1, 7, 6, 2, 19, 23], 8);
magicSum([14, 20, 60, 13, 7, 19, 8], 27);
magicSum([1, 2, 3, 4, 5, 6], 6);