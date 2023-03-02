function solve(text) {
    text = text.split(' ');
    text.forEach(element => {
        if (element.startsWith('#') && element.length > 1) {
            let toPush = element.substring(1, 1 + element.length);
            if (/^[a-zA-Z]+$/.test(toPush)) {
                console.log(toPush)
            }
        }
    });
}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve('The symbol # is known #variously in English-speaking #regions as the #number sign');