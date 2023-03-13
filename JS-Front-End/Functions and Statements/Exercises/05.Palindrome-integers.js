function palindromeIntegers(array) {
    return array.map((element) => Number([...element.toString()].reverse().join('')) === element)
        .join('\n');
}

console.log(
    palindromeIntegers([123, 323, 421, 121]));