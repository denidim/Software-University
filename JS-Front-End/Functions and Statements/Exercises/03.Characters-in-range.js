function charsInRange(a, b){
    let firstNum = a.charCodeAt();
    let seconfNum = b.charCodeAt();
    let result = [];

    for (let i = Math.min(firstNum,seconfNum) + 1; i < Math.max(firstNum,seconfNum); i++) {
        result.push(String.fromCharCode(i));
    }

    return result.join(' ');
}

console.log(charsInRange('C','#'))