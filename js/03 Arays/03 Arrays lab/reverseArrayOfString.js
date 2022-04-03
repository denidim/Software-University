function reverseArrayOfStr(array) {
    for(let i = 0; i < (array.length - 1) /2; i++){
        let k = (array.length - 1) - i;
        let temp = array[i];
        array[i] = array[k];
        array[k] = temp;
    }
    console.log(array.join(' '));
}
reverseArrayOfStr(['a', 'b', 'c', 'd', 'e']);
reverseArrayOfStr(['abc', 'def', 'hig', 'klm', 'nop']);
reverseArrayOfStr(['33', '123', '0', 'dd']);