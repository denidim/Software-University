function arrayModifier(arr) {
    let numbers = arr.shift().split(' ').map(Number);

    for (let line of arr) {
        let tokens = line.split(' ');
        let command = tokens[0];
        let index1 = Number(tokens[1]);
        let index2 = Number(tokens[2]);

        if (command === 'end') {
            console.log(numbers.join(', '));
        }

        if (command === 'swap') {

            let temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }

        if(command === 'multiply'){
            let result = numbers[index1] * numbers[index2];
            numbers[index1] = result;
        }

        if(command === 'decrease'){
            for(let i = 0; i < numbers.length; i++){
                numbers[i] --;
            }
        }
    }
}
arrayModifier([
    '23 -2 321 87 42 90 -123',
    'swap 1 3',
    'swap 3 6',
    'swap 1 0',
    'multiply 1 2',
    'multiply 2 1',
    'decrease',
    'end']);

arrayModifier([
    '1 2 3 4',
    'swap 0 1',
    'swap 1 2',
    'swap 2 3',
    'multiply 1 2',
    'decrease',
    'end']);