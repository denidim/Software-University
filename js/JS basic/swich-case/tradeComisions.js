function tradeComisions(input) {
    let town = input[0];
    let sales = Number(input[1]);
    let comision = 0;
    switch (town) {
        case 'Sofia':
            if (sales >= 0 && sales <= 500) {
                comision = sales * 0.05;
            }
            if (sales > 500 && sales <= 1000) {
                comision = sales * 0.07;
            }
            if (sales > 1000 && sales <= 10000) {
                comision = sales * 0.08;
            }
            if (sales > 10000) {
                comision = sales * 0.12;
            }
            if (sales < 0) {
                console.log('error')
            }
            else {
                console.log(comision.toFixed(2));
            }
            break;
        case 'Varna':
            if (sales >= 0 && sales <= 500) {
                comision = sales * 0.045;
            }
            if (sales > 500 && sales <= 1000) {
                comision = sales * 0.075;
            }
            if (sales > 1000 && sales <= 10000) {
                comision = sales * 0.10;
            }
            if (sales > 10000) {
                comision = sales * 0.13;
            }
            if (sales < 0) {
                console.log('error')
            }
            else {
                console.log(comision.toFixed(2));
            }
            break;
        case 'Plovdiv':
            if (sales >= 0 && sales <= 500) {
                comision = sales * 0.055;
            }
            if (sales > 500 && sales <= 1000) {
                comision = sales * 0.08;
            }
            if (sales > 1000 && sales <= 10000) {
                comision = sales * 0.12;
            }
            if (sales > 10000) {
                comision = sales * 0.145;
            }
            if (sales < 0) {
                console.log('error')
            }
            else {
                console.log(comision.toFixed(2));
            }
            break;
        default: console.log('error');break;
    }
}
tradeComisions(['Plovdiv' , '-20'])