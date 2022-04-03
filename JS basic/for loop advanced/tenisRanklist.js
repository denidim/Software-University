function tenisRank(input) {

    let turnirs = Number(input[0]);
    let startPoints = Number(input[1]);
    let index = 2;
    let turnirPosition = input[index];
    index++;
    let turnirPoints = 0;
    let totalPoints = 0;
    let avrPoints = 0;
    let procent = 0;
    let counterWin = 0;

    for (let i = 1; i <= turnirs; i++) {

        if (turnirPosition === 'W') {
            turnirPoints += 2000;
            counterWin++;
        }
        else if (turnirPosition === 'F') {
            turnirPoints += 1200;
        }
        else if (turnirPosition === 'SF') {
            turnirPoints += 720;
        }
        turnirPosition = input[index];
        index++;
       
    }
    avrPoints = turnirPoints / turnirs;
    totalPoints = turnirPoints + startPoints;
    procent = counterWin / turnirs * 100;

    console.log(`Final points: ${totalPoints}`);
    console.log(`Average points: ${Math.floor(avrPoints)}`);
    console.log(`${procent.toFixed(2)}%`);

}
tenisRank(["4",
"750",
"SF",
"W",
"SF",
"W"])

