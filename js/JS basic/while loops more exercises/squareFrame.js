function squareFrame(input) {
    let n = Number(input[0]);

    for (let row = 0; row < n; row++) {

        if (row === 0 || row === n - 1) {
            console.log("+" + " -".repeat(n - 2) + " +");
            for (let col = 0; col < n - 2; col++) {
            }
        } 
        else {
            console.log("|" + " -".repeat(n - 2) + " |");
        }
    }
}
squareFrame([5]);