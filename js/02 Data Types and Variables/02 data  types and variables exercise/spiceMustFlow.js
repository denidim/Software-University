function spiceMustFlow(startingYield) {
    let days = 1;
    let yielDrop = 0;
    let extract = 0;
    let totalAmount = 0;
    for (let i = startingYield; i <= 100; i++) {
        if (days === 1) {
        extract = i - 26;
            totalAmount += extract;
            yielDrop = i - 10;
        } else if (days >= 2) {
            extract = yielDrop + 26;
            totalAmount += extract;
            yielDrop -= 10;
        }
       
        if(yielDrop < 100){
            totalAmount -= 26;
            break;
        }
        days ++;
       
    }
    console.log(days);
    console.log(totalAmount);
}
spiceMustFlow(111);