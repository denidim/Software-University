function printCertificate(grade, names) {
    if(pass(grade)){
        printHeader();
        printName(names);
        printGrades(grade);
    }else{
        console.log(`${names[0]} ${names[1]} does not qualify`);
    }

    function printHeader() {
        console.log('~~~-   {@}   -~~~');
        console.log('~_ Certificate _~');
        console.log('~~~-  ~---~  -~~~');
    }
    function printName(nameArr) {
        console.log(nameArr[0] + ' ' + nameArr[1]);
    }

    function pass(grade) {
        return grade >= 3;
    }

    function printGrades(grade) {

        if (grade < 3) {
            console.log('Fail (2)');
        } else if (grade < 3.50) {
            console.log(`Poor (${grade.toFixed(2)})`);
        } else if (grade < 4.50) {
            console.log(`Good (${grade.toFixed(2)})`);
        } else if (grade < 5.50) {
            console.log(`Very good (${grade.toFixed(2)})`);
        } else if (grade <= 6) {
            
            console.log(`Exellent (${grade.toFixed(2)})`);
        }
    }
}
printCertificate(5.50, ['John', 'Smith']);
printCertificate(3.30, ['Peter', 'Carter']);
printCertificate(2, ['George', 'Markus']);