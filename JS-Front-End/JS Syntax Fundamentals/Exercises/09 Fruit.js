function solve(fruit, weightGr, priceKg) {
    let money = (weightGr * priceKg / 1000).toFixed(2);
    let weight = (weightGr / 1000).toFixed(2);
    console.log(`I need $${money} to buy ${weight} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80)
solve('apple', 1563, 2.35)