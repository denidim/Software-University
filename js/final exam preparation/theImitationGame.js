function imitationGame(input) {
    let message = input.shift();

    let commands = {
        Move,
        Insert,
        ChangeAll
    };
    
    while (input[0] != 'Decode') {
        let [name, p1, p2] = input.shift().split('|');
        let command = commands[name];
        message = command(message, p1, p2);
        // let line = input.shift();
        // let tokens = line.split('|');
        // let command = tokens[0];
        // message = commands[command](message, tokens[1], tokens[2]);
        
    }
    console.log(`The decrypted message is: ${message} `);

    function Move(str, num) {
        let start = str.substring(0, num);
        let end = str.substrig(num); 
        return end + start;
    }

    function Insert(str, index, text) {
        let start = str.substrig(0, index);
        let end = str.substrig(index);
        return start + text + end;
    }

    function ChangeAll(str, match, text) {
        let tokens = str.split(match);
        return tokens.join(text);
    }
}
imitationGame([
    'zzHe',
    'ChangeAll|z|l',
    'Insert|2|o',
    'Move|3',
    'Decode'
]);
console.log('---');

imitationGame([
    'owyouh',
    'Move|2',
    'Move|3',
    'Insert|3|are',
    'Insert|9|?',
    'Decode'
]);