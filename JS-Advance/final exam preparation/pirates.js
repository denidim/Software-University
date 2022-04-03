function pirates(input) {
    let line = input.shift();
    let target = {};


    while (line !== 'Sail') {

        let [city, population, gold] = line.split('||');

        if (!target.hasOwnProperty(city)) {
            target[city] = [Number(population), Number(gold)];
        } else {
            target[city][0] += Number(population);
            target[city][1] += Number(gold);
        }
        line = input.shift();
    }
    line = input.shift();

    while (line !== 'End') {
        let [command, city, people, gold] = line.split('=>');

        if (command == 'Plunder') {
            target[city][0] -= Number(people);
            target[city][1] -= Number(gold);
           

            if (target[city][0] <= 0 || target[city[1] <= 0]) {
                if(target[city][0] < 0){
                    people = Number(target[city][0]);
                }else if(target[city][1] < 0){
                    gold = Number(gold) + Number(target[city][1]);
                }
                delete target[city];
                console.log(`${city} plundered! ${gold} gold stolen, ${people} citizens killed.`);
                console.log(`${city} has been wiped off the map!`);
            } else{
                console.log(`${city} plundered! ${gold} gold stolen, ${people} citizens killed.`);
            }
        }else if(command == 'Prosper'){
            let ammountGold = Number(people);
            if(ammountGold > 0){
                target[city][1] += ammountGold;
                console.log(`${ammountGold} gold added to the city treasury. ${city} now has ${target[city][1]} gold.`);
               
            }else{
                console.log("Gold added cannot be a negative number!");   
            }
        }
        line = input.shift();
    }
    let citiesToPrint = Object.values(target).length;
    if(citiesToPrint < 0){
console.log("Ahoy, Captain! All targets have been plundered and destroyed!");
    }else{
        console.log(`Ahoy, Captain! There are ${citiesToPrint} wealthy settlements to go to:`);
        Object.entries(target).forEach((key) => {
            console.log(`${key[0]} -> Population: ${key[1][0]} citizens, Gold: ${key[1][1]} kg`);
        });
    }
}
pirates(["Tortuga||345000||1250",
    "Santo Domingo||240000||630",
    "Havana||410000||1100",
    "Sail",
    "Plunder=>Tortuga=>75000=>380",
    "Prosper=>Santo Domingo=>180",
    "End"]);
console.log('---');
pirates(["Nassau||95000||1000",
    "San Juan||930000||1250",
    "Campeche||270000||690",
    "Port Royal||320000||1000",
    "Port Royal||100000||2000",
    "Sail",
    "Prosper=>Port Royal=>-200",
    "Plunder=>Nassau=>94000=>750",
    "Plunder=>Nassau=>1000=>150",
    "Plunder=>Campeche=>150000=>690",
    "End"]);

