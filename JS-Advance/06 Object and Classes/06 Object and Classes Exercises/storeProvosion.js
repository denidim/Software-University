function storeProvosion(currentStoke, productsOrdered) {
    
    let store = [];
    for(let i = 0; i < currentStoke.length - 1; i+=2){
        let product = currentStoke[i];
        let quantity = Number(currentStoke[i + 1]);

        let productObj = {
            product,
            quantity,
        };

        store.push(productObj);
    }

    for(let i = 0; i < productsOrdered.length - 1; i +=2){
        let product = productsOrdered[i];
        let quantity = Number(productsOrdered[i + 1]);

        let productObj = {
            product,
            quantity,
        };

        let indexOfProduct = store.findIndex(x => x.product === product);

        if(indexOfProduct === -1){
            store.push(productObj);
        } else{
            store[indexOfProduct].quantity += quantity;
        }

    }
    
    for(let stoke of store){
        console.log(`${stoke.product} -> ${stoke.quantity}`);
    }
}
storeProvosion([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
]);