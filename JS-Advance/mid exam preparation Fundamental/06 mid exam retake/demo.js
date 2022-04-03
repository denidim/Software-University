function treasure(arr) {
    let theTreasure = arr.shift().split('|');
    // let command = arr.shift();
    let line = arr.shift();

    while (true) {

        // let tokens = command.split('')
        let [command, ...items] = line.split(' ');

        if (command === 'Yohoho!') {
            break;
        }

        if (command == 'Loot') {
            for (let j = 1; j < items.length; j++) {
                if (!theTreasure.includes(items[j])) { // j !!!
                    theTreasure.push(items[j]);
                }
            }
        } else if (command == ' Drop') {
            let index = Number(items[0]);
            if (index >= 0 && index < theTreasure.length) {
                // let theLoot = theTreasure.pop(index);
                // Removes the last element from an array and returns it
                let theLoot = theTreasure.splice(index, 1);
                theTreasure.push(theLoot)
            }
        } else if (command == 'Steal') {
            let steal = [];
            let count = Number(items[0]);

            //someone steals the last count loot items. 
            //If there are less items than the given count remove as much as there are.

            // if (count < theTreasure.length) {
            //     for (let i = theTreasure.length - count; i < theTreasure.length; i++) {
            //         steal.push(theTreasure[i])
            //     }
            //     console.log(steal.join(', '));
            // }
        }

        line = arr.shift();
    }

    if (theTreasure.length == 0) {
        console.log('Failed treasure hunt.');
    } else {
        let average = theTreasure.length
        console.log(`Average treasure gain: ${average.toFixed(2)} pirate credits.`);
    }
}

treasure(["Gold|Silver|Bronze|Medallion|Cup",
"Loot Wood Gold Coins",
"Loot Silver Pistol",
"Drop 3",
"Steal 3",
"Yohoho!"]);