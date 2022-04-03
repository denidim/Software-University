function solve(input) {
    let totalTax = 0;
    let totalTaxesCollected = 0;

    for (let el of input) {
        let str = el.split('>>');
        let tokens = [];
        for (let index = 0; index < str.length; index++) {
            tokens = str[index].split(' ');
            let carType = tokens[0];
            let years = Number(tokens[1]);
            let km = Number(tokens[2]);

            if (carType === 'family') {
                totalTax = Math.trunc(km / 3000) * 12 + (50 - years * 5);
                totalTaxesCollected += totalTax;

            } else if (carType === 'heavyDuty') {
                totalTax = Math.trunc(km / 9000) * 14 + (80 - years * 8);
                totalTaxesCollected += totalTax;

            } else if (carType === 'sports') {
                totalTax = Math.trunc(km / 2000) * 18 + (100 - years * 9);
                totalTaxesCollected += totalTax;
            } else {
                console.log('Invalid car type.');
                continue;
            }
            console.log(`A ${carType} car will pay ${totalTax.toFixed(2)} euros in taxes.`);
        }

    }
    console.log(`The National Revenue Agency will collect ${totalTaxesCollected.toFixed(2)} euros in taxes.`);
}

solve(['family 3 7210>>van 4 2345>>heavyDuty 9 31000>>sports 4 7410']);

solve(['family 5 3210>>pickUp 1 1345>>heavyDuty 7 21000>>sports 5 9410>>family 3 9012']);
