function oscars(input) {
    let actorName = input[0];
    let pointAcad = Number(input[1]);
    let jurry = Number(input[2]);
    let index = 3;
    let jurryName = input[index];
    index++;
    let jurryPoints = Number(input[index]);
    index++;

    for (let i = 0; i < jurry; i++) {

        pointAcad += ((jurryName.length * jurryPoints) / 2);
         if(pointAcad > 1250.5){
             break;
         }

        jurryName = input[index];
        index++;
        jurryPoints = Number(input[index]);
        index++;
        
    }

    if (pointAcad > 1250.5) {
        console.log(`Congratulations, ${actorName} got a nominee for leading role with ${pointAcad.toFixed(1)}!`);
    } else {
        let pointsNeeded = 1250.5 - pointAcad;
        console.log(`Sorry, ${actorName} you need ${pointsNeeded.toFixed(1)} more!`);
    }
}
oscars(["Sandra Bullock",
"340",
"5",
"Robert De Niro",
"50",
"Julia Roberts",
"40.5",
"Daniel Day-Lewis",
"39.4",
"Nicolas Cage",
"29.9",
"Stoyanka Mutafova",
"33"])
