function movingTarget(input) {
    let targets = input.shift().split(' ').map(Number);

    while (input[0] !== 'End') {
        let tokens = input.shift().split(' ');

        let command = tokens[0];
        let index = Number(tokens[1]);
        let num = Number(tokens[2]);

        if (command === 'Shoot') {

            if (index >= 0 && index < targets.length) {
                targets[index] -= num;
                if (targets[index] <= 0) {
                    targets.splice(index, 1);
                }
            }

        } else if (command === 'Add') {
            if (index >= 0 && index < targets.length) {
                targets.splice(index, 0, num);
            } else {
                console.log("Invalid placement!");
            }

        } else if (command === 'Strike' && index >= 0 && index < targets.length) {
            if (index - num >= 0 && index + num < targets.length) {
               targets.splice(index - num, num + num + 1);
            } else {
                console.log("Strike missed!");
            }
        }
    }
    console.log(targets.join('|'));
}

movingTarget(["52 74 23 44 96 110",
    "Shoot 5 10",
    "Shoot 1 80",
    "Strike 2 1",
    "Add 22 3",
    "End"])

movingTarget(["1 2 3 4 5",
    "Strike 0 1",
    "End"])
