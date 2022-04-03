function walking(input) {

    let target = 10000;
    let index = 0;
    let command = input[index];
    index++;

    let steps = 0;

    while (command !== 'Going home') {
        let currentSteps = Number(command);
        steps += currentSteps;

        if (steps >= target) {
            console.log(`Goal reached! Good job!`);
            console.log(`${steps - target} steps over the goal!`);
            break;

        }
        command = input[index];
        index++;
    }

    if (command === 'Going home') {
        let currentSteps = Number(input[index]);
        index++;
        steps += currentSteps;

        if (steps >= target) {
            console.log(`Goal reached! Good job!`);
            console.log(`${steps - target} steps over the goal!`);
            
        }else{
            console.log(`${target - steps} more steps to reach goal.`);
        }
    }
}

    walking(["1500",
    "300",
    "2500",
    "3000",
    "Going home",
    "200"])
    
    
    
