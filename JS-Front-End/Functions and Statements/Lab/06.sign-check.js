function signCheck(...numbers) {
    return numbers
        .filter((num) => num < 0)
        .length % 2 === 0 ? 'Positive' : 'Negative'
}

console.log(signCheck(5, 12, -15));