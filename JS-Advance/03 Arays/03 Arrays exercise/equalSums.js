function equalSum(list) {

    let hasFoundResult = false;

    for (let i = 0; i < list.length; i++) {
        let rightSum = 0;
        let leftSum = 0;

        for (let leftIndex = 0; leftIndex < i; leftIndex++) {
            let currentNum = list[leftIndex];
            leftSum += currentNum;
        }
        for (let rigthIndex = i + 1; rigthIndex < list.length; rigthIndex++) {
            let currentNum = list[rigthIndex];
            rightSum += currentNum;
        }
        if(leftSum === rightSum){
            console.log(i);
            hasFoundResult = true;
            break;
        } 
    }
    if(!hasFoundResult){
        console.log('no');
    }
}
equalSum([1, 2, 3, 3]);
equalSum([10, 5, 5, 99, 3, 4, 2, 5, 1, 1, 4]);
