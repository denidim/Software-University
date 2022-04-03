function needForSpeed(input) {
    let carNumber = Number(input.shift());

    let cars = {};

    for (let i = 0; i < carNumber; i++) {
        let line = input.shift().split('|');
        let carName = line[0];
        let mileage = Number(line[1]);
        let fuel = Number(line[2]);
        cars[carName] = {
            mileage,
            fuel
        };
    }
    while (input[0] !== 'Stop') {
        let [command, car, ...rest] = input.shift().split(' : ');

        if (cars.hasOwnProperty(car)) {

            switch (command) {
                case 'Drive':
                    let distance = Number(rest[0]);
                    let fuelNeeded = Number(rest[1]);
                    if (fuelNeeded < cars[car].fuel) {
                        cars[car].fuel -= fuelNeeded;
                        cars[car].mileage += distance;

                        console.log(`${car} driven for ${distance} kilometers. ${fuelNeeded} liters of fuel consumed.`);
                        if (cars[car].mileage >= 100000) {
                            delete cars[car];
                            console.log(`Time to sell the ${car}!`);
                        }
                    } else {
                        console.log("Not enough fuel to make that ride");
                    }
                    break;
                case 'Refuel':
                    let fuelTofill = Number(rest[0]);
                    let fuelFilled = 0;

                    if (fuelTofill > (75 - cars[car].fuel)) {
                        fuelFilled = 75 - cars[car].fuel;
                        cars[car].fuel += fuelFilled;
                        console.log(`${car} refueled with ${fuelFilled} liters`);
                    } else {
                        cars[car].fuel += fuelTofill;
                        console.log(`${car} refueled with ${fuelTofill} liters`);
                    }
                    break;
                case 'Revert':
                    let kilometers = Number(rest[0]);
                    cars[car].mileage -= kilometers;
                    console.log(`${car} mileage decreased by ${kilometers} kilometers`);
                    if (cars[car].mileage < 10000) {
                        cars[car].mileage = 10000;
                    }
                    break;
                default:
                    break;
            }
        }
    }
   
    for(let carData of Object.entries(cars)){
    
     let car = carData[0];
     let mileage = cars[car].mileage;
     let fuel = cars[car].fuel;
        console.log(`${car} -> Mileage: ${mileage} kms, Fuel in the tank: ${fuel} lt.`);
    }
}

needForSpeed([
    '3',
    'Audi A6|38000|62',
    'Mercedes CLS|11000|35',
    'Volkswagen Passat CC|45678|5',
    'Drive : Audi A6 : 543 : 47',
    'Drive : Mercedes CLS : 94 : 11',
    'Drive : Volkswagen Passat CC : 69 : 8',
    'Refuel : Audi A6 : 50',
    'Revert : Mercedes CLS : 500',
    'Revert : Audi A6 : 30000',
    'Stop'
]);
console.log('===');
needForSpeed([
    '4',
    'Lamborghini Veneno|11111|74',
    'Bugatti Veyron|12345|67',
    'Koenigsegg CCXR|67890|12',
    'Aston Martin Valkryie|99900|50',
    'Drive : Koenigsegg CCXR : 382 : 82',
    'Drive : Aston Martin Valkryie : 99 : 23',
    'Drive : Aston Martin Valkryie : 2 : 1',
    'Refuel : Lamborghini Veneno : 40',
    'Revert : Bugatti Veyron : 2000',
    'Stop'
]);