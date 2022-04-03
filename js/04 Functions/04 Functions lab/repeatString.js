function repeadString(text, n) {
    let result = '';

    for (let i = 0; i < n; i++) {
        result += text;
    }
    console.log(result);
}
repeadString('abc', 3);
repeadString('String', 2);