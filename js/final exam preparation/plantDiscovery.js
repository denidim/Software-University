function solve(input) {

    let n = Number(input.shift());
    let flowers = {};

    for (let i = 0; i < n; i++) {
        let tokens = input.shift().split('<->');
        let name = tokens[0];
        let rarity = Number(tokens[1])

        flowers[name] = {
            rarity,
            rating: []
        };
    }

    while (input[0] !== 'Exhibition') {

        let line = input.shift();
        let [command, ...arg] = line.split(': ');
        let [name, data] = arg[0].split(' - ');

       if(flowers.hasOwnProperty(name)){

        if (command === 'Rate') {
            let rating = Number(data);
            flowers[name].rating.push(rating);

        }else if(command === 'Update'){
            let newRarity = Number(data);
            flowers[name].rarity = newRarity;
console.log(flowers[name].rarity);
        }else if(command === 'Reset'){
            flowers[name].rating = [];

        }else{
            console.log('error');
        }
       }else{
           console.log('error');
       } 
    }
    console.log("Plants for the exhibition:");

    for(let flower of Object.entries(flowers)){
      
        console.log(` - ${flower}; Rarity: ${flowers[flower].rarity}; Rating: ${flowers[flower].rating.toFixed(2)}`);
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

