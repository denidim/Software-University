function condense(arr) {
    
    while (arr.length > 1) {
        let condesed = [];
        for (let i = 0; i < arr.length - 1; i++) {
            let sum = arr[i] + arr[i + 1];
            condesed.push(sum);
        }
        arr = condesed;
    }
    console.log(arr[0]);
}

condense([2, 10, 3]);
condense([5, 0, 4, 1, 2]);
condense([1]);