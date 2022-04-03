function sumNumbers(input) {

    let sum = Number(input[0]);
    let num = Number(input[1]);
    let index = 2;
    let total = 0;

    while (total < sum) {

        total += num;
        num = Number(input[index]);
        index++;  
    }
    console.log(total);

}

sumNumbers(["100",
"10",
"20",
"30",
"40"])

