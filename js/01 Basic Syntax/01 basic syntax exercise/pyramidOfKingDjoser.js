function pyramide(base, increment) {

    let gold = 0;
    let step = 1;
    
    let pyramidW = base;

    let pyramidH = 0;
    let totalStone = 0;
    let totalMarble = 0;
    let totalLapis = 0;

    for (let i = base; i >= increment; i--) {
        let pyramidArea = base * base;
    let outerLayer = pyramidArea - (base - 2) * (base - 2);
    let inerLayer = pyramidArea - outerLayer;
       // let currentArea = inerLayer;
       // pyramidW -= 2
       // let newOurerLayer = pyramidW * pyramidW;
       // let newInerLayer = currentArea - newOurerLayer;

        pyramidH += increment;
      //  let marble = newOurerLayer - increment;
      //  let stone = currentArea * increment;
       // totalStone += stone;
      //  totalMarble += outerLayer;

        if (step === 5 || step === 10) {
            lapis = marble;
            totalLapis = lapis * increment;
        }
        if (increment === inerLayer) {
            gold = inerLayer * increment;
        }
        step++;
    }
    console.log(`Stone requred: ${Math.ceil(totalStone)}`);
    console.log(`Marble requred: ${Math.ceil(totalMarble)}`);
    console.log(`Lapis Lazuli requred: ${Math.ceil(totalLapis)}`);
    console.log(`Gold requred: ${Math.ceil(gold)}`);
    console.log(`Final pyramide height: ${Math.floor(pyramidH)}`);
}
pyramide(11, 1)