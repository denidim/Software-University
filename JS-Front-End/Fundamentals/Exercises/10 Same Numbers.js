function solve(num) {
    let arr = num.toString().split("");
    let sum = Number(arr[0]);
    let areEqual = true;

    for (let i = 1; i < arr.length; i++) {
        if (arr[0] != arr[i]) {
            areEqual = false;
        }
        sum += Number(arr[i]);
    }

    if (areEqual) {
        console.log(true)
    }
    else {
        console.log(false);
    }

    console.log(sum);
}

solve(2222222);
solve(1234);