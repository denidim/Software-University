function onTimeForExam(input) {

    let examHour = Number(input[0]);
    let examMinutes = Number(input[1]);
    let arrivelHour = Number(input[2]);
    let arriveMinutes = Number(input[3]);

    let totalExamMin = examHour * 60 + examMinutes;
    let totalArrivelMin = arrivelHour * 60 + arriveMinutes;

    if (totalArrivelMin > totalExamMin) {

        console.log('Late');

    } else if (totalExamMin - totalArrivelMin <= 30) {

        console.log('On time');
    } else {
        console.log('Early');
    }

    let result = Math.abs(totalExamMin - totalArrivelMin)

    if (totalExamMin - totalArrivelMin > 0) {

        if (result < 60) {
            console.log(`${result} minutes before the start`);

        } else {
            if (result % 60 < 10) {
                console.log(`${parseInt(result / 60)}:0${result % 60} hours before the start`);
            } else {
                console.log(`${parseInt(result / 60)}:${result % 60} hours before the start`);
            }
        }
    }
    else if (totalArrivelMin - totalExamMin > 0) {
        if (result < 60) {
            console.log(`${result} minutes after the start`);
        } else {
            if (result % 60 < 10) {
                console.log(`${parseInt(result / 60)}:0${result % 60} hours after the start`);
            } else {
                console.log(`${parseInt(result / 60)}:${result % 60} hours after the start`);
            }
        }
    }
}
onTimeForExam(["16",
    "00",
    "15",
    "00"])


