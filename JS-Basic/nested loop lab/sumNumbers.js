function sumNum(input) {

    let startNum = Number(input[0]);
    let endNum = Number(input[1]);
    let magicNum = Number(input[2]);
    let combCounter = 0;

    for (let i = startNum; i <= endNum; i++) {

        for (let j = startNum; j <= endNum; j++) {
            combCounter++;

            if (i + j === magicNum) {

                console.log(`Combination N:${combCounter} (${i} + ${j} = ${magicNum})`);
                return;
            }

        }
    }
    console.log(`${combCounter} combinations - neither equals ${magicNum}`);
}
sumNum(["23", "24", "20"]);
