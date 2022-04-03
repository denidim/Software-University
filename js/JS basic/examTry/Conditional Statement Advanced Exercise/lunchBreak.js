function lunchBreak(input) {

    let serial = input[0];
    let epizodTime = Number(input[1]);
    let breakTime = Number(input[2]);

    let lunchTime = breakTime / 8;
    let relaxTime = breakTime / 4;
    let totalTime = epizodTime + lunchTime + relaxTime;
   
      if(breakTime >= totalTime){
        let timeLeft = breakTime - totalTime;
        console.log(`You have enough time to watch ${serial} and left with ${Math.ceil(timeLeft)} minutes free time.`);
      }

      if(totalTime > breakTime) {
           let timeNeeded = totalTime - breakTime;
          console.log(`You don't have enough time to watch ${serial}, you need ${Math.ceil(timeNeeded)} more minutes.`);
     }
}
lunchBreak(["Game of Thrones",
"60",
"96"])
