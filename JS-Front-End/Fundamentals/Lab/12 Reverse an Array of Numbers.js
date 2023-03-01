function solve(n,array){
    let newArr = array.slice(0,n).reverse();
    console.log(...newArr);
}


solve(3,[10, 20, 30, 40, 50]);