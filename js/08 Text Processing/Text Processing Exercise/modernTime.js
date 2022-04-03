function solve(input) {
let words = input.split(' ');
    for (let word of words) {
        
        if (word.startsWith('#') && word.length > 1) {
           let asciiCode = word.charCodeAt(1);
            let isLetter = (asciiCode >= 65 && asciiCode <=90) ||
             (asciiCode >= 97 && asciiCode <= 122)
            if(isLetter){
               console.log(word.substring(1));
            }
        }
    }

}
solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve('The symbol # is known #variously in English-speaking #regions as the #number sign');