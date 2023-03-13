function factorialDivision(a, b) {
    return (getFactorial(a)/getFactorial(b)).toFixed(2);
    function getFactorial(num) {
        if (num === 1) {
            return num;
        }

        return num * getFactorial(num - 1);
    }

}

console.log(
factorialDivision(5, 2));