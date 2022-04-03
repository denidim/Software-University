function building(input) {

    let flors = Number(input[0]);
    let rooms = Number(input[1]);
   

    for (let i = flors; i > 0; i++){

        for (let j = 0; j < rooms; j++) {

            if(i === flors){

                console.log(`L${i}${j}`);

            }else if (i % 2 === 0) {


                console.log(`O${i}${j}`);

            } else {

                console.log(`A${i}${j}`);
            }
        }

    }

}
building(["6", "4"]);