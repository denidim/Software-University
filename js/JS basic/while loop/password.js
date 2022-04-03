function guessPassword(input){

    let index = 0;
    let userName = input[index];
    index++;
    let password = input[index];
    index++;
    let data = input[index];
    index++;

    while(data !== password){
        data = input[index];
        index++;
    }
    console.log(`Welcome ${userName}!`);
}

guessPassword(["Gosho",
"secret",
"secret"])


