function convertToObject(objAsJson) {
    let parsed = JSON.parse(objAsJson);

    for(let key of Object.keys(parsed)){
console.log(`${key}: ${parsed[key]}`);
    }
}
convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');