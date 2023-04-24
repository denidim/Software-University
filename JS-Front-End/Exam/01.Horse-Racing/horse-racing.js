function solve(array) {
    let horses = array.shift().split('|');
    for (let i = 0; i < array.length; i++) {
        let command = array[i];
        let splittedCommand = command.split(' ');
        if (splittedCommand[0] === 'Finish') {
            break;
        }

        if (splittedCommand[0] === 'Retake') {
            let overtakingHorse = splittedCommand[1];
            let overtakenHorse = splittedCommand[2];

            let indexOfOvertakingHorse = horses.indexOf(overtakingHorse);
            let indexOfOvertakenHorse = horses.indexOf(overtakenHorse);

            if (indexOfOvertakingHorse < indexOfOvertakenHorse) {
                horses[indexOfOvertakingHorse] = overtakenHorse;
                horses[indexOfOvertakenHorse] = overtakingHorse;
                console.log(`${overtakingHorse} retakes ${overtakenHorse}.`);
            }
        }

        if (splittedCommand[0] === 'Trouble') {
            let troubleHorse = splittedCommand[1];

            let indexOfTroubleHorse = horses.indexOf(troubleHorse);

            if (indexOfTroubleHorse !== 0) {
                let previousHorse = horses[indexOfTroubleHorse - 1];
                horses[indexOfTroubleHorse] = previousHorse;
                horses[indexOfTroubleHorse - 1] = troubleHorse;

                console.log(`Trouble for ${troubleHorse} - drops one position.`);
            }
        }

        if (splittedCommand[0] === 'Rage') {
            let ragingHorse = splittedCommand[1];

            let indexOfRagingHorse = horses.indexOf(ragingHorse);

            if (indexOfRagingHorse === horses.length - 2) {
                let overtaken = horses[horses.length - 1];
                horses[horses.length - 1] = ragingHorse;
                horses[indexOfRagingHorse] = overtaken;
            } else if (indexOfRagingHorse < horses.length - 2) {

                let ragingHorse = horses[indexOfRagingHorse]

                let firstOvertake = horses[indexOfRagingHorse + 1];
                let secondOvertake = horses[indexOfRagingHorse + 2];

                horses[indexOfRagingHorse] = firstOvertake;
                horses[indexOfRagingHorse + 1] = secondOvertake;
                horses[indexOfRagingHorse + 2] = ragingHorse;

            }
            console.log(`${ragingHorse} rages 2 positions ahead.`)
        }

        if (splittedCommand[0] === 'Miracle') {

            let miracleHorse = horses[0];
            for (let i = 1; i < horses.length; i++) {
                horses[i - 1] = horses[i];
            }

            horses[horses.length - 1] = miracleHorse;

            console.log(`What a miracle - ${miracleHorse} becomes first.`);
        }
    }

    console.log(horses.join('->'));

    console.log(`The winner is: ${horses[horses.length - 1]}`);
}

// solve((['Bella|Alexia|Sugar',

//     'Retake Alexia Sugar',

//     'Rage Bella',

//     'Trouble Bella',

//     'Finish']));

// solve((['Onyx|Domino|Sugar|Fiona',

//     'Trouble Onyx',

//     'Retake Onyx Sugar',

//     'Rage Domino',

//     'Miracle',

//     'Finish']));

solve((['Fancy|Lilly',

    'Retake Lilly Fancy',

    'Trouble Lilly',

    'Trouble Lilly',

    'Finish',

    'Rage Lilly']));