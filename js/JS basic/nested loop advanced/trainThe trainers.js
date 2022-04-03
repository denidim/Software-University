function trainTrainers(input) {

    let index = 0;
    let gurry = Number(input[index]);
    index++;

    let command = input[index];
    index++;

    let sumOfgrade = 0;
    let counter = 0;


    while (command !== 'Finish') {

        let name = command;
        let temSumOfGrade = 0;

        for (let i = 0; i < gurry; i++) {
            counter++;
            let grade = Number(input[index]);
            index++;

            temSumOfGrade += grade;
            sumOfgrade += grade;
        }
        let averTempGrade = temSumOfGrade / gurry;

        console.log(`${name} - ${averTempGrade.toFixed(2)}.`);


        command = input[index];
        index++;
    }
    let avgGrade = sumOfgrade / counter;
    console.log(`Student's final assessment is ${avgGrade.toFixed(2)}.`);

}
trainTrainers(["2",
    "Objects and Classes",
    "5.77",
    "4.23",
    "Dictionaries",
    "4.62",
    "5.02",
    "RegEx",
    "2.88",
    "3.42",
    "Finish"])
