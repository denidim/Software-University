// function addAndSubtract(a, b, c) {
//     const sum = (a, b) => a + b;
//     const subtract = (mySum, num) => mySum - num;

//     return subtract(sum(a, b), c)
// }

// arrow function
const addAndSubtract = (a, b, c) =>
{
    const sum = (a, b) => a + b;
    const subtract = (mySum, num) => mySum - num;

    return subtract(sum(a, b), c)
}

console.log(addAndSubtract(23, 6, 10))