 class Vehicle {
        constructor(type, model, {engine, power}, fuel) {
            this.type = type;
            this.model = model;
            this.parts = {
                engine,
                power,
                quality: engine * power
            };
            this.fuel = Number(fuel);
        }
        drive(fuelLoss) {
            return this.fuel -= fuelLoss;
        };
    }
    

    let parts = { engine: 6, power: 100 };
    let vehicle = new Vehicle('a', 'b', parts, 200);
    vehicle.drive(100);
    console.log(vehicle.fuel);
    console.log(vehicle.parts.quality);
    



