function fuelMoney(distance, passengers, pricePerL) {
    let increasesFuel = passengers * 0.100;
    let fuel = (distance / 100) * 7 + increasesFuel;
    let money = fuel * pricePerL;
console.log(`Needed money for that trip is ${money.toFixed(2)}lv.`);
}
fuelMoney(260, 9, 2.49)