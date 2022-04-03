function cleverLily(input) {

    let age = Number(input[0]);
    let washerPrice = Number(input[1]);
    let toyPrice = Number(input[2]);

    let toyCouner = 0;
    let savedMoney = 0;
    let stolenMoney = 0;
    let income = 0;

    for (let currentBDay = 1; currentBDay <= age; currentBDay++) {
        if (currentBDay % 2 !== 0) {
            toyCouner++;
        } else {
            stolenMoney++;
            savedMoney += 10;
            income += savedMoney;
        }
    }
    let moneyFromToys = toyCouner * toyPrice;
    let finalIncom = (income + moneyFromToys) - stolenMoney;

    if (finalIncom >= washerPrice) {
        console.log(`Yes! ${(finalIncom - washerPrice).toFixed(2)}`);

    } else {
        console.log(`No! ${(washerPrice - finalIncom).toFixed(2)}`);
    }

}
cleverLily(["10", "170", "6"])
