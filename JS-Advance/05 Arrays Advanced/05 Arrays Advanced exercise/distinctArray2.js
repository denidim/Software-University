function distinct(numbers) {
    
    let result = [];

    for(let num of numbers){
        if(!result.includes(num)){
            result.push(num);
        }
    }
    console.log(result.join(' '));
}
distinct([7, 8, 9, 7, 2, 3, 4, 1, 2]);