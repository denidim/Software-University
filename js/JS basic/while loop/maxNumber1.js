function maxNumber(input) {
    let data = input[0];
    let max = Number.MIN_SAFE_INTEGER;
    let index = 1;

    while (data !== 'Stop') {
        let num = Number(data);

        if (num > max) {
            max = num;
        }
        data = input[index];
        index++;
    
        
    }
    console.log(max);

}
maxNumber(["-10",
    "20",
    "-30",
    "Stop"])

