function fishTank(input){

    let lenght = parseInt(input[0]);
    let wide = parseInt(input[1]);
    let high = parseInt(input[2]);
    let precentage = parseFloat(input[3]);

    let volume = lenght * wide * high;
    let liters = volume * 0.001;
    let precentageFull = precentage * 0.01;
    let litersFull = liters *(1 -precentageFull);


    console.log(litersFull);
    
}
fishTank(['85', '75', '47', '17']);