function accountBalance(input) {
    
    let moneyIn = input[0];
    let index = 1;
    let total = 0;

   

    while (moneyIn !== 'NoMoreMoney') {
        let amount =Number(moneyIn);

        if(amount < 0){
            console.log('Invalid operation!');
            break;
        }
        
        total+=amount;

        console.log(`Increase: ${amount.toFixed(2)}`);

        moneyIn= input[index];
        index++;
       
    
    }
   
    console.log(`Total: ${total.toFixed(2)}`);
}
accountBalance(["120",
"45.55",
"-150"])

