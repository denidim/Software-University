function manOWar(input) {

    let pirate = input.shift().split('>').map(Number);
    let warship = input.shift().split('>').map(Number);
    let maxHealth = Number(input.shift());
    let needRepair = maxHealth * 0.20;
    let isDead = false;
    let isEnemyDead = false;

    for (let line of input) {
        let [command, ...num] = line.split(' ');

        if (command === 'Retire') {
            let statusWarship = 0;
            let statusPirate = 0;
            for (let el of warship) {
                statusWarship += el;
            }
            for (let el of pirate) {
                statusPirate += el;
            }
            if(!isDead && !isEnemyDead){
            console.log(`Pirate ship status: ${statusPirate}\nWarship status: ${statusWarship}`);
            break;
        }
        } else if (command === 'Fire') {
            let index = Number(num[0]);
            let damage = Number(num[1]);
            if (index >= 0 && index < warship.length) {
                warship[index] -= damage;

                if (warship[index] == 0) {
                    health = 0;
                    isEnemyDead = true;
                    console.log("You won! The enemy ship has sunken.");
                    break;
                }
            }
        } else if (command === 'Defend') {

            let startIndex = Number(num[0]);
            let endIndex = Number(num[1]);
            let damage = Number(num[2]);

            if (startIndex >= 0 && startIndex < pirate.length
                && endIndex > startIndex && endIndex < pirate.length) {

                for (let i = startIndex; i <= endIndex; i++) {
                    pirate[i] -= damage;
                    if (pirate[i] <= 0) {
                        health = 0;
                        isDead = true;
                    }
                }
                if(isDead){
                    console.log("You lost! The pirate ship has sunken.");
                    break;
                }
            }
        } else if (command === 'Repair') {
            let index = Number(num[0]);
            let health = Number(num[1]);
            if (index >= 0 && index < pirate.length) {

                pirate[index] += health;
                if (pirate[index] > maxHealth) {
                    pirate[index] = maxHealth;
                }
            }
        } else if (command === 'Status') {
            let count = 0;
            for (let i = 0; i < pirate.length; i++) {

                if (pirate[i] < needRepair) {
                    count++;
                }
            }
            console.log(`${count} sections need repair.`);
        }
    }
}
manOWar(["12>13>11>20>66",
    "12>22>33>44>55>32>18",
    "70",
    "Fire 2 11",
    "Fire 8 100",
    "Defend 3 6 11",
    "Defend 0 3 5",
    "Repair 1 33",
    "Status",
    "Retire"]);

manOWar(["2>3>4>5>2",
    "6>7>8>9>10>11",
    "20",
    "Status",
    "Fire 2 3",
    "Defend 0 4 11",
    "Repair 3 18",
    "Retire"]);

