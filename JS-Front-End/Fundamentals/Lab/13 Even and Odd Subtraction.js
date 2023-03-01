function solve(array) {
    let sumEven = 0;
    let sumOdd = 0;

    array.forEach(element => {
        if (element % 2 === 0) {
            sumEven += element;
        }else{
            sumOdd += element;
        }
    });

    console.log(sumEven-sumOdd);
}

solve([1,2,3,4,5,6])
solve([3,5,7,9])