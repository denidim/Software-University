function tickets(input) {

    let index = 0;
    let command = input[index];
    index++;

    let standardCounter = 0;
    let studentCounter = 0;
    let kidCounter = 0;
    let totalTicketCounter = 0;

    while (command !== 'Finish') {
        let name = command;
        let freeSpace = Number(input[index]);
        index++;

        let ticketType = input[index];
        index++;
        let ticketCounter = 0;

        while (ticketType !== 'End') {
            ticketCounter++;

            switch (ticketType) {
                case 'standard': standardCounter++; break;

                case 'student': studentCounter++; break;
                case 'kid': kidCounter++; break;

            }
            if (ticketCounter >= freeSpace) {
                break;
            }
            ticketType = input[index];
            index++;


        }
        totalTicketCounter += ticketCounter;
        let capacity = ticketCounter / freeSpace * 100;

        console.log(`${name} - ${capacity.toFixed(2)}% full.`);
        command = input[index];
        index++;

    }

    let studentTickets = studentCounter / totalTicketCounter * 100;
    let standardTickets = standardCounter / totalTicketCounter * 100;
    let kidTickets = kidCounter / totalTicketCounter * 100;

    console.log(`Total tickets: ${totalTicketCounter}`);
    console.log(`${studentTickets.toFixed(2)}% student tickets.`);
    console.log(`${standardTickets.toFixed(2)}% standard tickets.`);
    console.log(`${kidTickets.toFixed(2)}% kids tickets.`);
}
tickets(["The Matrix",
"20",
"student",
"standard",
"kid",
"kid",
"student",
"student",
"standard",
"student",
"End",
"The Green Mile",
"17",
"student",
"standard",
"standard",
"student",
"standard",
"student",
"End",
"Amadeus",
"3",
"standard",
"standard",
"standard",
"Finish"])
