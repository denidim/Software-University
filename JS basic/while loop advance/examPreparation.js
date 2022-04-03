function examPreparation(input) {

    let index = 0;
    let poorGrade = Number(input[index]);
    index++;
    let command = input[index];
    index++;

    let sumGrades = 0;
    let counter = 0;
    let lastProblem = "";
    let countPoorGrade = 0;
    let isNeedBreak = false;


    while (command !== "Enough") {
        let currentProblem = command;
        let currentGrade = Number(input[index]);
        index++;

        if (currentGrade <= 4) {
            countPoorGrade++;
        }
        if (countPoorGrade === poorGrade) {
            isNeedBreak = true;
            console.log(`You need a break, ${countPoorGrade} poor grades.`);
            break;
        }
        sumGrades += currentGrade;
        counter++;
        lastProblem = currentProblem;

        command = input[index];
        index++;

    }
    if (!isNeedBreak) {
        let avgGrade = sumGrades / counter;
        console.log(`Average score: ${avgGrade.toFixed(2)}`);
        console.log(`Number of problems: ${counter}`);
        console.log(`Last problem: ${lastProblem}`);
    }
}
examPreparation(["2",
    "Income",
    "3",
    "Game Info",
    "6",
    "Best Player",
    "4"]);
