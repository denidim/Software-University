function evenPower(input){

    let finalPower = Number(input[0]);

    for(let power = 0; power <= finalPower; power +=2){
        console.log(Math.pow(2, power));
    }
}
evenPower(['10'])