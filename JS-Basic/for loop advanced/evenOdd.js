function evenOdd(input) {

    let n = Number(input.shift());
   
    let oddSum = 0;
    let oddMax = Number.MIN_SAFE_INTEGER;
    let oddMin = Number.MAX_SAFE_INTEGER;
    let evenSum = 0;
    let evenMax = Number.MIN_SAFE_INTEGER;
    let evenMin = Number.MAX_SAFE_INTEGER; 

    for (let i = 1; i <= n; i++) {
        let num = Number(input.shift());

      
        if (i % 2 !== 0) {
            oddSum += num;
            if(num < oddMin){
            oddMin = num;
            }
            if(num > oddMax) {
                oddMax = num;

            }
             else {
                evenSum += num;

                if (i % 2 === 0) {
                    evenSum += num;
                    if(num < evenMin){
                    evenMin = num;
                    }
                    if(num > evenMax) {
                        evenMax = num;
                    }
                }
            }
        }
        num=input[index];
        index++
    }
    console.log(`OddSum=${oddSum.toFixed(2)}`);
    console.log(`OddMin=${oddMin.toFixed(2)}`);
    console.log(`OddMax=${oddMax.toFixed(2)}`);
    console.log(`EvenSum=${evenSum.toFixed(2)}`);
    console.log(`EvenMin=${evenMin.toFixed(2)}`);
    console.log(`EvenMax=${evenMax.toFixed(2)}`);
}
evenOdd('6', '2', '3', '5', '4', '2', '1');

