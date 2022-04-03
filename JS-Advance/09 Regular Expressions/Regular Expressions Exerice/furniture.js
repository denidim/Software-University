function furnitureStore(input) {
    let pattern = />>(?<name>[A-Za-z]+)<<(?<price>\d+(?:\.\d+)?)!(?<qty>\d+)/;
    let furniture = [];
    let total = 0;

    while (input[0] != 'Purchase') {
        let line = input.shift();
        let match = pattern.exec(line);

        if (match != null) {
            let { name, price, qty } = match.groups;
            price = Number(price);
            qty = Number(qty);
            total += price * qty;
            furniture.push(name);
        }
    }
    console.log('Bought furniture:');
    for(let item of furniture){
        console.log(item);
    }
    console.log('Total money spend: '+ total.toFixed(2));
}
// furnitureStore(['>>Sofa<<312.23!3',
//     '>>TV<<300!5',
//     '>Invalid<<!5',
//     'Purchase']);

furnitureStore(['>>Laptop<<312.2323!3',
'>>TV<<300.21314!5',
'>Invalid<<!5',
'>>TV<<300.21314!20',
'>>Invalid<!5',
'>>TV<<30.21314!5',
'>>Invalid<<!!5',
'Purchase']);