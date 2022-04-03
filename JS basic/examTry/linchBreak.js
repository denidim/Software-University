function lunchBreak(input) {

    let serialName = input[0];
    let episodeTime = Number(input[1]);
    let breakTime = Number(input[2]);

    let lunchTime = breakTime / 8;
    let relaxTime = breakTime / 4;
    let enoughTime = episodeTime + lunchTime + relaxTime;

    if (breakTime >= enoughTime){
        console.log(`You have enough time to watch ${serialName} and left with ${Math.ceil(breakTime - enoughTime)} minutes free time.`);
    }else{
        console.log(`You don't have enough time to watch ${serialName}, you need ${Math.ceil(enoughTime - breakTime)} more minutes.`);
    }

    
}
lunchBreak(["Teen Wolf","48", "60"]);
    