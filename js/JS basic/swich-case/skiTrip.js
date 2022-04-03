function santaHoliday(input) {

    let days = Number(input[0]);
    let type = input[1];
    let feedback = input[2];
    let result = 0;

    switch (type) {
        case 'room for one person':
            result = (days - 1) * 18.00;
            break;
        case 'apartment':
            result = (days - 1) * 25.00;
            if (days < 10) {
                result = result * 0.70;

            } else if (days >= 10 && days <= 15) {
                result = result * 0.65;
            }
            else {
                result = result * 0.50;
            }
            break;
        case 'president apartment':
            result = (days - 1) * 35.00;
            if(days < 10){
                result = result * 0.90;
            } else if (days >= 10 && days <= 15) {
                result = result * 0.85;
            } else {
                result = result * 0.80;
            }
            break       

    }
    if(feedback === 'positive'){
        result = result * 1.25;
        console.log(result.toFixed(2));
    }else{
        result = result * 0.90;
        console.log(result.toFixed(2));
    }

}
santaHoliday
(["12",
"room for one person",
"positive"])


