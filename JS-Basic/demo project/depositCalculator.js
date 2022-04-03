function depositCalculatior(input){

    let depositedSum = Number(input[0]);
    let period = Number(input[1]);
    let interest = Number(input[2]);

    let sum = depositedSum + period * ((depositedSum * (interest / 100)) / 12);

    console.log(sum);

}
depositCalculatior(['200', '3', '5.7']);