function solve(array){
    let sortedAsc = [...array].sort((a,b) => a-b);
    let result = [];
    let step = 0;
    while (sortedAsc.length > 0){
        if(step % 2 === 0){
            result.push(sortedAsc.shift());
        }
        else{
            result.push(sortedAsc.pop());
        }
        step++;
    }
    return(result);
}

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);