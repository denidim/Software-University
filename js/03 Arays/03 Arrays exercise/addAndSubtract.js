function addAndSubstract(array) {
    let oldSum = 0;
    let newSum = 0;

    for (let i = 0; i < array.length; i++) {
        let currentNum = array[i];
        let newNumber = 0;

        if (currentNum % 2 === 0) {
            newNumber = currentNum + i;
            array[i] = newNumber;
        } else {
            newNumber = currentNum - i;
            array[i] = newNumber;
        }
        oldSum += currentNum;
        newSum += newNumber;
    }
    console.log(array);
    console.log(oldSum);
    console.log(newSum);
}
addAndSubstract([5, 15, 23, 56, 35]);
addAndSubstract([-5, 11, 3, 0, 2]);