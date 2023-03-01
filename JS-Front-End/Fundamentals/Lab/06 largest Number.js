function solve(num1, num2, num3) {

    let max = Number.MIN_SAFE_INTEGER;
    let nums = [num1, num2, num3]
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] > max) {
            max = nums[i];
        }
    }
    console.log(`The largest number is ${max}.`);
}

solve(5, -3, 16);
