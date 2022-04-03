function addAndSubstr(input) {

    let arrOfNumbers = input;
    let modifyAdrr = [];
    let oldArrSum = 0;
    let newArrSum = 0;
    let arrLength = arrOfNumbers.length;

    for (let i = 0; i < arrLength; i++) {

        let currentNum = arrOfNumbers[i];
        let newNumber = 0;
        oldArrSum += currentNum;


        if (currentNum % 2 === 0) {
            newNumber = currentNum + i;
        } else {
            newNumber = currentNum - i;
        }
        modifyAdrr.push(newNumber);
        newArrSum += newNumber;
    }

    console.log(modifyAdrr);
    console.log(oldArrSum);
    console.log(newArrSum);


}
addAndSubstr([5, 15, 23, 56, 35]);
