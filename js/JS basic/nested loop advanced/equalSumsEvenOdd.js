function equalSums(input) {

    let startNum = Number(input[0]);
    let endNum = Number(input[1]);

    let result = ""; 

    for (let i = startNum; i <= endNum; i++) {

        let evenSum = 0;
        let oddSum = 0;
        let numToString = i + "";

        for (let index = 0; index < numToString.length; index++) {
            if (index % 2 === 0) {
                evenSum += Number(numToString[index]);

            } else {
                oddSum += Number(numToString[index]);
            }

        }
        if(evenSum === oddSum){
            result += numToString + " ";
            
        }
    }
    console.log(result);
}

equalSums(["100000", "100050"]);
