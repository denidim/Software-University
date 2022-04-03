function nonDecreasing(numbers) {
    let sequence = [];
    let maxNum = 0;
    let firstNum = numbers[0];
    sequence.push(firstNum);

    for (let i = 1; i < numbers.length; i++) {
        let currentNum = numbers[i];

        if(currentNum >= firstNum){
            maxNum = currentNum;
            firstNum = currentNum;
        sequence.push(maxNum); 
        }else{
            continue;
        }     
    }
    console.log(sequence.join(' '));
}
nonDecreasing([1, 3, 8, 4, 10, 12, 3, 2, 24]);
nonDecreasing([1, 2, 3, 4]);
nonDecreasing([20, 3, 2, 15, 6, 1]);