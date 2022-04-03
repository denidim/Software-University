function numberInRange(input) {

    let n = Number(input[0]);

    if (n >= -100 && n <= 100 && n !== 0) {
        console.log('Yes');

    }
    else {
        console.log('No');
    }

}
numberInRange(['25']);