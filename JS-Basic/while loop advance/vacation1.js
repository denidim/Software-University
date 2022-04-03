function vacation(input) {

    let index = 0;
    let needMoney = Number(input[index]);
    index++;
    let money = Number(input[index]);
    index++;

    let couter = 0;
    let dayCounter = 0;

    while (money < needMoney) {
        dayCounter++;
        let action = input[index];
        index++;
        let sumSpendOrSave = Number(input[index]);
        index++;

        if (action == "spend") {
            money -= sumSpendOrSave;
            if(money<0){
                money=0;
            }
            couter++;
        }
        else {
            money += sumSpendOrSave;
            couter=0;
        }
        if (couter == 5) {
            console.log("You can't save the money.");
            console.log(dayCounter);
            break;
        }
    }
    if (money>=needMoney) {
        console.log(`You saved the money for ${dayCounter} days.`);

    }
}

    vacation(["2000",
    "1000",
    "spend",
    "1200",
    "save",
    "2000"])
    