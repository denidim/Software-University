function santaHoliday(input) {

    let days = Number(input[0]);
    let typeRoom = input[1];
    let feedback = input[2];
    let sum = 0;

    switch (typeRoom) {
        case "room for one person": sum = (days - 1) * 18; break;
        case "apartment": sum = (days - 1) * 25; break;
        case "president apartment": sum = (days - 1) * 35; break;
    }
    if (typeRoom === 'apartment') {

        if (days < 10) {
            sum = (days * 25) * 0.70;

        } else if (days >= 10 && days <= 15) {

            sum = (days * 25) * 0.75;

        } else if (days > 15) {
            sum = (days * 25) * 0.50;
        }
    }

    if (typeRoom === 'president apartment') {

        if (days < 10) {
            sum = (days * 35) * 0.90;

        } else if (days >= 10 && days <= 15) {
            sum = (days * 35) * 0.85;

        } else if (days > 15) {
            sum = (days * 35) * 0.80;
        }
    }
    if (feedback === 'positive') {
        sum = sum * 0.75;

    } else {
        sum = su * 0.90;
    }
    console.log(sum.toFixed(2));
}
santaHoliday(["14",
    "apartment",
    "positive"])


