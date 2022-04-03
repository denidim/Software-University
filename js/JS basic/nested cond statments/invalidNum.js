function invalidNumber(input) {
    let num = Number(input[0]);

    if(num >= 100 && num <= 200 || num === 0 ){
        console.log();
    }else{
        console.log('invalid');
    }
}
invalidNumber(['0'])