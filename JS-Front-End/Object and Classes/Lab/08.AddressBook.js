function PrintAdress(arr) {

    let person = {};

    for (const key of arr) {
        let [name, address] = key.split(':');
        person[name] = address;
    }

    Object.entries(person).sort((personA, personB) =>
        personA[0].localeCompare(personB[0]))
        .forEach(([name, address]) =>
            console.log(`${name} -> ${address}`));

    // let entries = Object.entries(person); // [[],[],[]]

    // let sortedByName = entries.sort((personA, personB) => {
    //     let personAName = personA[0];
    //     let personBName = personB[0];
    //     return personAName.localeCompare(personBName);
    // });

    // for (const [name, address] of sortedByName) {
    //     console.log(`${name} -> ${address}`);
    // }
}

PrintAdress(
    ['Bob:Huxley Rd',
        'John:Milwaukee Crossing',
        'Peter:Fordem Ave',
        'Bob:Redwing Ave',
        'George:Mesta Crossing',
        'Ted:Gateway Way',
        'Bill:Gateway Way',
        'John:Grover Rd',
        'Peter:Huxley Rd',
        'Jeff:Gateway Way',
        'Jeff:Huxley Rd']
);