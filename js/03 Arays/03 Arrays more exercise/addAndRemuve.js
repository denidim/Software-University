function addAndRemuve(arr) {
    let listOfCommand = arr;
    let newArray = [];
    let num = 1;

    for (let i = 0; i < listOfCommand.length; i++) {
        let currentEl = listOfCommand[i];

        if (currentEl === 'add') {
            newArray.push(num);
        } else if(currentEl === 'remove'){
            newArray.pop(num);
        }
        num++;    
    }
    if(newArray.length === 0){
        console.log('Empty');
    }else{
        console.log(newArray.join(' '));
    }   
}
addAndRemuve(['add', 'add', 'add', 'add']);
addAndRemuve(['add', 'add', 'remove', 'add', 'add']);
addAndRemuve(['remove', 'remove', 'remove']);