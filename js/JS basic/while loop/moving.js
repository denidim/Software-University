function moving(input) {

    let w = Number(input[0])
    let l = Number(input[1]);
    let h = Number(input[2]);

    let volume = w * l * h;

    let index = 3;
    let sum = 0;
    let command = input[index];

    while (command !== 'Done') {
        sum += Number(command);
        index++;
        if (sum > volume) {
            break;
        }
        command = input[index];
    }
    if (sum > volume) {

        console.log(`No more free space! You need ${sum - volume} Cubic meters more.`);
    } else {
        console.log(`${volume - sum} Cubic meters left.`);
    }
}

moving(["10", "1", "2", "4", "6", "Done"])



