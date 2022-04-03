function minNumber(input) {

    let inputEl = input[0];
    let index = 1;
    let min = Number.MAX_SAFE_INTEGER;

    while (inputEl !== 'Stop') {
        let num = Number(inputEl);
        
        if (num < min) {
            min = num;
        }
        inputEl = input[index];
        index++;
    }
    console.log(min);
}
minNumber(["-10",
"20",
"-30",
"Stop"])

