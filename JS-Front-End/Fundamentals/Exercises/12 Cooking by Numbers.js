function solve(num, op1, op2, op3, op4, op5) {
    let number = Number(num);
    let arr = [];
    arr.push(op1);
    arr.push(op2);
    arr.push(op3);
    arr.push(op4);
    arr.push(op5);

    for (let i = 0; i < arr.length; i++) {
        if (arr[i] == 'chop') {
            number = number / 2;
            console.log(number);
        }
        else if (arr[i] == 'dice') {
            number = Math.sqrt(number);
            console.log(number);
        }
        else if (arr[i] == 'dice') {
            number = Math.sqrt(number);
            console.log(number);
        }
        else if (arr[i] == 'spice') {
            number = number + 1;
            console.log(number);
        }
        else if (arr[i] == 'bake') {
            number = number * 3;
            console.log(number);
        }
        else if (arr[i] == 'fillet') {
            number = number - 0.2 * number
            console.log(number);
        }
    }
}

// solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');