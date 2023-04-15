function ExtractElement(input) {
    let arr = input.toLowerCase().split(' ');
    let words = [];

    for (const word of arr) {
        if(words.includes(word)){
            continue;
        }
        let filtered = arr.filter((w)=>w === word);
        if(filtered.length % 2 !== 0){
            words.push(word);
        }
    }
    console.log(...words);
}


ExtractElement('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');