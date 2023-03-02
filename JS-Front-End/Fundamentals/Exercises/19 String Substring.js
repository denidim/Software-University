function solve(word, text) {
    let lowered = word.toLowerCase();
    let textArr = text.split(' ');

    for (const t of textArr) {
        if (t.toLowerCase() === lowered) {
            return word;
        }
        return (`${word} not found!`)
    }
}

console.log(
    solve('javascript', 'JavaScript is the best programming language'));
console.log(
    solve('python', 'JavaScript is the best programming language'));