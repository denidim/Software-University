function memoryGame(input) {

    let sequence = input.shift().split(' ');
    let moves = 0;

    while (input[0] !== 'end') {

        let tokens = input.shift().split(' ');
        let index1 = Number(tokens[0]);
        let index2 = Number(tokens[1]);
        moves++;
        if (index1 < 0 || index2 < 0
            || index1 >= sequence.length
            || index2 >= sequence.length
            || index1 === index2) {

            let index = Math.trunc(sequence.length / 2);
            let elToAdd = '-' + moves + 'a';
            sequence.splice(index, 0, elToAdd, elToAdd);
            console.log("Invalid input! Adding additional elements to the board");
           
        } else if (sequence[index1] == sequence[index2]) {

            let num1 = sequence[index1];
            let num2 = sequence[index2];
            if (num1 === num2) {
                sequence.splice(index1, 1);
                index2 = sequence.indexOf(num2);
                sequence.splice(index2, 1)

                console.log(`Congrats! You have found matching elements - ${num1}!`);
            }

            if (sequence.length == 0) {
                console.log(`You have won in ${moves} turns!`);
                break;
            }

        } else if (sequence[index1] !== sequence[index2]) {
            console.log("Try again!");
            moves++;
        }
    }

    if (sequence.length > input.length) {
        console.log(`Sorry you lose :(\n${sequence.join(' ')}`);
    }
}
memoryGame([
    "1 1 2 2 3 3 4 4 5 5",
    "1 0",
    "-1 0",
    "1 0",
    "1 0",
    "1 0",
    "end"
]);

memoryGame([
    "a 2 4 a 2 4",
    "0 3",
    "0 2",
    "0 1",
    "0 1",
    "end"
]);

memoryGame([
    "a 2 4 a 2 4",
    "4 0",
    "0 2",
    "0 1",
    "0 1",
    "end"
]);