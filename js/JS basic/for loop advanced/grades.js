function grades(input) {
    
    let students = Number(input[0]);
    let grade = Number(input[1]);
    let index = 2;
    let totalGrade= 0;
    let topStudents = 0;
    let goodStudents = 0;
    let avgStudents = 0;
    let failed = 0;
    let avgGrade = 0;

    for(let i = 1; i <= students; i ++){

        if (grade >= 5 && grade <= 6){
            totalGrade += grade;
            topStudents ++;

        }
        else if(grade >= 4 && grade <= 4.99){
            totalGrade += grade;
            goodStudents ++;

        }
        else if(grade >= 3 && grade <= 3.99){
            totalGrade+= grade;
            avgStudents ++;
        }
        else if(grade < 3){
            totalGrade += grade;
            failed ++;
        }
        grade = Number(input[index]);
        index++;
    }
    avgGrade = totalGrade / students;
    let procentTop = topStudents / students * 100;
    let procentGood = goodStudents / students * 100;
    let procentAvg = avgStudents / students * 100;
    let procentFailed = failed / students * 100;

    console.log(`Top students: ${procentTop.toFixed(2)}%`);
    console.log(`Between 4.00 and 4.99: ${procentGood.toFixed(2)}%`);
    console.log(`Between 3.00 and 3.99: ${procentAvg.toFixed(2)}%`);
    console.log(`Fail: ${procentFailed.toFixed(2)}%`);
    console.log(`Average: ${avgGrade.toFixed(2)}`);
}
grades(['10','3.00', '2.99', '5.68', '3.01', 
'4', '4', '6.00', '4.50', '2.44', '5' ])