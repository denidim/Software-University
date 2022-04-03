function arrRotation(arr, n) {
    let rotation = n;
    let array = arr;

    for (let i = 0; i < rotation; i++) {
        let numToMove = array.shift();
        array.push(numToMove);
    }
    console.log(array.join(' '));
}

arrRotation([51, 47, 32, 61, 21], 2);
arrRotation([32, 21, 61, 1], 4);
arrRotation([2, 4, 15, 31], 5);