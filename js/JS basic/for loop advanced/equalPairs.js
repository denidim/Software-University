function equalPairs(input) {
    
    let pairs = Number(input[0]);
    let n1 = Number(input[1]);
    let n2 = Number(input[2]);
    let index = 3;

    let maxDifference = 0;
    let previousSum = n1 + n2;

    for(let i = 1; i < pairs; i++){
         n1 = Number(input[index]);
        index++;
        n2 = Number(input[index]);
        index++;
        let currentSum = n1 + n2;
        let currentDifference = Math.abs(currentSum - previousSum);

        if(currentDifference > maxDifference){
            maxDifference = currentDifference;
        }
        previousSum = currentSum;
    }
    console.log(maxDifference ? `No, maxdiff=${maxDifference}` : `Yes, value=${previousSum}`);
}
equalPairs(['3', '1', '2', '0', '3', '4', '-1'])
