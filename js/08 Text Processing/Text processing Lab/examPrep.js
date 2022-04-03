function solve(input) {
    let commands = {
        Move,
        Insert,
        ChangeAll
    };

    // take encoded message
    let message = input.shift();

    // repeat for every line of input
    while (input[0] != 'Decode') {
        // - parse line
        let [name, param1, param2] = input.shift().split('|');

        // - find and execute command with parse parameters
        let command = commands[name];
        message = command(message, param1, param2);
    }

    // print result
    console.log(`The decrypted message is: ${message}`);

    function Move(str, num) {
        // take first n letters
        let start = str.substring(0, num);
        // take remaining letters
        let end = str.substring(num);
        // return end + start
        return end + start;
    }

    function Insert(str, index, text) {
        // take first half
        let start = str.substring(0, index);
        // take second half
        let end = str.substring(index);
        // return first + text + second
        return start + text + end;
    }

    function ChangeAll(str, match, text) {
        // tokenize by removing match
        let tokens = str.split(match);
        // stitch by text
        return tokens.join(text);
    }
}


solve([
    'zzHe',
    'ChangeAll|z|l',
    'Insert|2|o',
    'Move|3',
    'Decode',
]);

console.log('---');

solve([
    'owyouh',
    'Move|2',
    'Move|3',
    'Insert|3|are',
    'Insert|9|?',
    'Decode',
]);