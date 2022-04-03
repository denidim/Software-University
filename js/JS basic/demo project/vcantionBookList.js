function vacantionBookList(input) {

    let pages = parseInt(input[0]);
    let pagesPerHour = parseInt(input[1]);
    let days = parseInt(input[2]);

    let timeForReding = pages / pagesPerHour;
    let hoursPerDay = timeForReding / days;

    console.log(hoursPerDay);

}
vacantionBookList(['212', '20', '2']);
