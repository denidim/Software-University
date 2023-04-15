function PrintEmployee(input) {
    // let employee = {};

    // for (const element of input) {
    //     employee[element] = element.length
    // }

    // for (const key in employee) {
    //     console.log(`Name: ${key} -- Personal Number: ${employee[key]}`)
    // }

    Object.entries(
        input.reduce((data, element) => {
            data[element] = element.length;
            return data;
        }, {})
    ).forEach(([employee, length]) => {
        console.log(`Name: ${employee} -- Personal Number: ${length}`)
    })

}

PrintEmployee(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal'])