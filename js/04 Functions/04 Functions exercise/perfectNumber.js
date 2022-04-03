function perfectNumber(n) {
    let sum = 0;
    for(let i = 1; i < n; i++){
        if(n % i === 0){
            sum += i;
        }
    }
    if(sum === n){
       return ' We have a perfect number!';
    }else{
        return 'It\'s not so perfect.';
    }
}
let result = perfectNumber(1236498);
console.log(result);
perfectNumber(28);
perfectNumber(1236498);