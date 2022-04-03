function nationalCourt(input) {
    let people = input.pop();
    let employees = input.map(x => Number(x));
    let answerPerH = 0;
    let hour = 0;
    
    for(let employee of employees){
        answerPerH += employee;
    }
    while (people > 0) {
       hour++;
       if(hour % 4 !== 0){
        people -= answerPerH;
       } 
    }   
    console.log(`Time needed: ${hour}h.`);
}
nationalCourt(['5', '6', '4', '20']);
nationalCourt(['1', '2', '3', '45']);