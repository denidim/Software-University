function cleverLili(input) {
    let age = Number(input[0]);
    let washerPrice = Number(input[1]);
    let toyPrice = Number(input[2]);

    let toyCounter = 0;
    let money = 10;
    let savedMoney = 0;

    for (let i = 1; i <= age; i++) {

        if (i % 2 !== 0) {
            toyCounter++;
        } else {
            savedMoney += money;
            money += 10;
            savedMoney -= 1;
        }
    }
    savedMoney += toyCounter * toyPrice;
    let diff = Math.abs(savedMoney - washerPrice);

    if (savedMoney >= washerPrice) {

        console.log(`Yes! ${diff.toFixed(2)}`);
    } else {

        console.log(`No! ${diff.toFixed(2)}`);
    }
}
cleverLili(["21",
"1570.98",
"3"])

