function addAndSubtract(firstNumber, secondNumnber, thirdNumer) {

  function sum(firstNumber, secondNumber) {
    let result = firstNumber + secondNumber;
    return result;
  }
  
  function subtract(firstNumber, secondNumber) {
    let result = firstNumber - secondNumber;
    return result;
  }

  let sumNumbers = sum(firstNumber, secondNumnber);
  let result = subtract(sumNumbers, thirdNumer);
  return result;
}
let result = addAndSubtract(23, 6, 10);
console.log(result);