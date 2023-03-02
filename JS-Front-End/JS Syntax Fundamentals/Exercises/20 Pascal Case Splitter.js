function solve(text) {
    let output = '';
    for (const symbol of text) {
        const asciiCode = symbol.charCodeAt(0);
        if (asciiCode >= 65 && asciiCode <= 90) {
            if (output.length > 0) {
                output += ', '
            }
            output += symbol;
        }
        else {
            output += symbol;
        }
    }

    console.log(output);
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
solve('HoldTheDoor');