function sorting(numbers) {
    let sortedNum = [];
    let numbersLength = numbers.length;

    for (let i = 0; i < numbersLength; i++) {
        let num;
        if (i % 2 === 0) {
            num = Math.max(...numbers);
        } else {
            num = Math.min(...numbers);
        }
        sortedNum.push(num);
        numbers.splice(numbers.indexOf(num), 1);
    }
    console.log(sortedNum.join(' '));
}
sorting([1, 21, 3, 52, 69, 63, 31, 2, 18, 94]);
