function evenAndOddSub(array) {
    sumEven = 0;
    sumOdd = 0;
    
    for(let i = 0; i < array.length; i ++){
        array[i] = Number(array[i]);

        if(array[i] % 2 === 0){
            sumEven += array[i];
        } else{
            sumOdd += array[i];
        }
    }
    console.log(sumEven - sumOdd);
}
evenAndOddSum([1,2,3,4,5,6]);
evenAndOddSum([3,5,7,9]);
evenAndOddSum([2,4,6,8,10]);