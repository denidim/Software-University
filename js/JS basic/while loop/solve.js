function solve(input) {

    let name = input[0];
    let grade = Number(input[1]);
    let index = 2;
    let grades = 1;
    let sum = 0;
    let excluded = 0;
    let avgGrade = 0;

    while (grades <= 12) {

        if (grade >= 4.00) {
            sum += grade;
            grades++;

        } else {
            excluded++;

            break;
        }
        grade = Number(input[index]);
        index++;
    }
    if (excluded >= 1) {
        console.log(`${name} has been excluded at ${grades} grade`);
    }
    else {
        avgGrade = sum / 12;
        console.log(`${name} graduated. Average grade: ${avgGrade.toFixed(2)}`);
    }
}
solve(["Mimi",
    "5",
    "6",
    "5",
    "6",
    "5",
    "6",
    "6",
    "2",
    "3"])

