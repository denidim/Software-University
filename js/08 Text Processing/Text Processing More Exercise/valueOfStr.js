function solve(input) {
    let text = input.shift();
    let command = input.shift();

    let sum = 0;

    for (let i = 0; i < text.length; i++) {

        let num = text.charCodeAt(i);

        if (command === 'LOWERCASE') {

            if (num >= 97 && num <= 122) {
                sum += num;
            }

        } else {
            if (num >= 65 && num <= 90) {
                sum += num;
            }
        }
    }
    console.log(`The total sum is: ${sum}`);
}

solve(['HelloFromMyAwesomePROGRAM',
    'LOWERCASE']);

solve(['AC/DC',
    'UPPERCASE']);
