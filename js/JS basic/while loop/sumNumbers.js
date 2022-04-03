function sumNumbers(input) {

    let target = Number(input[0]);
    let sum = 0;
    let index = 1;

    while (sum <target) {
        let currentNum = Number(input[index]);
        sum +=currentNum;
        index++
    }
    console.log(sum);

}

sumNumbers(["100",
"10",
"20",
"30",
"40"])




