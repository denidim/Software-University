function amazingNumbers(num) {
    let numAsStr = num.toString();
    let sum = 0;

    for (let i = 0; i < numAsStr.length; i++) {
        let currentDigit = Number(numAsStr[i]);
        sum += currentDigit;
    }
    let sumAsStr = sum.toString();
    let hasNine = false;

    for (let i = 0; i < sumAsStr.length; i++) {
        if (sumAsStr[i] == '9') {
            hasNine = true;
            break;
        }
    }
    console.log(`${num} Amazing? ${hasNine ? 'True' : 'False'}`);
}
amazingNumbers(1233)