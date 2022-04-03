function nexDay(year, month, day) {
    let newDay = 0;
    if (year === 1) {
        year += 1900;
    }
    for (let i = year; i <= year; i++) {

        for (let j = month; j <= 12; j++) {

            for (let d = day; d <= 31; d++) {

                newDay++;
            }

        }
        console.log(`${year}-${month}-${day + 1}`);
    }
}

nexDay(2016, 9, 30);