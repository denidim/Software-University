function solve(start, end){
    let sum = 0;
    let result = [];
    for (let i = start; i <= end; i++) {
        result.push(i);
        sum += i;
    }
    console.log(...result)
    console.log(`Sum: ${sum}`);
}

solve(5 ,10)