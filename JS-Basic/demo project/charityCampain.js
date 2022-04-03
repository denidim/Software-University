function charityCampain(input) {

    let days = parseInt(input[0]);
    let confectioners = parseInt(input[1]);
    let cakes = parseInt(input[2]);
    let waffles = parseInt(input[3]);
    let pancakes = parseInt(input[4]);

    let cakesSum = cakes * 45;
    let wafflesSum = waffles * 5.80;
    let pancakesSum = pancakes * 3.20;
    
    let totalSumPerDay = confectioners * (cakesSum + wafflesSum + pancakesSum);
    let totalCampainSum = totalSumPerDay * days;
    let totalIncom = totalCampainSum - (totalCampainSum / 8);

    console.log(totalIncom);

}
charityCampain(['23', '8', '14', '30', '16']);