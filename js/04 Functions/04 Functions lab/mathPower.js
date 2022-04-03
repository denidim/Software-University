function power(x, n) {
    let result = 1;

    for(let i = 0; i < n; i++){
        result *= x;
    }
    console.log(result);
}
mathPower(2, 8);
mathPower(3, 4);
