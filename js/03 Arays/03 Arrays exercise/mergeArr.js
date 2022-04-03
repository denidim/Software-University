function mergeArr(arr1, arr2) {
    let firstArr = arr1;
    let secondArr = arr2;
    let firstArrLength = firstArr.length;
    let newArr = [];
   
    for (let i = 0; i < firstArrLength; i++) {
        let firstArrEl = firstArr[i];
        let secondArrEl = secondArr[i];
        if (i % 2 === 0) {
           let sum = Number(firstArrEl) + Number(secondArrEl);
            newArr.push(sum);
        } else{
            let concate = firstArrEl + secondArrEl;
            newArr.push(concate);
        }
    }
console.log(newArr.join(' - '));
}
mergeArr(['5', '15', '23', '56', '35'],
    ['17', '22', '87', '36', '11']);

mergeArr(['13', '12312', '5', '77', '4'],
    ['22', '333', '5', '122', '44']);