function maxNumber(nums) {
    let topInt = [];
    for (let i = 0; i < nums.length; i++) {
        let currentNum = nums[i];
        let isTop = true;

        for (let j = i + 1; j < nums.length; j++) {
            let nextNum = nums[j];

            if (nextNum >= currentNum) {
                isTop = false;
                break;
            }
        }
        if (isTop) {
            topInt.push(currentNum);
        }
    }
    console.log(topInt.join(' '));

}
maxNumber([1, 4, 3, 2]);
maxNumber([14, 24, 3, 19, 15, 17]);
maxNumber([41, 41, 34, 20]);
maxNumber([27, 19, 42, 2, 13, 45, 48]);