function foodExpenditure([arg1, arg2]){
    let dogs = parseInt(arg1);
    let animals = parseInt(arg2);
    let sum = (dogs * 2.5) + (animals * 4);
    
    console.log(sum + ' lv.');
}
foodExpenditure(['5', '4'])