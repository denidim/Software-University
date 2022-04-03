function negativeOrPositive(numbers) {
    let newArray = [];
    for (let number of numbers) {
        if (number < 0) {
            newArray.unshift(number);
        } else {
            newArray.push(number);
        }
    }
    for (let i = 0; i < newArray.length; i++) {
        let number = newArray[i];
        console.log(number);
    }
}
negativeOrPositive([7, -2, 8, 9]);
negativeOrPositive([3, -2, 0, -1]);