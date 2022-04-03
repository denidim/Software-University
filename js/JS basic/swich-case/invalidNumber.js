function invalidNumber(input) {

    let n = Number(input[0]);
    let isValid = n >= 100 && n <= 200 || n === 0;

    if (!isValid) {
        console.log('invalid');
    }
}

invalidNumber(['75']);