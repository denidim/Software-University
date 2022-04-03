function reverseString(str) {
    let word = str.split('');
    let reverseWord = word.reverse();
    let newWord = reverseWord.join('');
    console.log(newWord);

}
reverseString('1234')