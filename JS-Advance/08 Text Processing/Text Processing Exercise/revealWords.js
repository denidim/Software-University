   function revealWords(words, text) {
    let word = words.split(', ');

    for (let i = 0; i < word.length; i++) {
        let string = '*'.repeat(word[i].length);
        if(text.includes(string)){

            text = text.replace(string,word[i]);

        }

    }

    console.log(text);
}
revealWords('great',
    'softuni is ***** place for learning new programming languages');

revealWords('great, learning',
    'softuni is ***** place for ******** new programming languages');