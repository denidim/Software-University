function WordTracker(input) {
    let searchedWords = input.shift().split(' ');
    let words = {};
    for (const word of searchedWords) {
        let filtered = input.filter((w) => w === word);
        words[word] = filtered.length;
    }

    let sorted = Object.entries(words).sort((a, b) => b[1] - a[1]);

    for (const [word, count] of sorted) {
        console.log(`${word} - ${count}`)
    }
}

WordTracker([

    'is the',

    'first', 'sentence', 'Here', 'is',

    'another', 'the', 'And', 'finally', 'the',

    'the', 'sentence'])