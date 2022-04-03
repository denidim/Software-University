function readText(input) {

    let index = 0;
    let currentElement = input[index];

    while (currentElement !== 'Stop') {

        console.log(currentElement);
        index++
        currentElement = input[index];
    }
}

readText(["Nakov",
    "SoftUni",
    "Sofia",
    "Bulgaria",
    "SomeText",
    "Stop",
    "AfterStop",
    "Europe",
    "HelloWorld"])


