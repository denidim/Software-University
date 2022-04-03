function coins(input) {

    let moneyInLv = Number(input[0]);
    let money = parseInt(moneyInLv * 100);
    let countCoins = 0;

    while (money > 0) {
        if (money >= 200) {
            money -= 200;
            countCoins++;

        } else if (money >= 100) {
            money -= 100;
            countCoins++;

        } else if (money >= 50) {
            money -= 50;
            countCoins++;

        } else if (money >= 20) {
            money -= 20;
            countCoins++;

        } else if (money >= 10) {
            money -= 10;
            countCoins++;

        } else if (money >= 5) {
            money -= 5;
            countCoins++;

        } else if (money >= 2) {
            money -= 2;
            countCoins++;

        } else if (money >= 1) {
            money -= 1;
            countCoins++
        }
    }
    console.log(countCoins);
}
coins(["0.56"]);