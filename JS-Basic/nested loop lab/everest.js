function everest(input) {

    let index = 0;
    let beginAt = 5364;
    let finishAt = 8848;
    let day = 1;

    while (true) {
        let command = input[index];
        index++;
        if (command === "Yes") {
            day++;
        }
        if (command === "END" || day > 5) {

            console.log(`Failed!`);
            console.log(beginAt);
            break;
        }

        let meterClimed = Number(input[index]);
        index++;
        beginAt += meterClimed;

        if (beginAt >= finishAt) {
            console.log(`Goal reached for ${day} days!`);
            break;
        }
    }
}
everest(["Yes",
    "535",
    "Yes",
    "849",
    "Yes",
    "499",
    "Yes",
    "400",
    "Yes",
    "500"])

//7647