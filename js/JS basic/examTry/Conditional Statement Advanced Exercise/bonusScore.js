function bonusScore(input) {

    let num = Number(input[0]);
    let bonusPoint = 0;
    
    if(num <= 100){

        bonusPoint += 5;
    }else if(num > 1000){
        bonusPoint = num * 0.10;

    }else{
        bonusPoint = num * 0.20;
    }

    if( num % 2 === 0){
        bonusPoint +=1;
    }
    if(num % 10 === 5){
        bonusPoint+=2;
    }
    console.log(bonusPoint);
    console.log(num + bonusPoint);
    
}
bonusScore(['2703']);