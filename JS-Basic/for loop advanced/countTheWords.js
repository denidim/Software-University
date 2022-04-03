function countTheWords(input){

    let message = input[0];
    let couner = 1;
    
    for( let i = 0; i <= message.length; i++ ){
        if(message[i] === ' '){
            couner ++;
        }
    }
    if(couner > 10){

    console.log(`The message is too long to be send! Has ${couner} words.`);
    }
    else{
        console.log('The message was sent successfully!');
    }
}
countTheWords(["This message has exactly eleven words. One more as it's allowed!"]);