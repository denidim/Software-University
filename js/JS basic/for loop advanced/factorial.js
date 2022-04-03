function factorial(input){

    let n = Number(input[0]);
    result = 1;

    for(let i = 1; i <= n; i ++){
        result = result * i;  
        }
        console.log(result)
    }
    
factorial(['8']);
