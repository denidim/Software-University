function arrayManipulations(arr) {
    let numbers = arr
        .shift()
        .split(' ')
        .map(Number);

    for (let i = 0; i < arr.length; i++) {
        let [command, firstNum, secondNum] = arr[i].split(' ');
        firstNum = Number(firstNum);
        secondNum = Number(secondNum);
        switch (command) {
            case 'Add':
                numbers.push(firstNum);
                break;
            case 'Remove':
                let index = numbers.indexOf(firstNum);
                if (index > -1) {
                    numbers.splice(index, 1)
                }
                break;
            case 'RemoveAt':
                numbers.splice(firstNum, 1);
                break;
            case 'Insert':
                numbers.splice(secondNum, 0, firstNum);
                break;
        }
    }
    console.log(numbers.join(' '));
}
arrayManipulations(['4 19 2 53 6 43',
    'Add 3',
    'Remove 2',
    'RemoveAt 1',
    'Insert 8 3']);

arrayManipulations(['6 12 2 65 6 42',
    'Add 8',
    'Remove 12',
    'RemoveAt 3',
    'Insert 6 2']);