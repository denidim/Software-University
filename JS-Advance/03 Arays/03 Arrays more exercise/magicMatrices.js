function magicMatrix(arr) {
    let firstArr = arr.shift();
    let secondArr = arr.shift();
    let thirdArr = arr.shift();
    let sumFirstArr = 0;
    let sumSecondArr = 0;
    let sumThirdArr = 0;
    let sumCol = 0;

    for (let i = 0; i < firstArr.length; i++) {
        sumFirstArr += firstArr[i];
        sumSecondArr += secondArr[i];
        sumThirdArr += thirdArr[i];

        for (let i = 0; i < firstArr.length; i++) {
            sumCol = firstArr[i] + secondArr[i] + thirdArr[i];

        }
    
    }
    if(sumFirstArr === sumCol || sumSecondArr === sumCol || sumThirdArr === sumCol){
        console.log('true');
    } else{
        console.log('false');
    }
}
magicMatrix([[4, 5, 6], [6, 5, 4], [5, 5, 5]]);

magicMatrix([[11, 32, 45], [21, 0, 1], [21, 1, 1]]);

magicMatrix([[1, 0, 0], [0, 0, 1], [0, 1, 0]]);



let sumRow = row => matrix[row].reduce((a, b) => a + b);
    let sumCol = col => matrix.map(row => row[col])
        .reduce((a, b) => a + b);


     