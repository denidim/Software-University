function CovertToJSON(name, lastName, hairColor) {
    let person = {
        name,
        lastName,
        hairColor,
    };

    let json = JSON.stringify(person);
    console.log(json);
}

CovertToJSON('George', 'Jones', 'Brown');