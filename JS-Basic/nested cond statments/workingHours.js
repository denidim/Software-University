function workingHours(input) {
    let h = Number(input[0]);
    let day = input[1];
    if(h >= 10 && h < 18 && day !== 'Sunday'){
        console.log('open');
    }else{
        console.log('closed');
    }

}
workingHours(["11",
"Sunday"])

