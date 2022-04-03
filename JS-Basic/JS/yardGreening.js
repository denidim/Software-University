function yardGreening(input){
    let squareMeters = parseFloat(input[0]);
    let yard = squareMeters * 7.61;
    let discount = yard * 0.18;
    let price = yard - discount;

    console.log(`The final price is: ${price} lv.`);
    console.log(`The discount is: ${discount} lv.`);


}
yardGreening(['550']);