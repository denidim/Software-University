function travel(input) {
    let index = 0
    let destination = input[index];
    index++;

    while (destination !== 'End') {
        let budget = Number(input[index]);
        index++;
        let sum = 0;

        while (budget > sum) {
            let money = Number(input[index]);
            index++
            sum += money;

        }
        console.log(`Going to ${destination}!`);
        destination = input[index];
        index++;
    }

}
travel(["Greece",
    "1000",
    "200",
    "200",
    "300",
    "100",
    "150",
    "240",
    "Spain",
    "1200",
    "300",
    "500",
    "193",
    "423",
    "End"])

