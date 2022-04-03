function charactersInRange(firstCharacter, secondCharacter) {
    let min = firstCharacter.charCodeAt(0);
    let max = secondCharacter.charCodeAt(0);

    let firstCharAsNumber = firstCharacter.charCodeAt(0);
    let secondCharAsNumber = secondCharacter.charCodeAt(0);

    if (firstCharAsNumber > secondCharAsNumber) {
        min = secondCharacter.charCodeAt(0);
        max = firstCharacter.charCodeAt(0);
    }
    let result = '';

    for (let i = min + 1; i < max; i++) {
        let character = String.fromCharCode(i);
        result += character + ' ';
    }
    return result;
}
let result = charactersInRange('#', ':');
console.log(result);
charactersInRange('#', ':');
charactersInRange('C', '#');
