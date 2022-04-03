function maxNumber(input) {

    let inputEl = input[0];
    let index = 1;
    let max = Number.MIN_SAFE_INTEGER;

    while (inputEl !== 'Stop') {
        let num = Number(inputEl);

        if (num > max) {
            max = num;
        }
        inputEl = input[index];
        index++;
    }
    console.log(max);
}


maxNumber(["100",
    "99",
    "80",
    "70",
    "Stop"])
