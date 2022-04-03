function bills(input) {
    
    let months = Number(input[0]);
    let electrycity = Number(input[1]);

    let index = 2;
    let totalElectricity=0; 
   
    let totalPerMonth = 0;
   
    let water = 20;
    let internet = 15;
    let other = 0;
    let avg = 0;

    for(let i = 1; i <= months; i ++){

        totalElectricity += electrycity;
        let procent = (electrycity + water + internet) * 0.20;
      
        totalPerMonth =  procent + electrycity + water + internet;
        other += totalPerMonth;
        electrycity = Number(input[index]);
        index++;
    }
    let totalWater = months * 20;
    let totalInternet = months * 15;
  avg = (totalElectricity + totalWater + totalInternet + other) / months;

    console.log(`Electricity: ${totalElectricity.toFixed(2)} lv`);
    console.log(`Water: ${totalWater.toFixed(2)} lv`);
    console.log(`Internet: ${totalInternet.toFixed(2)} lv`);
    console.log(`Other: ${other.toFixed(2)} lv`);
    console.log(`Average: ${avg.toFixed(2)} lv`);
}
bills(['5', '68.63', '89.25', '132.53', '93.53', '63.22'])