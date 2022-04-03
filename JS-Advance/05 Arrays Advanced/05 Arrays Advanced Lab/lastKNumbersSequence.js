function lastKSequence(n, k) {
    let result = [1];

    for (let i = 1; i < n; i++) {
        let current = 0;

        for (let num of result.slice(-k)) {
            current += num;
        }
        result.push(current);
    }
    console.log(result.join(' '));
}
lastKSequence(6, 3);
lastKSequence(8, 2);
lastKSequence(9, 5);