// function printCityKeyValue(person) {
//    Object.entries(person).forEach(([key, value]) => console.log(`${key} -> ${value}`)) 
// }

// function printCityKeyValue(person){
//     Object.keys(person).forEach((key) => console.log(`${key} -> ${person[key]}`))
// }

function printCityKeyValue(person) {
    for (const key in person) {
        console.log(`${key} -> ${person[key]}`)
    }
}


printCityKeyValue(
    {
        name: "Sofia",
        area: 492,
        population: 1238438,
        country: "Bulgaria",
        postCode: "1000"
    }
);