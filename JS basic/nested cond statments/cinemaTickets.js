function cinemaTickets(input) {
    let day = input[0];
    let ticket = 0;

    switch (day) {
        case 'Monday': ticket = 12; break;
        case 'Tuesday': ticket = 12; break;
        case 'Thursday': ticket = 14; break;
        case 'Friday': ticket = 12; break;
        case 'Saturday': ticket = 16; break;
        case 'Sunday': ticket = 16; break;
    }
    console.log(ticket);
}
cinemaTickets(["Sunday"])