function houseParty(list) {
    let guests = [];

    for (let i = 0; i < list.length; i++) {
        
        let currentEl = list[i];
        let tokens = currentEl.split(' ');
        let name = tokens[0];

        if(!guests.includes(name)){
            guests += name;
        } else{
            console.log(name);
        }
    }
}
houseParty(['Allie is going!',
    'George is going!',
    'John is not going!',
    'George is not going!']);