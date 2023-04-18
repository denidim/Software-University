function sumTable() {
    let rows = Array.from(document.querySelectorAll('table > tbody  td:nth-child(2):not(#sum)'))//:nth-child(2)'));

    let newArr = rows.map((e) => Number(e.textContent));

    let sum = newArr.reduce((partialSum, a) => partialSum + a, 0);

    let s = document.getElementById('sum').textContent = sum;
}