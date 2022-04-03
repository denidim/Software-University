function sign(a, b, c) {


    if ((a > 0 && b > 0) || (a < 0 && b < 0)) {
        if (c > 0) {
            console.log('Positive');
        } else {
            console.log('Negative');
        }
    } else {
        if (c > 0) {
            console.log('Negative');
        } else {
            console.log('Positive');
        }
    }
}
sign(5, 12, -15);
sign(-6, -12, 14);
sign(-1, -2, -3);
sign(-5, 1, 1);
