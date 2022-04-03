function solve(input) {
    let n = Number(input.shift());
 
    let oddSum = 0;
    let oddMin = Number.MAX_SAFE_INTEGER;
    let oddMax = Number.MIN_SAFE_INTEGER;
    let evenSum = 0;
    let evenMin = Number.MAX_SAFE_INTEGER;
    let evenMax = Number.MIN_SAFE_INTEGER;
 
    for (let i = 1; i <= n; i++){
 
        let number = Number(input.shift());
 
        if (i % 2 !== 0){
            oddSum += number;
            if (oddMin > number) {
                
                oddMin = number;
            }   
            if (oddMax < number) { 
                
                oddMax = number;
            }
        }
        else{
            evenSum += number;
            if (evenMin > number) {   
                
                evenMin = number;
            }   
            if (evenMax < number) {  
                
                evenMax = number;
            }
        }
    }

    if (oddSum === 0) {
        
        let zero = 0;
        console.log(`OddSum=${zero.toFixed(2)},`);
        console.log("OddMin=No,");
        console.log("OddMax=No,");
    }
    else {
        
        console.log(`OddSum=${oddSum.toFixed(2)},`);
        console.log(`OddMin=${oddMin.toFixed(2)},`);
        console.log(`OddMax=${oddMax.toFixed(2)},`);
    }
    if (evenSum === 0) {
        
        let zero = 0;
        console.log(`EvenSum=${zero.toFixed(2)},`);
        console.log("EvenMin=No,");
        console.log("EvenMax=No");
    }                      
    else {    
        
       console.log(`EvenSum=${evenSum.toFixed(2)},`);
       console.log(`EvenMin=${evenMin.toFixed(2)},`);
       console.log(`EvenMax=${evenMax.toFixed(2)}`);
    }
}
solve(['6', '2', '3', '5', '4', '2', '1']);