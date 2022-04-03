function sumEvenNum(array) {
let sum = 0;
    for (let i = 0; i < array.length; i ++){
        array[i] = Number(array[i]);
        if(array[i] % 2 === 0){
            sum += array[i];
        } 
    }
    console.log(sum);
}
sumEvenNum(['1','2','3','4','5','6']);
sumEvenNum(['3','5','7','9']);
sumEvenNum(['2','4','6','8','10']);