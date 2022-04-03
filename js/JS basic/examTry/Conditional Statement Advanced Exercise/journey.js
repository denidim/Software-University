
function journey(input) {

    let budget = Number(input[0]);
    let season = input[1];
    let price = 0;
    let destination = '';
    let typeHoliday = '';


    if (season === 'summer' ) {
        if(budget <= 100);{
        price = budget * 0.30;
        destination = 'Bulgaria';
        typeHoliday = 'Camp';
        }
    }
    else if (season === 'summer') {
        if(budget > 100 && budget <= 1000){
        price = budget * 0.40;
        destination = 'Balkans';
        typeHoliday = 'Camp';
        }
    }
    else if (season === 'summer') {
        if(budget > 1000){
        price = budget * 0.90;
        destination = 'Europe';
        typeHoliday = 'Hotel';
        }
    }

    else if (season === 'winter' ){
        if(budget > 1000){
        price = budget * 0.90;
        destination = 'Europe';
        typeHoliday = 'Hotel';
        }
    }

    else if (season === 'winter' ) {
        if(budget <= 100){
        price = budget * 0.70;
        destination = 'Bulgaria';
        typeHoliday = 'Hotel';
        }
    }
    else  if (season === 'winter' ) {
        if(gudget > 100 && budget <= 1000){
        price = budget * 0.80;
        destination = 'Balkans';
        typeHoliday = 'Hotel';
        }
    }


    console.log(`Somewhere in ${destination}`);
    console.log(`${typeHoliday} - ${price.toFixed(2)}`)


}

journey(["75", "winter"]);