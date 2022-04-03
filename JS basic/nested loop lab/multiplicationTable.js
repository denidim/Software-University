function multiplication(input) {

    let num = Number(input[0]);
    let n1 = num % 10;
    let n2 = Math.trunc(num / 10 % 10);
    let n3 = Math.trunc(num /100);


    for (let i = 1; i <= n1; i++) {

        for (let y = 1; y <= n2; y++) {

            for (let z = 1; z <= n3; z++) {
                
                let result = i * y * z;

                console.log(`${i} * ${y} * ${z} = ${result}`);
            }
        }
    }
}
multiplication(324);