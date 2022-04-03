function minNumber(input){

    let index = 0;
    let n = Number(input[index]);
    index++;
    let min = Number.MAX_SAFE_INTEGER;

    for( let i = 0; i < n; i ++){
        let num = Number(input[index]);
        index++;

        if(min > num){
            min = num;
        }

    }
    console.log(min);
}
minNumber(["3",
"-10",
"20",
"-30"])


