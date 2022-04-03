function multiplicationTable(n) {
    let times = 1;
    for (let i = 1; i <= 10; i++) {

        console.log(`${n} X ${times} = ${n * times}`);
        times++;
    }
}
multiplicationTable(5);
multiplicationTable(2);