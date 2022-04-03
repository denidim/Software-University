function theatrePromotion(day, age) {
    let ticketPrice = 0;
    if (day === 'Weekday') {
        if (age >= 0 && age <= 18 || age > 64 && age <= 122) {
            ticketPrice += 12;
        } else if (age > 18 && age <= 64) {
            ticketPrice += 18;
        }
    } else if (day === 'Weekend') {
        if (age >= 0 && age <= 18 || age > 64 && age <= 122) {
            ticketPrice += 15;
        } else if (age > 18 && age <= 64) {
            ticketPrice += 20;
        }
    } else if (day === 'Holiday') {
        if (age >= 0 && age <= 18) {
            ticketPrice += 5;
        } else if (age > 18 && age <= 64) {
            ticketPrice += 12;
        } else if (age > 64 && age <= 122) {
            ticketPrice += 10;
        } 
    }
    if (age < 0 || age > 122) {
        console.log('Error!');
    } else{
    console.log(ticketPrice + '$');
    }

}
theatrePromotion('Weekday', 0);
theatrePromotion('Holiday', -12);