function Dictionary(input){
    let obj = {};
    for (const line of input) {
        let newObj = JSON.parse(line);
        obj[Object.keys(newObj)[0]] = Object.values(newObj)[0];
    }

    let sorted = Object.entries(obj).sort((a,b) => a[0].localeCompare(b[0]))

    for (const [term,defenition] of sorted) {
        console.log(`Term: ${term} => Definition: ${defenition}`)
    }
}

Dictionary([

    '{"Cup":"A small bowl-shaped container for drinking from, typically having a handle"}',
    
    '{"Cake":"An item of soft sweetfood made from a mixture of flour, fat, eggs, sugar, and other ingredients, baked and sometimes iced or decorated."}',
    
    '{"Watermelon":"The large fruit of a plant of the gourd family, with smooth green skin, red pulp, and watery juice."} ',
    
    '{"Music":"Vocal or instrumental sounds (or both) combined in such a way as to produce beauty of form, harmony, and expression of emotion."} ',
    
    '{"Art":"The expression or application of human creative skill and imagination, typically in a visual form such as painting or sculpture, producing works to be appreciated primarily for their beauty or emotional power."} ']);