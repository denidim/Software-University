function treasureHunt(input) {
    let treasureChest = input.shift().split('|');

    for (let line of input) {
        let [command, ...items] = line.split(' ');

        if (command === 'Yohoho!') {
            break;

        } else if (command === 'Loot') {
            for (let i = 0; i < items.length; i++) {

                if (!treasureChest.includes(items[i])) {
                    treasureChest.unshift(items[i]);

                } else {
                    continue;
                }
            }
        } else if (command === 'Drop') {

            let index = Number(items[0]);
            if (index >= 0 && index < treasureChest.length) {
                let dropped = treasureChest.splice(index, 1);
                treasureChest.push(dropped.toString());

            } else if (index < 0 || index >= treasureChest.length) {
                continue;
            }
        } else if (command === 'Steal') {
            let stealed = [];
            let count = Number(items[0]);

            if (count < treasureChest.length) {
               
                for (let i = treasureChest.length - count; i < treasureChest.length; i++) {
                    stealed.push(treasureChest[i]);
                }
                let index = treasureChest.length - count;
                treasureChest.splice(index, 3);
                console.log(stealed.join(', '));

            } else if (count >= treasureChest.length) {

                stealed = treasureChest;
                console.log(stealed.join(', '));
                treasureChest.splice(0, );
            }
        }
    }
    let sum = 0;

    if (treasureChest.length == 0) {
        console.log("Failed treasure hunt.");

    } else {
        for (let element of treasureChest) {
            sum += element.length;
        }
        let averageGain = sum / treasureChest.length;
        console.log(`Average treasure gain: ${averageGain.toFixed(2)} pirate credits.`);
    }
}


treasureHunt(["Gold|Silver|Bronze|Medallion|Cup",
    "Loot Wood Gold Coins",
    "Loot Silver Pistol",
    "Drop 3",
    "Steal 3",
    "Yohoho!"]);

treasureHunt(["Diamonds|Silver|Shotgun|Gold",
    "Loot Silver Medals Coal",
    "Drop -1",
    "Drop 1",
    "Steal 6",
    "Yohoho!"]);

