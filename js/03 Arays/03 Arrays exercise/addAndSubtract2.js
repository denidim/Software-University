function solve(arr) {
    
    let newArr = [];
    let arrSum = 0;
    let newArrSum = 0;

    for(let i = 0; i < arr.length; i++){

        if(arr[i] % 2 === 0){
            newArr.push(arr[i] + i);
        } else{
            newArr.push(arr[i] - i);
        }
        arrSum += arr[i];
    }
    for(let i = 0; i < newArr.length; i++){
        newArrSum += newArr[i];
    }
  
    console.log(newArr);
    console.log(arrSum);
    console.log(newArrSum);
}
solve([5, 15, 23, 56, 35]);
solve([-5, 11, 3, 0, 2]);