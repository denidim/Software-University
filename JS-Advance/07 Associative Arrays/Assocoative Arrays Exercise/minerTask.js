function minerTask(input) {
    let resources = new Map();
    let arrLength = input.length;

    for (let i = 0; i < arrLength; i += 2) {
        let curr = input[i];
        let quantity = Number(input[i + 1]);

        if (!resources.has(curr)) {
            resources.set(curr, 0);
        }
        let updateQuantity = resources.get(curr);
        updateQuantity += quantity;
        resources.set(curr, updateQuantity);
    }
    for (let item of resources) {
        console.log(`${item[0]} -> ${item[1]}`);
    }
}
minerTask([
    'Gold',
    '155',
    'Silver',
    '10',
    'Copper',
    '17'
]);

minerTask([
    'gold',
    '155',
    'silver',
    '10',
    'copper',
    '17',
    'gold',
    '15'
]);