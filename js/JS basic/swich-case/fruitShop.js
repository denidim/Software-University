function fruitShop(input) {
    let fruit = input[0];
    let day = input[1];
    let quantity = Number(input[2]);
    let result = 0;
    if (day === 'Monday' || day === 'Tuesday' || day === 'Wednesday' || day === 'Thursday' || day === 'Friday') {
        switch (fruit) {
            case 'banana':
                result = quantity * 2.50; console.log(result.toFixed(2));
                break;
            case 'apple':
                result = quantity * 1.20; console.log(result.toFixed(2));
                break;
            case 'orange':
                result = quantity * 0.85; console.log(result.toFixed(2));
                break;
            case 'grapefruit':
                result = quantity * 1.45; console.log(result.toFixed(2));
                break;
            case 'kiwi':
                result = quantity * 2.70; console.log(result.toFixed(2));
                break;
            case 'pineapple':
                result = quantity * 5.50; console.log(result.toFixed(2));
                break;
            case 'grapes':
                result = quantity * 3.85; console.log(result.toFixed(2));
                break;
            default: console.log('error');
                break;
        }
    } else if (day === 'Saturday' || day === 'Sunday') {
        switch (fruit) {
            case 'banana':
                result = quantity * 2.70; console.log(result.toFixed(2));
                break;
            case 'apple':
                result = quantity * 1.25; console.log(result.toFixed(2));
                break;
            case 'orange':
                result = quantity * 0.90; console.log(result.toFixed(2));
                break;
            case 'grapefruit':
                result = quantity * 1.60; console.log(result.toFixed(2));
                break;
            case 'kiwi':
                result = quantity * 3.00; console.log(result.toFixed(2));
                break;
            case 'pineapple':
                result = quantity * 5.60; console.log(result.toFixed(2));
                break;
            case 'grapes':
                result = quantity * 4.20; console.log(result.toFixed(2));
                break;
            default: console.log('error');
                break;
        }
    }else {
        console.log('error');
    }
}
fruitShop(['tomato' , 'Monday' , '0.5']);

