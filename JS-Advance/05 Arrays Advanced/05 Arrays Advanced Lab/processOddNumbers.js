function processOddN(numbers) {
    
        let result = [];
        for (let i = 0; i < numbers.length; i++) {
            if (i % 2 !== 0) {
                let currentNum = numbers[i];
                currentNum *= 2;
                result.push(currentNum);
            }
        }
        result.reverse();
        console.log(result.join(' '));
}
processOddN([10, 15, 20, 25]);
processOddN([3, 0, 10, 4, 7, 3]);