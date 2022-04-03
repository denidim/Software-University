function distinctArray(numbers) {
    let resultArr = [];
    for(let i = 0; i < numbers.length; i++){
        let currentNumber = numbers[i];

        if(!resultArr.includes(currentNumber)){
            resultArr.push(currentNumber);
        }
    }
    console.log(resultArr.join(' '));
}
//distinctArray([1, 2, 3, 4]);
distinctArray([7, 8, 9, 7, 2, 3, 4, 1, 2]);
distinctArray([20, 8, 12, 13, 4, 4, 8, 5]);