function theLift(input) {
    let people = Number(input.shift());
    let max = 4;
    let lift = input.shift().split(' ').map(Number);
    let wagonCount = 0;

    for (let i = 0; i < lift.length; i++) {

        let curr = lift[i];
        if (curr < max) {
            let spots = max - curr;
            curr += spots;

            if (people >= spots) {
                people -= spots;
                lift[i] = curr;

            } else if (people > 0 && people < spots) {

                curr = people;
                lift[i] = curr;
                people = 0;
            } else if (people == 0) {
                curr = people;
                lift[i] = curr;
            }
        }
    }
    if (people != 0) {
        console.log(`There isn't enough space! ${people} people in a queue!\n${lift.join(' ')}`);

    } else {

        for (let wagon of lift) {

            if (wagon === max) {
                wagonCount++;
            }
        }

        if (wagonCount != lift.length && people == 0) {
            console.log(`The lift has empty spots!\n${lift.join(' ')}`);
        } else {
            console.log(lift.join(' '));
        }
    }
}


theLift([
    "15",
    "0 0 0 0"
]);

theLift([
    "20",
    "0 2 0"
]);
theLift([
    "16",
    "0 0 0 0"
]);