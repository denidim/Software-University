function holiday(input) {

    let people = Number(input[0]);
    let nights = Number(input[1]);
    let travelTickets = Number(input[2]);
    let museumTickets = Number(input[3]);
    

    let sumNightPerPerson = nights * 20;
    let sumTransportPerPerson = travelTickets * 1.60;
    let sumMuseumPerPerson = museumTickets * 6;

    let totalPerPerson = sumNightPerPerson + sumTransportPerPerson + sumMuseumPerPerson;
    let total = people * totalPerPerson;
    let result = total * 0.25 + total;

    console.log(result.toFixed(2));
}
holiday(["131", "9", "33", "46"]);

