function footboolLeague(input) {

    let capacity = Number(input[0]);
    let fens = Number(input[1]);
    let index = 2;
    let sector = input[index];
    index++;
    let a = 0;
    let b = 0;
    let v = 0;
    let g = 0;

    for (let i = 1; i <= fens; i++) {

        if (sector === 'A') {
            a ++;
        }
        else if(sector === 'B'){
            b++;
        }
        else if(sector === 'V'){
            v ++;
        }
        else if(sector === 'G'){
            g ++;
        }
        sector = input[index];
        index++;
    }
    let procentA = a / fens * 100;
    let procentB = b / fens * 100;
    let procentV = v / fens * 100;
    let procentG = g / fens * 100;
    let avg = fens / capacity * 100;
    
    console.log(procentA.toFixed(2) +'%');
    console.log(procentB.toFixed(2) +'%');
    console.log(procentV.toFixed(2) +'%');
    console.log(procentG.toFixed(2) +'%');
    console.log(avg.toFixed(2) + '%');

}
footboolLeague(['76','10', 'A', 'V', 'V', 'V', 'G',
 'B', 'A', 'V', 'B', 'B']); 
   