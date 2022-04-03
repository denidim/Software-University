function cinema(input) {

    let typeProj = input[0];
    let row = Number(input[1]);
    let column = Number(input[2]);
    let income = 0;

    switch (typeProj) {
        case 'Premiere': income = (row * column) * 12.00; break;
        case 'Normal': income = (row * column) * 7.50; break;
        case 'Discount': income = (row * column) * 5.00; break;
    }
    console.log(`${income.toFixed(2)} leva`);

}
cinema(["Normal",
"21",
"13"])
