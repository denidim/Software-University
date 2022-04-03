function clock(input){
    
    
    for(let i = 0; i <=23; i++){

        for(let j = 0;j <= 59; j++ ){

            for(let s = 0; s <= 59;s++){

                console.log(`${i} : ${j} : ${s}`);
            }
        }
    }
}
clock()