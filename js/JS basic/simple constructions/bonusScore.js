function bonusScore(input) {
    let num = Number(input[0]);
    let bonus = 0;
    if (num % 2 === 0) {
        bonus = bonus + 1;
    } else if (num % 5 === 0) {
        bonus = bonus + 2;
    }
    if (num <= 100) {
        bonus = bonus + 5;
        num = num + bonus;
    } else if (num < 1000) {
        bonus = bonus + num * 0.20;
        num = num + bonus;
    } else {
        bonus = bonus + num * 0.10;
        num = num + bonus;
    }
    console.log(`${bonus}`);
    console.log(`${num}`);
}
bonusScore([`2703`]);