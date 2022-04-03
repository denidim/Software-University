function toyShop(input) {

    let trip = Number(input[0]);
    let puzzles = Number(input[1]);
    let dolls = Number(input[2]);
    let bears = Number(input[3]);
    let minions = Number(input[4]);
    let trucks = Number (input[5]);

    let sum = puzzles * 2.6 + dolls * 3 + bears * 4.1 + minions * 8.2 + trucks * 2;
    let toys = puzzles + dolls + bears + minions + trucks;

    if (toys >= 50) {
        sum = sum * 0.75;
    } 

    sum = sum * 0.90;

    if(sum >= trip){
        let moneyLeft = sum - trip;
        console.log(`Yes! ${moneyLeft.toFixed(2)} lv left.`);

    }else{
        let moneyNeeded = trip - sum;
        console.log(`Not enough money! ${Math.abs(moneyNeeded.toFixed(2))} lv needed.`)

    }
}
toyShop(["320", "8", "2", "5", "5", "1"]);
