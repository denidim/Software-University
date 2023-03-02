function simpleCalculator(firstNum, secondNum, operator) {
    const add = (a, b) => a + b;
    const subtract = (a, b) => a - b;
    const divide = (a, b) => a / b;
    const multiply = (a, b) => a * b;

    const operatinMap = {
        add,
        subtract,
        divide,
        multiply
    }
    return operatinMap[operator](firstNum, secondNum);
}

simpleCalculator(5, 5, 'multiply');
simpleCalculator(40, 8, 'divide');