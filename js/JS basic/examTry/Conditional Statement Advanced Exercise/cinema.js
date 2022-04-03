function cinemaTickets(input) {
    
    let type = input[0];
    let row = Number(input[1]);
    let columns = Number(input[2]);
    let income = 0;

    switch (type) {
        case 'Premiere': income = row * columns * 12.00; break;

        case 'Normal': income = row * columns * 7.50; break;

        case 'Discount': income = row * columns * 5.00; break;
    }
    console.log(income.toFixed(2) + ' leva');
}
cinemaTickets(["Premiere", "10", "12"]);

