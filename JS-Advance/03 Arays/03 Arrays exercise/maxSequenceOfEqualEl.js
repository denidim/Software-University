function maxSequence(arr) {
    
    let longestSequence = [];
    let leftMostIndex = 0;

    for (let i = 0; i < arr.length; i++) {

        let currentEl = Number(arr[i]);
        let currentSequence = [currentEl];

        for (let j = i + 1; j < arr.length; j++) {
            let nextEl = Number(arr[j]);

            if (nextEl === currentEl) {
                currentSequence.push(nextEl);
            } else  {
               break;
            }
        }
        if(currentSequence.length > longestSequence.length){
            longestSequence =[];

            for (let j = 0; j < currentSequence.length; j++){
                longestSequence.push(currentSequence[j]);
            }
        } else if(currentSequence.length === longestSequence.length){
            if(i < leftMostIndex){
                leftMostIndex = i;
            }
        }
    }
    console.log(longestSequence.join(' '));

//     let longestSequence = [];


//     for (let i = 0; i < arr.length; i++) {

//         let currentEl = arr[i];
//         let currentSequence = [currentEl];

//         for (let j = i + 1; j < arr.length; j++) {
//             let nextEl = arr[j];

//             if (nextEl === currentEl) {
//                 currentSequence.push(nextEl);
//             } else {
//                 break;
//             }
//         }
//         if (currentSequence.length > longestSequence.length) {
//             longestSequence = currentSequence;
//         }
//     }
// console.log(longestSequence.join(' '));
// }
}
maxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
maxSequence([1, 1, 1, 2, 3, 1, 3, 3]);
maxSequence([4, 4, 4, 4]);
maxSequence([0, 1, 1, 5, 2, 2, 6, 3, 3]);