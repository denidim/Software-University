function triangleOfNumbers(n) {
    let str = '';
    for(let i = 1; i <= n; i++){
        str = ` ${i}`;
        console.log(str + str.repeat(i -1));
    }
}
triangleOfNumbers(3);
triangleOfNumbers(5);
triangleOfNumbers(6);