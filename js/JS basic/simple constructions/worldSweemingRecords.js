function worldSwimmingRecord(input){

    let record = Number(input[0]);
    let distance = Number(input[1]);
    let secPerMeter = Number(input[2]);

    let totalTime = (distance * secPerMeter + ((distance / 15) *12.5));
    let timeNeeded = totalTime - record

    if(totalTime > record){
        console.log(`No, he failed! He was ${timeNeeded.toFixed(2)} seconds slower.`);
    }
    else{
        console.log(`Yes, he succeeded! The new world record is ${totalTime.toFixed(2)} seconds.`)
    }

   



}

worldSwimmingRecord(["55555.67", "3017", "5.03"]);

