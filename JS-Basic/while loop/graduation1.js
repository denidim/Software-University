function graduation(input) {

    let name = input[0];

    let index = 0;
    let counterClass = 1;
    let excl = 0;

    let totalGrage = 0;

    while (counterClass <= 12) {
        index++;
        let grade = Number(input[index]);
        if (grade >= 4.00) {
            totalGrage += grade;
            counterClass++;
        }
        else {
            excl++;
            break;
        }

    }

    let avrGrade = totalGrage / 12;
    if (excl >= 1) {
        console.log(`${name} has been excluded at ${counterClass} grade`);

    } else {
        console.log(`${name} graduated. Average grade: ${avrGrade.toFixed(2)}`);
    }

}

graduation(["Mimi", 
"5",
"6",
"5",
"6",
"5",
"6",
"6",
"2",
"3"])



