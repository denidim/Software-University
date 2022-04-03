function solve(input) {
    let plantCount = Number(input.shift());
    let plantCollection = {};
 
    for (let i = 0; i < plantCount; i++) {
        let line = input.shift();
        let [plant, rarity] = line.split('<->');
        rarity = Number(rarity);
        plantCollection[plant] = { rarity, rating: [] };
    }
 
    let line = input.shift();
    while (line !== 'Exhibition') {
        let [command, ...rest] = line.split(': ');
        let [plant, data] = rest[0].split(' - ');
        if (plantCollection.hasOwnProperty(plant)) {
            switch (command) {
                case 'Rate': {
                    let rating = Number(data);
                    plantCollection[plant].rating.push(rating);
                    break;
                }
                case 'Update': {
                    let newRarity = Number(data);
                    plantCollection[plant].rarity = newRarity;
                    break;
                }
                case 'Reset': {
                    plantCollection[plant].rating = [];
                    break;
                }
                default:
                    console.log('error');
                    break;
            }
        } else {
            console.log('error');
        }
        line = input.shift();
    }
 
    let sortedPlants = Object.keys(plantCollection).sort(
        (a, b) =>
            plantCollection[b].rarity - plantCollection[a].rarity ||
            average(plantCollection[b].rating) - average(plantCollection[a].rating)
    );
 
    console.log(`Plants for the exhibition:`);
 
    for (let plant of sortedPlants) {
        console.log(`- ${plant}; Rarity: ${plantCollection[plant].rarity}; Rating: ${average(plantCollection[plant].rating).toFixed(2)}`);
    }
 
    function average(arr) {
        if (!arr.length) return 0;
        return arr.reduce((a, b) => a + b, 0) / arr.length;
    }
}
solve(["3",
    "Arnoldii<->4",
    "Woodii<->7",
    "Welwitschia<->2",
    "Rate: Woodii - 10",
    "Rate: Welwitschia - 7",
    "Rate: Arnoldii - 3",
    "Rate: Woodii - 5",
    "Update: Woodii - 5",
    "Reset: Arnoldii",
    "Exhibition"]);
console.log('===');
solve(["2",
    "Candelabra<->10",
    "Oahu<->10",
    "Rate: Oahu - 7",
    "Rate: Candelabra - 6",
    "Exhibition"]);

