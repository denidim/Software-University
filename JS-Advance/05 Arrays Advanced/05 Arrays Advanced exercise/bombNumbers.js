function bombNumbers(sequence, bomb) {
let specialNum = bomb[0];
let bombPow = bomb[1];

while (sequence.includes(specialNum)) {
    let index = sequence.indexOf(specialNum);
    let elToRemove = bombPow * 2 + 1;
    let startIndex = index - bombPow;

    if(startIndex < 0){
        elToRemove += startIndex;
        startIndex = 0;
    }
    sequence.splice(startIndex, elToRemove);
}
let result = sequence.reduce((a, b) =>{
    return a + b;
}, 0);
console.log(result);
}
bombNumbers([1, 2, 2, 4, 2, 2, 2, 9],
             [4, 2]);

bombNumbers([1, 4, 4, 2, 8, 9, 1],
             [9, 3]);

bombNumbers([1, 7, 7, 1, 2, 3],
             [7, 1]);

bombNumbers([1, 1, 2, 1, 1, 1, 2, 1, 1, 1],
             [2, 1]);