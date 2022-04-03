function solve([input]) {

    let threshold = 1;
    let coolEmojis = [];

    let digits = input.match(/\d/g).map(Number);
    for (let digit of digits) {
        threshold *= digit;
    }
    let emojis = input.match(/(::|\*\*)[A-Z][a-z]{2,}(\1)/g);
    if (emojis != null) {

        for (let emoji of emojis) {
            let coolness = 0;
            let chars = emoji.slice(2, -2);
            for (let char of chars) {
                coolness += char.charCodeAt(0);
            }
            if (coolness >= threshold) {
                coolEmojis.push(emoji);
            }
        }
    }
    console.log('Cool threshold: ' + threshold);
    console.log(`${emojis ? emojis.length : 0} emojis found in the text. The cool ones are:`);

    for (let emoji of coolEmojis) {
        console.log(emoji);
    }

}
solve(["In the Sofia Zoo there are 311 animals in total! ::Smiley:: This includes 3 **Tigers**, 1 ::Elephant:, 12 **Monk3ys**, a **Gorilla::, 5 ::fox:es: and 21 different types of :Snak::Es::. ::Mooning:: **Shy**"]);

solve(["5, 4, 3, 2, 1, go! The 1-th consecutive banana-eating contest has begun! ::Joy:: **Banana** ::Wink:: **Vali** ::valid_emoji::"]);

solve(["It is a long established fact that 1 a reader will be distracted by 9 the readable content of a page when looking at its layout. The point of using ::LoremIpsum:: is that it has a more-or-less normal 3 distribution of 8 letters, as opposed to using 'Content here, content 99 here', making it look like readable **English**."]);