function convertToJson(name, lastName, hairColor) {
    let result = {
        name: name,
        lastName: lastName,
        hairColor: hairColor
    };
    console.log(JSON.stringify(result));
}
convertToJson('George', 'Jones', 'Brown');