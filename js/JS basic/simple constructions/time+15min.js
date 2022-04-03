function timeCalculator(input){

    let hours = Number(input[0]);
    let minutes = Number(input[1])

    let totalMins = hours * 60 + minutes + 15;
    let newHours = Math.floor(totalMins / 60);
    let newMins = totalMins % 60;

    if (newHours === 24){
        newHours = 0;
    }
    if(newMins < 10){
        console.log(newHours + ':0' + newMins)
        
    }
    else {
        console.log(newHours + ':' + newMins);
    }

}
timeCalculator(["23", "59"]);