function sumFirstAndLast(array) {
    
    let first = Number(array.shift());
    let last = Number(array.pop());
    // let sum = Number(first) + Number(last);
    return first + last;  
}
let result = sumFirstAndLast(['20', '30', '40']);
console.log(result);
sumFirstAndLast(['5', '10']);