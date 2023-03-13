function oddAndEvenSum(num){
    let array = [...num.toString()];
    let sumEven = 0;
    let sumOdd = 0;

    for (let i = 0; i < array.length; i++) {
        if(Number(array[i])%2===0){
            sumEven += Number(array[i]);
        }else{
            sumOdd += Number(array[i]);
        }
    }

    return `Odd sum = ${sumOdd}, Even sum = ${sumEven}`
}

console.log(oddAndEvenSum(1000435));