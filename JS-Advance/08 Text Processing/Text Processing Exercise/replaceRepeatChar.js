function solve(input) {

    let result ='';

    for(let ch of input){
        if(ch !== result[result.length -1]){
            result+= ch;
        }
    }
    console.log(result);
}
solve('aaaaabbbbbcdddeeeedssaa');
solve('qqqwerqwecccwd');