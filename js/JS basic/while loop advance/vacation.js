function vacation(input) {

    let vacationMoney = Number(input[0]);
    let money = Number(input[1]);
    let spendOrSave = input[2];
    let index = 3;
    let days = 0;
    let counterSpend = 0;

    while (money < vacationMoney) {
        days++;

        if (spendOrSave === 'spend') {
            counterSpend++;
            money -= Number(input[index]);
            index++;
            if (money < 0) {
                money = 0;
            }
        }
        if (spendOrSave === 'save') {
            counterSpend = 0;
            money += Number(input[index]);
            index++;
        }
        if (counterSpend === 5) {
            console.log("You can't save the money.");
            console.log(days);
            break;
        }
        spendOrSave = input[index];
        index++;
    }
    if (money >= vacationMoney) {
        console.log(`You saved the money for ${days} days.`);
    }

}
vacation(["110",
    "60",
    "spend",
    "10",
    "spend",
    "10",
    "spend",
    "10",
    "spend",
    "10",
    "spend",
    "10"])





