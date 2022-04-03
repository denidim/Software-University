function godzVsKong(input) {

    let budget = Number(input[0]);
    let workers = Number(input[1]);
    let suit = Number(input[2]);

    let decor = budget * 0.10;
    let totalSuits = workers * suit;
    

    if(workers >= 150){
        totalSuits = totalSuits - totalSuits * 0.10;
    }
    let totalPrice = decor + totalSuits;

    if(totalPrice > budget){
        console.log(`Not enough money!`);
        console.log(`Wingard needs ${(totalPrice - budget).toFixed(2)} leva more.`);
    }else{
        console.log('Action!');
        console.log(`Wingard starts filming with ${(budget - totalPrice).toFixed(2)} leva left.`);
    }
    
}
godzVsKong(['9587.88', '222', '55.68'])