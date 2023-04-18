function colorize() {
    let rows = Array.from(document.querySelectorAll('table > tbody > tr:not(:first-child):nth-child(even)'));
    for (const row of rows) {
        row.style.backgroundColor = 'teal';
    }
}