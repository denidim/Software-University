function solve(input) {
    let w = Number(input[0]);
    let l = Number(input[1]);
    let h = Number(input[2]);
    let command = input[3];
    let index = 4;
    let vol = w * l * h;
    let isFool = false;

    while (command !== "Done") {
        let boxes = Number(command);
        vol -= boxes;

        if (vol < 0) {
            isFool = true;
            console.log(`No more free space! You need ${Math.abs(vol)} Cubic meters more.`);
            break;
        }
        command = input[index];
        index++;
    }
    if (!isFool) {
        console.log(`${vol} Cubic meters left.`);
    }
}

solve(["10",
    "1",
    "2",
    "4",
    "6",
    "Done"])



