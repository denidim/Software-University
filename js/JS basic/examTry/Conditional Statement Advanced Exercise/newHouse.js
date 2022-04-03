function newHouse(input) {

    let flowerType = input[0];
    let quantity = Number(input[1]);
    let budget = Number(input[2]);
    let price = 0;

    if (flowerType === 'Roses') {
        price = quantity * 5;

        if (quantity > 80) {
            price = price * 0.90;
        }

    } else if (flowerType === 'Dahlias') {
        price = quantity * 3.80;

        if (quantity > 90) {
            price = price * 0.85;
        }
    } else if (flowerType === 'Tulips') {
        price = quantity * 2.80;

        if (quantity > 80) {
            price = price * 0.85;
        }
    } else if (flowerType === 'Narcissus') {
        price = quantity * 3;

        if (quantity < 120) {
            price = price + (price * 0.15);
        }
    } else if (flowerType === 'Gladiolus') {
        price = quantity * 2.50;

        if (quantity < 80) {
            price = price * 0.20 + price;
        }
    }
    if (budget >= price) {
        console.log(`Hey, you have a great garden with ${quantity} ${flowerType} and ${(budget - price).toFixed(2)} leva left.`);

    } else {

        console.log(`Not enough money, you need ${Math.abs(budget - price).toFixed(2)} leva more.`);
    }
}
newHouse(['Gladiolus', '64', '160']);
    