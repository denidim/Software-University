function movieBudget(input) {

    let budget = Number(input[0]);
    let walkons = Number(input[1]);
    let clotesPrice = Number(input[2]);

    let decorPrice = budget * 0.10;
    let totalClotesPrice = walkons * clotesPrice;

    if (walkons > 150) {
        totalClotesPrice = totalClotesPrice - totalClotesPrice * 0.10;
    }

    let totalCosts = totalClotesPrice + decorPrice;
    let moneyLeft = Math.abs(budget - totalCosts);

    if (totalCosts > budget) {
        console.log('Not enough money!');
        console.log(`Wingard needs ${moneyLeft.toFixed(2)} leva more.`)
    } else {
        console.log('Action!');
        console.log(`Wingard starts filming with ${moneyLeft.toFixed(2)} leva left.`)
    }

}
movieBudget(["9587.88", "222", "55.68"]);

