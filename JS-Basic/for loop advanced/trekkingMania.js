function trekkingMania(input) {
    let groupsNum = Number(input[0]);

    let peopleInGroup = Number(input[1]);
    let index = 2;

    let total = 0;
    let group1 = 0;
    let group2 = 0;
    let group3 = 0;
    let group4 = 0;
    let group5 = 0;
    let procent1 = 0;
    let procent2 = 0;
    let procent3 = 0;
    let procent4 = 0;
    let procent5 = 0;
    
    for (let i = 1; i <= groupsNum; i++) {
        peopleInGroup = Number(input[i]);
        total += peopleInGroup;
    }
    peopleInGroup = Number(input[1]);

 for(let a = 1; a <= groupsNum; a++) {
  
        if (peopleInGroup <= 5) {
            group1 += peopleInGroup
           
        }
        else if (peopleInGroup > 5 && peopleInGroup <= 12) {
            group2 += peopleInGroup;
            
        }
        else if (peopleInGroup >= 13 && peopleInGroup <= 25) {
            group3 += peopleInGroup;
        }
        else if (peopleInGroup >= 26 && peopleInGroup <= 40) {
            group4 += peopleInGroup;
          
        }
        else if (peopleInGroup >= 41) {
            group5 += peopleInGroup;    
        }

        peopleInGroup = Number(input[index]);
        index++;

    }
    procent1 = group1 / total * 100;
    procent2 = group2 / total * 100;
    procent3 = group3 / total * 100;
    procent4 = group4 / total * 100;
    procent5 = group5 / total * 100;

    console.log(procent1.toFixed(2) + '%');
    console.log(procent2.toFixed(2) + '%');
    console.log(procent3.toFixed(2) + '%');
    console.log(procent4.toFixed(2) + '%');
    console.log(procent5.toFixed(2) + '%');

}
trekkingMania(["10",
"10",
"5",
"1",
"100",
"12",
"26",
"17",
"37",
"40",
"78"])

