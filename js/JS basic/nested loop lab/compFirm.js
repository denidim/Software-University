function compFirm(input) {

    let index = 0;
    let pcCount = Number(input[index]);
    index++;
    let raitingCount = 0;
    let sales = 0;
    for (let i = 0; i < pcCount; i++) {
        let num = Number(input[index]);
        index++

        let rating = num % 10;
        raitingCount += rating;

        let posibleSales = Math.trunc(num / 10);
        if (rating === 2) {
            sales += 0;
        }
        else if (rating === 3) {
            sales += posibleSales * 0.5;
        }
        else if (rating === 4) {
            sales += posibleSales * 0.7;
        }
        else if (rating === 5) {
            sales += posibleSales * 0.85
        }
        else if (rating === 6) {
            sales += posibleSales;
        }
    }
    console.log(sales.toFixed(2));
    console.log((raitingCount / pcCount).toFixed(2));
}
compFirm(["3",
"103",
"103",
"103"])


