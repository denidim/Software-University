function printNthEl(arr) {
    let n = arr.pop();
    let arrayOfElement =arr;
    let collections = [];
   
    for (let i = 0; i <= arrayOfElement.length; i++) {
        let currentEl = arrayOfElement[i];
        if (i % n === 0){
            collections.push(currentEl);
        }  
    }
    console.log(collections.join(' '));
}


/*function printNthEl(arr) {
    let lastNum = arr.pop();
    let resultArr = [];
    for (let index in arr) {
        if (index % lastNum === 0) {
            resultArr.push(arr[index]);
        }
    }
    console.log(resultArr.join(' '));
}
*/
printNthEl(['5', '20', '31', '4', '20', '2']);
printNthEl(['dsa', 'asd', 'test', 'test', '2']);
printNthEl(['1', '2', '3', '4', '5', '6']);