function travel(input) {

    let index = 0;
    let destination = input[index];
    index++;

    let budget = 0;
    let savings = 0;

    while (destination !== 'End') {
        budget = Number(input[index]);
        index++;

        while (savings < budget) {

            savings += Number(input[index]);
            index++;

        }
        savings = 0;

        console.log(`Going to ${destination}!`);

        destination = input[index];
        index++;


    }


}
travel([
    "Greece",
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
    "End"]);

