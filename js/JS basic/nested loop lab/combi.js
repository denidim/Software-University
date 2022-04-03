function comnbinations(input) {

    let target = Number(input[0]);
    let combCounter = 0;

    for (let i = 0; i <= target; i++) {

        for (let j = 0; j <= target; j++) {

            for (let q = 0; q <= target; q++) {

                if(i + j + q === target){
                    combCounter++;
                }

            }
        }
    }
    console.log(combCounter);

}
comnbinations(['5']);