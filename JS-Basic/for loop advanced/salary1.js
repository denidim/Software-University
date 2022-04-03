function salaryCount(input) {
    let openTabs = Number(input[0]);
    let salary = Number(input[1]);
    let index = 2;
    let currentTab = input[index];
    index++;

    for (let i = 0; i <= openTabs; i++) {

        if(currentTab === 'Facebook'){
            salary -= 150;
        } else if(currentTab === 'Instagram'){
            salary -= 100;
        } else if(currentTab === 'Reddit'){
            salary -= 50;
        }
        currentTab = input[index];
        index++;
    }
    if (salary <= 0){
        console.log("You have lost your salary." );
        
    }else {
        console.log(salary);
    }

}
salaryCount(["3",
"500",
"Github.com",
"Stackoverflow.com",
"softuni.bg"])

