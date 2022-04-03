function sumSeconds(input) {
    let firstCompetitor = Number(input[0]);
    let secondCompetitor = Number(input[1]);
    let thirdCompetitor = Number(input[2]);

    let total = firstCompetitor + secondCompetitor + thirdCompetitor;

    let min = Math.floor(total / 60);
    let sec = total % 60;

    if (sec < 10) {
        sec = `0${sec}`;
    }

    console.log(`${min}:${sec}`)

}
sumSeconds(["14", "12", "10"]);