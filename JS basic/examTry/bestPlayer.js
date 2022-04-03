function bestPlayer(input) {


    let name = input[0];
    let gols = Number(input[1]);
    let index = 2;

    let bestGoals = 0;
    let bestName = "";

    while (name !== "END") {

        if (gols >= 10) {
            bestGoals = gols;
            bestName = name;
            break;
        }

        if (gols > bestGoals) {
            bestGoals = gols;
            bestName = name;
        }

        name = input[index]
        index++;
        gols = Number(input[index])
        index++;

    }

    console.log(`${bestName} is the best player!`);

    if (bestGoals >= 3) {

        console.log(`He has scored ${bestGoals} goals and made a hat-trick !!!`);

    } else {
        console.log(`He has scored ${bestGoals} goals.`);

    }

}

bestPlayer(["Silva",
"5",
"Harry Kane",
"10"])


