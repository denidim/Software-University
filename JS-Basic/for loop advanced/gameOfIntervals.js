function gameOfIntervals(input) {

    let steps = Number(input[0]);
    let n = Number(input[1]);
    let index = 2;

    let result1 = 0;
    let result2 = 0;
    let result3 = 0;
    let result4 = 0;
    let result5 = 0;
    let total = 0;
    let counter1 = 0;
    let counter2 = 0;
    let counter3 = 0;
    let counter4 = 0;
    let counter5 = 0;
    let counter6 = 0;


    for (let i = 1; i <= steps; i++) {

        if (n >= 0 && n <= 9) {
            result1 = n * 0.20;
            total += result1;
            counter1++;
        }
        else if (n >= 10 && n <= 19) {
            result2 = n * 0.30;
            total += result2;
            counter2++;
        }
        else if (n >= 20 && n <= 29) {
            result3 = n * 0.40;
            total += result3;
            counter3++;
        }
        else if (n >= 30 && n <= 39) {
            result4 = 50;
            total += 50;
            counter4++;
        }
        else if (n >= 40 && n <= 50) {
            result5 = 100;
            total += 100;
            counter5++;
        }
        else if (n < 0 || n > 50) {
            total = total / 2;
            counter6++;
        }

        n = Number(input[index]);
        index++;
    }
    console.log(total.toFixed(2));
    console.log(`From 0 to 9: ${(counter1 / steps * 100).toFixed(2)}%`);
    console.log(`From 10 to 19: ${(counter2 / steps * 100).toFixed(2)}%`);
    console.log(`From 20 to 29: ${(counter3 / steps * 100).toFixed(2)}%`);
    console.log(`From 30 to 39: ${(counter4 / steps * 100).toFixed(2)}%`);
    console.log(`From 40 to 50: ${(counter5 / steps * 100).toFixed(2)}%`);
    console.log(`Invalid numbers: ${(counter6 / steps * 100).toFixed(2)}%`);
}
gameOfIntervals(['10', '43', '57', '-12', '23',
    '12', '0', '50', '40', '30', '20'])