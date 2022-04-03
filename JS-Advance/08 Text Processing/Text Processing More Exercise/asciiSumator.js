function solve(input) {
    let firstChar = input.shift().charCodeAt(0);
    let endtChar = input.shift().charCodeAt(0);
    let text = input.shift();

    let sum = 0;

    for (let i = 0; i < text.length; i++) {

        if ((text.charCodeAt(i) > firstChar && text.charCodeAt(i) < endtChar) ||
            (text.charCodeAt(i) > endtChar && text.charCodeAt(i) < firstChar)) {

            sum += text.charCodeAt(i);
        } else if (text.charCodeAt(i) == firstChar && text.charCodeAt(i) == endtChar) {
            let startIndex = text.indexOf(firstChar);
            let endIndex = text.indexOf(endtChar);

            text = text.substring(startIndex, endIndex);
            sum += text.charCodeAt(i);

        }
    }
    console.log(sum);
}





solve(['.',
    '@',
    'dsg12gr5653feee5']);

solve(['?',
    'E',
    '@ABCEF']);

solve(['a',
    '1',
    'jfe392$#@j24ui9ne#@$']);