function rectangleN(input) {
    let n = Number(input[0]);
    let num = 1;
    
    while (num <= n) {
        console.log("*" + "*".repeat(n - 1));
        num++;
    }
}
rectangleN(['5']);