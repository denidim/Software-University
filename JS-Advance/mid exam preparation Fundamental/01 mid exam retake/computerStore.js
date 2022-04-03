function computerStore(input) {
   
    let priceWithoutTax = 0;
    let taxes = 0;
    let totalPrice = 0;
    let isSpecial = true;

    for (let i = 0; i < input.length; i++) {

        let curr = input[i];
        if (curr === 'special' || curr === 'regular') {
            if (curr !== 'special') {
                isSpecial = false;
            }
            break;
        } else {
            curr = Number(input[i]);
            if (curr < 0) {
                console.log('Invalid price!');
                continue;
            } else {
                priceWithoutTax += curr;
            }
        }
    }

    taxes = priceWithoutTax * 0.20;
    totalPrice = priceWithoutTax + taxes;

    if (totalPrice == 0) {
        console.log('Invalid order!');

    } else {
        if (isSpecial) {
            totalPrice -= totalPrice * 0.10;
            console.log(`Congratulations you've just bought a new computer!\nPrice without taxes: ${priceWithoutTax.toFixed(2)}$\nTaxes: ${taxes.toFixed(2)}$\n-----------\nTotal price: ${totalPrice.toFixed(2)}$`);
        } else {
            console.log(`Congratulations you've just bought a new computer!\nPrice without taxes: ${priceWithoutTax.toFixed(2)}$\nTaxes: ${taxes.toFixed(2)}$\n-----------\nTotal price: ${totalPrice.toFixed(2)}$`);
        }
    }
}


computerStore([
    '1050',
    '200',
    '450',
    '2',
    '18.50',
    '16.86',
    'special'
]);

computerStore([
    '1023',
    '15',
    '-20',
    '-5.50',
    '450',
    '20',
    '17.66',
    '19.30', 'regular'
]);

computerStore([
    'regular'
]);


