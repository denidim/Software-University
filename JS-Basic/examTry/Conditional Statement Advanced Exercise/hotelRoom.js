function hotelRoom(input) {


    let month = input[0];
    let night = Number(input[1]);

    let priceStudio = 0;
    let priceApartment = 0;

    if (month === 'May' || month === 'October') {

        priceStudio = night * 50;
        priceApartment = night * 65;

        if (night > 7 && night <14) {
            priceStudio = priceStudio * 0.95;

        } else if (night > 14) {
            priceStudio = priceStudio * 0.70;
            priceApartment = priceApartment * 0.90;
        }

    }
    else if (month === 'June' || month === 'September') {

        priceStudio = night * 75.20;
        priceApartment = night * 68.70;

        if (night > 14) {

            priceStudio = priceStudio * 0.80;
            priceApartment = priceApartment * 0.90;
        }

    }
    else if (month === 'July' || month === 'August') {

        priceStudio = night * 76;
        priceApartment = night * 77;

        if (night > 14) {
            priceApartment = priceApartment * 0.90;
        }

    }

    console.log(`Apartment: ${priceApartment.toFixed(2)} lv.`);
    console.log(`Studio: ${priceStudio.toFixed(2)} lv.`);

}
hotelRoom(["May",
"15"])




