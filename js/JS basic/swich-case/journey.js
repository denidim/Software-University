function journey(input) {
    
    let budget = Number(input[0]);
    let season = input[1];
    let price = 0;
    let destination = '';
    let type = '';

    if (budget <= 100){
        destination = 'Bulgaria';

        if(season === 'summer'){
           price = budget * 0.30; 
           type = 'Camp';
         
        }else if(season === 'winter'){
            price = budget * 0.70;
            type = 'Hotel'
        }

    } else if(budget > 100 && budget <= 1000){
        destination = 'Balkans';

        if(season === 'summer'){
            type = 'Camp';
            price = budget * 0.40;

        }else if(season === 'winter'){
            type = 'Hotel';
            price = budget * 0.80;
        }
    } else if(budget > 1000){
        destination = 'Europe';
        price = budget * 0.90;
        type = 'Hotel'
    }
    console.log(`Somewhere in ${destination}`);   
    console.log(`${type} - ${price.toFixed(2)}`);      
}
journey(["1500", "summer"])