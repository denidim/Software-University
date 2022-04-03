function fishingBoat(input) {
    let budget = Number(input[0]);
    let season = input[1];
    let fisherman = input[2];
    let price = 0;

    if (season === 'Spring') {
        price = 3000;
        if (fisherman <= 6) {
            price = price * 0.90;
        }
        else if (fisherman >= 7 && fisherman <= 11) {
            price = price * 0.85;

        }
        else if (fisherman >= 12) {
            price = price * 0.75;

        }
        if (fisherman % 2 === 0) {
            price = price * 0.95;

        } ,.
    }

    if (season === 'Summer') {
        price = 4200;
        if (fisherman <= 6) {
            price = price * 0.90;
        }
        else if (fisherman >= 7 && fisherman <= 11) {
            price = price * 0.85;

        }
        else if (fisherman >= 12) {
            price = price * 0.75;

        }
        if (fisherman % 2 === 0) {
            price = price * 0.95;

        }
    }

    if (season === 'Autumn') {
        price = 4200;
        if (fisherman <= 6) {
            price = price * 0.90;
        }
        else if (fisherman >= 7 && fisherman <= 11) {
            price = price * 0.85;

        }
        else if (fisherman >= 12) {
            price = price * 0.75;
        }
    }

    if (season === 'Winter') {
        price = 2600;
        if (fisherman <= 6) {
            price = price * 0.90;
        }
        else if (fisherman >= 7 && fisherman <= 11) {
            price = price * 0.85;

        }
        else if (fisherman >= 12) {
            price = price * 0.75;

        }
        if (fisherman % 2 === 0) {
            price = price * 0.95;

        }
    }

    if (budget >= price) {
        console.log(`Yes! You have ${(budget - price).toFixed(2)} leva left.`);

    }else {
        console.log(`Not enough money! You need ${Math.abs(budget - price).toFixed(2)} leva.`);
    }

}

fishingBoat(["3000", "Summer", "11"]);