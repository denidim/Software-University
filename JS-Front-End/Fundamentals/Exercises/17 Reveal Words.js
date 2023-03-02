function solve(string, text) {
    let strArr = string.split(", ");
    strArr.forEach(element => {
        let toReplace = '*'.repeat(element.length);
        text = text.replace(toReplace, element);
    });
    console.log(text)
}

solve('great', 'softuni is ***** place for learningnew programming languages');
solve('great, learning', 'softuni is ***** place for ******** new programming languages');