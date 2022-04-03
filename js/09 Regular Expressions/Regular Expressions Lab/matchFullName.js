function solve(input) {
    let pattern = /\b[A-Z][a-z]+ [A-Z][a-z]+\b/g;
    let match = pattern.exec(input);
    let result = [];

    while (match != null) {
        result.push(match[0]);

        match = pattern.exec(input);
    }

    console.log(result.join(' '));
}



solve("Ivan Ivanov, Ivan ivanov, ivan Ivanov, IVan Ivanov, Test Testov, Ivan	Ivanov")