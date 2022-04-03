function addressBook(input) {

    let result = {};

    for(let line of input){
        let [name, address] = line.split(':');

        result[name] = address;
    }
    let sorted = Object.entries(result);
    sorted.sort((a, b)=> a[0].localeCompare(b[0]));

    for(let [name, address] of sorted){
        console.log(name, '->', address);
    }
    
}
addressBook(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']);

addressBook(['John:Milwaukee Crossing',
'Peter:Fordem Ave',
'Bob:Redwing Ave',
'George:Mesta Crossing',
'Ted:Gateway Way',
'Bill:Gateway Way',
'John:Grover Rd',
'Peter:Huxley Rd',
'Jeff:Gateway Way',
'Jeff:Huxley Rd']);