function solve(input) {
    let text = input.shift();

    while (input[0] != 'Reveal') {

        let tokens = input.shift().split(':|:');
        let name = tokens[0];
        let p1 = tokens[1];
        let p2 = tokens[2];

        if (name == 'InsertSpace') {
            let index = Number(p1);
            let left = text.slice(0, index);
            let right = text.slice(index);
            text = left + ' ' + right;
            console.log(text);

        } else if (name == 'Reverse') {
            let index = text.indexOf(p1);

            if (index != -1) {
                let left = text.slice(0, index);
                let right = text.slice(index + p1.length);
                text = left + right + p1.split('').reverse().join('');
                console.log(text);
            } else {
                console.log('error');
            }

        } else if (name == 'ChangeAll') {
            text = text.split(p1).join(p2);
            console.log(text);
        }
    }
    console.log(`You have a new text message: ${text}`);

}
solve([
    'heVVodar!gniV',
    'ChangeAll:|:V:|:l',
    'Reverse:|:!gnil',
    'InsertSpace:|:5',
    'Reveal'
]);

console.log('---');

solve([
    'Hiware?uiy',
    'ChangeAll:|:i:|:o',
    'Reverse:|:?uoy',
    'Reverse:|:jd',
    'InsertSpace:|:3',
    'InsertSpace:|:7',
    'Reveal'
]);