function solve(str) {

    let firstPart = str
    .substring(0, str.length / 2)
    .split('')
    .reverse()
    .join('');

    let secondPart = str
    .substring(str.length / 2)
    .split('')
    .reverse()
    .join('');

    console.log(firstPart);
    console.log(secondPart);
}
solve('tluciffiDsIsihTgnizamAoSsIsihT');
solve('sihToDtnaCuoYteBIboJsihTtAdooGoSmI');