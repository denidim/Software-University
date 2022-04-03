function demo(input) {
    let result = [];
    for (let word of input.split(' ')) {

        if (word[0] == '#' && word.length !== 1) {
            result.push(word.substring(1));
        }
    }
    let finalResult = [];
    for (let el of result) {
        let arr = el.split('');
        let flag = true;
        for (let i = 0; i < arr.length; i++) {
            let currCode = arr[i].charCodeAt(0);
            if ((currCode < 97 || currCode > 122) &&
                (currCode < 65 || currCode > 90)) {
                flag = false;
            }
        } if (flag) {
            finalResult.push(el);
        }
    }
    finalResult.forEach(el => console.log(el));

}
demo('Nowadays everyone uses # to tag a #special word in #socialMedia')
demo('The symbol # is known #variously in English-speaking #regions as the #number sign')