function wordsTracker(input) {
    let words = input.shift().split(' ');
    let result = {};

    for (let word of words) {
        result[word] = 0;
    }

    for (let word of input) {
        if (result.hasOwnProperty(word)) {
            result[word]++;
        }
    }

    let sorted = Object.entries(result);
    sorted.sort((a, b)=> b[1] - a[1]);

    for(let [word, count] of sorted){
        console.log(word, '-', count);
    }
}

wordsTracker([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurances', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
]);

wordsTracker([
    'is the',
    'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']);