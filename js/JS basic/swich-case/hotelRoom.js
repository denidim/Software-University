function hotelRoom(input) {
    let mounth = input[0];
    let nights = Number(input[1]);

    let studioPrice = 0;
    let apartmentPrice = 0;

    if (mounth === 'May' || mounth === 'October') {
        studioPrice = nights * 50;
        apartmentPrice = nights * 65;

        if (nights > 7 && nights <= 14) {
            studioPrice = studioPrice * 0.95;
        } else if (nights > 14) {
            studioPrice = studioPrice * 0.70;
            apartmentPrice = apartmentPrice * 0.90;
        }
    } 
    else if (mounth === 'June' || mounth === 'September') {
        studioPrice = nights * 75.20;
        apartmentPrice = nights * 68.70;
        if (nights > 14) {
            studioPrice = studioPrice * 0.80;
            apartmentPrice = apartmentPrice * 0.90;
        }
    } 
    else if(mounth === 'July' || mounth === 'August'){
        studioPrice = nights * 76;
        apartmentPrice = nights * 77;
        if (nights > 14) {
            apartmentPrice = apartmentPrice * 0.90;
        }
    }
    console.log(`Apartment: ${apartmentPrice.toFixed(2)} lv.`);
    console.log(`Studio: ${studioPrice.toFixed(2)} lv.`);

}
hotelRoom(["June",
"14"])
