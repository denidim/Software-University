function triangle(input) {
    let row = Number(input[0]);
    let line = "";

    for (let col = 1; col <= row; col++) {
        line += "$ ";
        console.log(line);
    }
}
triangle([3]);