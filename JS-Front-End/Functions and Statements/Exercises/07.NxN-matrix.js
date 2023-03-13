// function matrix(num){
//     for (let i = 0; i < num; i++) {
//         console.log([...num.toString().repeat(num)].join(' '))
//     }
// }

function matrix(num) {
    new Array(num).fill(new Array(num).fill(num)).forEach(row => console.log(row.join(' ')));
}


matrix(3)