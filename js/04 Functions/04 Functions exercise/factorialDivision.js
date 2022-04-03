function factorialDivision(firstNum, secondNum) {
  
    function factorial(n) {
        let fact = 1;
        for (let i = 2; i <= n; i++){
            fact = fact * i;
        }
        return fact;
    }
    
    let firstF = factorial(firstNum);
    let secondF = factorial(secondNum);
    let result = firstF / secondF;
    return result.toFixed(2);
}
let result = factorialDivision(5, 2);
console.log(result);
//factorialDivision(6, 2)