function softuniReception(arr) {
    let studentCount = Number(arr.pop());
    let employeeEfficiency = arr.map(Number);
    let questionsPerHour = 0;
   
    let hourCounter = 0;

    for(let i = 0; i < employeeEfficiency.length; i++){
        questionsPerHour += employeeEfficiency[i];
    }

    while (studentCount > 0) {
        hourCounter ++;
        if(hourCounter % 4 !== 0){
            studentCount -= questionsPerHour; 
        }
        
    }
    
    console.log(`Time needed: ${hourCounter}h.`);
console.log(questionsPerHour);
}

softuniReception(['5','6','4','20']);

softuniReception(['1','2','3','45']);