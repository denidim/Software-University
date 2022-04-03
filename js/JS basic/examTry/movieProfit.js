function movieProf(input) {
    
    let movieName = input[0];
    let days = Number(input[1]);
    let ticketsPerDay = Number(input[2])
    let ticketPrice = Number(input[3]);
    let profit = Number(input[4]);

    let ticketSumtPerDay = ticketsPerDay * ticketPrice;
    let totalTicketsProfit = ticketSumtPerDay * days;
    let profitStudio = totalTicketsProfit * profit /100;

    let profitFromMovie = totalTicketsProfit - profitStudio;


    console.log(`The profit from the movie ${movieName} is ${profitFromMovie.toFixed(2)} lv.`);
}
movieProf(['The Programmer', '20', '500', '7.50', '7']);


