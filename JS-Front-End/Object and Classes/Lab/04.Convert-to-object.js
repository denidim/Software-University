function ConvertToObject(string) {
    let obj = JSON.parse(string);
    Object.keys(obj).forEach((key) => console.log(`${key}: ${obj[key]}`))
}

ConvertToObject(
    '{"name": "George", "age": 40, "town": "Sofia"}'
);