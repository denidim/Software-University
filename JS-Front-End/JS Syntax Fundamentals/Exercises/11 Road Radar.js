function solve(speed, area) {
    const motorway = 130;
    const interstate = 90;
    const city = 50;
    const residential = 20;
    let status;

    if (area == 'city' && speed <= city) {
        console.log(`Driving ${speed} km/h in a ${city} zone`)
    } else if (area == 'city' && speed > city) {
        if (speed - city <= 20) {
            status = 'speeding';
        } else if (speed - city > 20 && speed - city <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${speed - city} km/h faster than the allowed speed of ${city} - ${status}`);
    }
    else if (area == 'residential' && speed <= residential) {
        console.log(`Driving ${speed} km/h in a ${residential} zone`)
    } else if (area == 'residential' && speed > residential) {
        if (speed - residential <= 20) {
            status = 'speeding';
        } else if (speed - residential > 20 && speed - residential <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${speed - residential} km/h faster than the allowed speed of ${residential} - ${status}`);
    }
    else if (area == 'interstate' && speed <= interstate) {
        console.log(`Driving ${speed} km/h in a ${interstate} zone`)
    } else if (area == 'interstate' && speed > interstate) {
        if (speed - interstate <= 20) {
            status = 'speeding';
        } else if (speed - interstate > 20 && speed - interstate <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${speed - interstate} km/h faster than the allowed speed of ${interstate} - ${status}`);
    }
    else if (area == 'motorway' && speed <= motorway) {
        console.log(`Driving ${speed} km/h in a ${motorway} zone`)
    } else if (area == 'motorway' && speed > motorway) {
        if (speed - motorway <= 20) {
            status = 'speeding';
        } else if (speed - motorway > 20 && speed - motorway <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${speed - motorway} km/h faster than the allowed speed of ${motorway} - ${status}`);
    }
}

solve(91, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');