function ladyBugs(arr) {

    let lenght = arr.shift();
    let index = arr.shift().split(' ');

    for(let i = 0; i < lenght; i++){
        let command = arr[i];
        let tokens = command.split(' ');
        
        if(tokens[1] === 'right'){
            index = tokens[0];
        }
    }
}
ladyBugs([ 3, '0 1',
'0 right 1',
'2 right 1' ]);

ladyBugs([ 3, '0 1 2',
'0 right 1',
'1 right 1',
'2 right 1']);