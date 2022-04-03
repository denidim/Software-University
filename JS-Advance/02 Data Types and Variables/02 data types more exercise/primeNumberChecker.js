function primeNumberChecker(num) {
    let isPrime = false;

    if (num === 2) {
        isPrime = true;
    }
    for (let i = 2; i < num; i++) {

        if (num % i === 0 && num / 1 !== 0) {
            isPrime = false;
        } else if (num === i * i) {
            isPrime = false
        }
    }


    console.log(`${num ? 'true' : 'false'}`);
}
primeNumberChecker(7);
primeNumberChecker(8);
primeNumberChecker(81);
