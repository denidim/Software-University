function toyShop(input) {

    let trip = Number(input[0]);
    let puzels = Number(input[1]);
    let dolls = Number(input[2]);
    let bears = Number(input[3]);
    let minions = Number(input[4]);
    let trucks = Number(input[5]);

    let sum = puzels * 2.60 + dolls * 3 + bears * 4.10 + minions * 8.20 + trucks * 2;
    let totalToys = puzels + dolls + bears + minions + trucks;

    if(totalToys >= 50){
        sum =sum * 0.75;
        
    }
    sum = sum * 0.90;

    if(sum >= trip){
    console.log(`Yes! ${(sum - trip).toFixed(2)} lv left.`);
    } else{
        console.log(`Not enough money! ${(trip - sum).toFixed(2)} lv needed.`);
    }

    
}
toyShop(['40.8', '20', '25', '30', '50', '10'])