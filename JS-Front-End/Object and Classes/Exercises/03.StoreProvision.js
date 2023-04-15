function Solve(stock, ordered) {

    let combined = [...stock, ...ordered];

    let store = {};

    for (let i = 0; i < combined.length; i++) {
        if (i % 2 === 0) {
            if (!store.hasOwnProperty(combined[i])) {
                store[combined[i]] = 0
            }
        } else {
            store[combined[i - 1]] += Number(combined[i]);
        }
    }

    for (const key in store) {
        console.log(`${key} -> ${store[key]}`)
    }
}

Solve(
    [
        'Chips', '5', 'CocaCola', '9', 'Bananas',
        '14', 'Pasta', '4', 'Beer', '2'
    ],

    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7',
        'Tomatoes', '70', 'Bananas', '30'
    ]
)

