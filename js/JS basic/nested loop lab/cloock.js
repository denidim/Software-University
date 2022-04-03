function clock(input) {

    for (let hour = 0; hour <= 23; hour++) {

        for (let min = 0; min <= 59; min++) {

            for (let sec = 0; sec <= 59; sec++)

                console.log(`${hour}:${min}:${sec}`);

        }
    }

}
clock();