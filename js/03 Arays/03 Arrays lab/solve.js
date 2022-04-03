function solve(n, array) {
    let result = [];
    for (let i = n - 1; i >= 0; i--) {
        result.push(array[i]);
    }
    console.log(result.join(' '));
}
solve(3, [10, 20, 30, 40, 50]);