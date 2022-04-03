function rightPlace(firstWord, char, secondWord) {
    let tmp = '';
    for (let i = 0; i < firstWord.length; i++) {

        if (firstWord[i] === '_') {
            tmp += char;
        } else {
            tmp += firstWord[i];
        }
    }
    if(tmp === secondWord){
        console.log('Matched');
    } else{
        console.log('Not Matched');
    }
}
rightPlace('Str_ng', 'I', 'Strong')