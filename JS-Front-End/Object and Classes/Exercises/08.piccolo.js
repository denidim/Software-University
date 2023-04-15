function SortCars(input) {
    let numbers = [];
    for (const item of input) {
        let [direction, number] = item.split(', ');
        if (direction === 'IN' && !numbers.includes(number)) {
            numbers.push(number);
        } if (direction === 'OUT' && numbers.includes(number)) {
            let index = numbers.indexOf(number);
            numbers.splice(index, 1);
        }
    }

    if (numbers.length === 0) {
        console.log(`Parking Lot is Empty`);
    } else {
        let sorted = numbers.sort((a, b) => a.localeCompare(b));
        for (const num of sorted) {
            console.log(num);
        }
    }
}

SortCars(['IN, CA2844AA', 'IN, CA2844AA', 'IN, CA1234TA', 'OUT, CA2844AA', 'IN, CA9999TT', 'IN, CA2866HI', 'OUT, CA1234TA', 'IN, CA2844AA', 'OUT, CA2866HI', 'IN, CA9876HH', 'IN, CA2822UU']);

SortCars(['IN, CA2844AA',

    'IN, CA1234TA',

    'OUT, CA2844AA',

    'OUT, CA1234TA']);