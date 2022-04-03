function demo(arr) {
    let insert = ['a', 'b', 'c', 'd'];
    let left = arr.slice(0, 3); // start, end;
    let removed = arr.slice(3, 5); //start, start + count;
    let right = arr.slice(5) // start + count....to arr end

    for (let element of insert) {
        left.push(element);
    }
    for(let element of right){
        left.push(element);
    }
    console.log(left);
}
demo([5, 8, -3, 11, 44, 13, -8]);