function oddOccurances(input) {
    let words = input.split(' ');
    let result = {};

    for (let word of words) {
        word = word.toLocaleLowerCase();
        if (result.hasOwnProperty(word)) {
            result[word]++;
        } else {
            result[word] = 1;
        }
    }

    let filtered = Object.entries(result)
        .filter(([word, count]) => count % 2 == 1)
        .map(entry => entry[0])
        .join(' ');

    console.log(filtered);
}
oddOccurances('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');

oddOccurances('Cake IS SWEET is Soft CAKE sweet Food')