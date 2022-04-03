function firstAndLastK(numbers) {
    let k = numbers.shift(0);
let firstSlice = numbers.slice(0, k);
let lastSlice = numbers.slice(numbers.length - k);
    /*let k = numbers.shift(0);
    let firstK = [];
    let lastK = [];
    for (let i = 0; i < k; i++) {
        firstK.push(numbers[i]);
    }
    for (let j = numbers.length - k; j < numbers.length; j++) {
        lastK.push(numbers[j]);
    }
    */
    console.log(firstSlice.join(' '));
    console.log(lastSlice.join(' '));
    

}
firstAndLastK([2, 7, 8, 9]);
firstAndLastK([3, 6, 7, 8, 9]);