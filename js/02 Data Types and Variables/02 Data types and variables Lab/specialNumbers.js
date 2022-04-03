function specialNumbers(n) {


    let sum = 0;
    let isSpecial = false;

    for (let i = 1; i <= n; i++) {
    let lastDigit = n % 10;
    sum = n - lastDigit
       // console.log(`${i} -> ${sum && i ? 'True' : 'False'}`);
    }
}
specialNumbers(15);