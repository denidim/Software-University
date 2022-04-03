function palindromeIntegers(numbers) {

    for (let number of numbers){
        let numberAsString = number.toString();
        let reverseNumberAsString = numberAsString.split('').reverse().join('');
       
        if(numberAsString === reverseNumberAsString){
            console.log(true);
        } else{
            console.log(false); 
        }
    }
}
palindromeIntegers([123,323,421,121]);
palindromeIntegers([32,2,232,1010]); 
