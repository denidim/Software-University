function arrayRotation(array, n) {

    for (let i = 0; i < n; i++) {
        let firstEl = array[0];

        for (let j = 0; j < array.length - 1; j++) {
            array[j] = array[j + 1];
        }
        let lastIndex = array.length - 1;
        array[lastIndex] = firstEl;
    }
   
console.log(array.join(' '));
}
arrayRotation([51, 47, 32, 61, 21], 2);
arrayRotation([32, 21, 61, 1], 4);
arrayRotation([2, 4, 15, 31], 5);

