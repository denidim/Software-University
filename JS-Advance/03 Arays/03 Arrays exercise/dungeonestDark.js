function dungeonesrdark(arr) {
    let rooms = arr.toString().split('|');
    let initialHealth = 100;
    let initialCoins = 0;
    let counerRoom = 1;
    

    for (let i = 0; i < rooms.length; i++) {
        let tokens = rooms[i].split(' ');
        let command = tokens[0];
        let number = Number(tokens[1]);

        if (command === 'potion') {
            let sum = 0;
            if ( number > 100 - initialHealth) {
                sum = 100 - initialHealth;
                initialHealth += sum;
            } else{
                sum = number;
                initialHealth += number;
            }

            console.log(`You healed for ${sum} hp.`);
            console.log(`Current health: ${initialHealth} hp.`);

        } else if (command === 'chest') {
            initialCoins += number;
            console.log(`You found ${number} coins.`);

        } else {
            initialHealth -= number;
            if(initialHealth > 0){
            console.log(`You slayed ${command}.`);
            } else{
                console.log(`You died! Killed by ${command}.`);
                console.log(`Best room: ${counerRoom}`);
                break;
            }
        }
       counerRoom ++;
    }
    if(initialHealth > 0){
        console.log("You've made it!");
        console.log(`Coins: ${initialCoins}`);
        console.log(`Health: ${initialHealth}`);
    }
}





dungeonesrdark(["rat 10|bat 20|potion 10|rat 10|chest 100|boss 70|chest 1000"]);
dungeonesrdark(["cat 10|potion 30|orc 10|chest 10|snake 25|chest 110"]);