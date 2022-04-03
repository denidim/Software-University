function solve(word, text) {
    let sentence = text.toLowerCase();
    let wordToLower = word.toLowerCase();
    let sentenceAsArray = sentence.split(' ');

    if(sentenceAsArray.includes(wordToLower)){
        console.log(wordToLower);
    }else{
        console.log(`${wordToLower} not found!`);
    }

}
solve('javascript',
'JavaScript is the best programming language'
);

solve('python',
'JavaScript is the best programming language'
);