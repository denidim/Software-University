function solve(num){
    let sum = 0;
    let str = num.toString().split("");

    for (let i = 0; i < str.length; i++) {
        sum += Number(str[i]);
    }

    console.log(sum);
}

solve(245678)