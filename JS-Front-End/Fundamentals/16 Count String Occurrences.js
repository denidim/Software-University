function solve(text, word) {
    let words = text.split(' ');
    let counter = 0;
    words.forEach(element => {
        if (element === word) {
            counter++;
        }
    });

    console.log(counter);
}

solve('This is a word and it also is a sentence', 'is');
solve('softuni is great place for learning newprogramming languages', 'softuni');