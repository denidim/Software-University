function fishinBoat(input) {

    let budget = Number(input[0]);
    let season = input[1];
    let fisherman = Number(input[2]);
    let boatPrice = 0;

    if (season === 'Spring') {
        boatPrice = 3000;

        if (fisherman <= 6) {
            boatPrice = boatPrice * 0.90;
        } else if (fisherman > 7 && fisherman <= 11) {
            boatPrice = boatPrice * 0.85;
        } else if (fisherman >= 12) {
            boatPrice = boatPrice * 0.75;
        }     
    } 
    else if (season === 'Summer' || season === 'Autumn') {
        boatPrice = 4200;

        if (fisherman <= 6) {
            boatPrice = boatPrice * 0.90;
        } else if (fisherman > 7 && fisherman <= 11) {
            boatPrice = boatPrice * 0.85;
        } else if (fisherman >= 12) {
            boatPrice = boatPrice * 0.75;
        }
    }
    else if (season === 'Winter') {
        boatPrice = 2600;

        if (fisherman <= 6) {
            boatPrice = boatPrice * 0.90;
        } else if (fisherman > 7 && fisherman <= 11) {
            boatPrice = boatPrice * 0.85;
        } else if (fisherman >= 12) {
            boatPrice = boatPrice * 0.75;
        }
    }

    if (fisherman % 2 === 0 && season !== 'Autumn') {
        boatPrice = boatPrice * 0.95;
    }
    if (budget >= boatPrice) {
        console.log(`Yes! You have ${(budget - boatPrice).toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money! You need ${(boatPrice - budget).toFixed(2)} leva.`);
    }

}
fishinBoat(["2000",
"Winter",
"13"])


