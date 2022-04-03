let calculator = (a, b, operator) => console.log(({
        'multiply': (a, b) => a * b,
        'divide': (a, b) => a / b,
        'add': (a, b) => a + b,
        'substract': (a, b) => a - b,
    })[operator](a, b));

   


calculator(5, 5, 'multiply');
calculator(40, 8, 'divide');
calculator(12, 19, 'add');
calculator(50, 13, 'substract');

