function fruitMarket(input) {

    let strawberriesPricePerKg = parseFloat(input[0]);
    let bananasKg = parseFloat(input[1]);
    let orangesKg = parseFloat(input[2]);
    let rasberriesKg = parseFloat(input[3]);
    let strawberriesKg = parseFloat(input[4]);

    let rasberriesPricePerKg = strawberriesPricePerKg * 0.50;
    let orangesPricePerKg = rasberriesPricePerKg * 0.60;
    let bananasPricePerKg = rasberriesPricePerKg * 0.20;

    let totalStrawSum = strawberriesPricePerKg * strawberriesKg;
    let totalOrangesSum = orangesKg * orangesPricePerKg;
    let totalBanansSum = bananasPricePerKg * bananasKg;
    let totalRasberSum = rasberriesKg * rasberriesPricePerKg;

    let totalPrice = totalBanansSum + totalOrangesSum + totalRasberSum + totalStrawSum;

    console.log(totalPrice);


}
fruitMarket(['48', '10', '3.3', '6.5', '1.7'])