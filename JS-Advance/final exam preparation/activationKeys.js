function solve(input) {
    rawKey = input.shift();

    while (input[0] !== 'Generate') {
        let [command, ...tokens] = input.shift().split('>>>');
        if (command === 'Contains') {
            let substring = tokens[0];
            if (rawKey.includes(substring)) {
                console.log(`${rawKey} contains ${substring}`);
            } else {
                console.log("Substring not found!");
            }
        } else if (command === 'Flip') {

            let startIndex = Number(tokens[1]);
            let endIndex = Number(tokens[2]);
            let result;
            let left = rawKey.slice(0, startIndex);
            let rigth = rawKey.slice(endIndex);
            let changed = rawKey.slice(startIndex, endIndex);

            if (tokens[0] === 'Upper') {
               
                result = changed.toUpperCase();
                rawKey = left + result + rigth;
                console.log(rawKey);
            } else{
                result = changed.toLowerCase();
                rawKey = left + result + rigth;
                console.log(rawKey);
            }
        }else if(command === 'Slice'){
            let startIndex = tokens[0];
            let endIndex = tokens[1];
            let left = rawKey.slice(0, startIndex);
            let rigth = rawKey.slice(endIndex);
            rawKey = left + rigth;
            console.log(rawKey);
        }
    }
    console.log(`Your activation key is: ${rawKey}`);
}
solve(["abcdefghijklmnopqrstuvwxyz",
    "Slice>>>2>>>6",
    "Flip>>>Upper>>>3>>>14",
    "Flip>>>Lower>>>5>>>7",
    "Contains>>>def",
    "Contains>>>deF",
    "Generate"]);
    console.log(23);
    solve(["134softsf5ftuni2020rockz42",
    "Slice>>>3>>>7",
    "Contains>>>-rock",
    "Contains>>>-uni-",
    "Contains>>>-rocks",
    "Flip>>>Upper>>>2>>>8",
    "Flip>>>Lower>>>5>>>11",
    "Generate"])
    

