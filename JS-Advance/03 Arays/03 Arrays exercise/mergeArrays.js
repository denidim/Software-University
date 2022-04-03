function mergeArrays(firstArr, secondArr) {
    let newArray = [];

    for(let i = 0; i < firstArr.length; i ++){
        let firstArrEl = firstArr[i];
        let secondArrEl = secondArr[i];

        if(i % 2 === 0){
            let sum = Number(firstArrEl) + Number(secondArrEl);
          newArray.push(sum); 
        } else{
            let result = firstArrEl + secondArrEl;
            newArray.push(result);
        }
    }
    console.log(newArray.join(' - '));
}
mergeArrays(['5', '15', '23', '56', '35'],
['17', '22', '87', '36', '11']);

mergeArrays(['13', '12312', '5', '77', '4'],
['22', '333', '5', '122', '44']);