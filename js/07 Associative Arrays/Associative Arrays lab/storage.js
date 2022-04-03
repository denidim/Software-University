function storage(input) {
    let result = new Map();
    for (let line of input) {
        let [product, qty] = line.split(' ');
        qty = Number(qty);

        if (result.has(product)) {
            let existing = result.get(product);
            result.set(product, qty + existing);
        } else {
            result.set(product, qty)
        }
    }
    for(let [product, qty] of result){
        console.log(product, '->', qty);
    }
}
storage(['tomatoes 10',
    'coffee 5',
    'olives 100',
    'coffee 40']);

storage(['apple 50',
    'apple 61',
    'coffee 115',
    'coffee 40']);