function substring(text, startIndex, numChar) {
    let result = text.substring(startIndex, (numChar + startIndex) )
    console.log(result);
}
substring('ASentence', 1, 8);

substring('SkipWord', 4, 7);