function guesPassword(input) {
    
    let userName = input[0];
    let password = input[1];
    let data = input[2];
    let i = 3;


    while (true) {
        
        if (data===password){
            break;
        }


        data = input[i];
        i++;
    }
    console.log(`Welcome ${userName}!`);
}
guesPassword(["Nakov",
"1234",
"Pass",
"1324",
"1234"])




