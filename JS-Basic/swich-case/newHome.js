function newHome(input) {

    let flowerType = input[0];
    let quantity = Number(input[1]);
    let budget = Number(input[2]);
    let sum = 0;
    let total = 0;


    if (flowerType === 'Roses') {
        sum = quantity * 5;
        if (quantity > 80) {
            sum = sum * 0.90;
        }
    } else if (flowerType === 'Dahlias') {
        sum = quantity * 3.80;
        if (quantity > 90) {
            sum = sum * 0.85;
        }
    } else if (flowerType === 'Tulips') {
        sum = quantity * 2.80;
        if (quantity > 80) {
            sum = sum * 0.85;
        }
    } else if (flowerType === 'Narcissus') {
        sum = quantity * 3;
        if (quantity < 120) {
            sum += sum * 0.15;
        }
    } else if (flowerType === 'Gladiolus') {
        sum = quantity * 2.50;
        if (quantity < 80) {
            sum += sum * 0.20;
        }
    }


    if (budget >= sum) {
        total = budget - sum;
        console.log(`Hey, you have a great garden with ${quantity} ${flowerType} and ${total.toFixed(2)} leva left.`);

    } else {
        total = sum - budget;
        console.log(`Not enough money, you need ${total.toFixed(2)} leva more.`);
    }
}


newHome(["Gladiolus",
    "64",
    "160"])

