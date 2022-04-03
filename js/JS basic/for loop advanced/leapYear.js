function leapYear(input){

    let startDate = Number(input[0]);
    let endDate = Number(input[1]);

    for(let i = startDate; i <= endDate; i +=4){
        console.log(i);

    }
}
leapYear(["1908", "1919"]);
