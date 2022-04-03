function fruitShop(input) {

    let fruit = input[0];
    let day = input[1];
    let quantity = Number(input[2]);

    let sum = 0;

    if (day === 'Monday' || day === 'Tuesday' || day === 'Wednesday'
        || day === 'Thursday' || day === 'Friday') {

        switch (fruit) {
            case 'banana': sum = quantity * 2.50; console.log(sum.toFixed(2)); break;
            case 'apple': sum = quantity * 1.20; console.log(sum.toFixed(2)); break;
            case 'orange': sum = quantity * 0.85; console.log(sum.toFixed(2)); break;
            case 'grapefruit': sum = quantity * 1.45; console.log(sum.toFixed(2)); break;
            case 'kiwi': sum = quantity * 2.70; console.log(sum.toFixed(2)); break;
            case 'pineapple': sum = quantity * 5.50; console.log(sum.toFixed(2)); break;
            case 'grapes': sum = quantity * 3.85; console.log(sum.toFixed(2)); break;
            default: console.log('error'); break;
        }
    }
    else if (day === 'Saturday' || day === 'Sunday') {
        switch (fruit) {
            case 'banana': sum = quantity * 2.70; console.log(sum.toFixed(2)); break;
            case 'apple': sum = quantity * 1.25; console.log(sum.toFixed(2)); break;
            case 'orange': sum = quantity * 0.90; console.log(sum.toFixed(2)); break;
            case 'grapefruit': sum = quantity * 1.60; console.log(sum.toFixed(2)); break;
            case 'kiwi': sum = quantity * 3.00; console.log(sum.toFixed(2)); break;
            case 'pineapple': sum = quantity * 5.60; console.log(sum.toFixed(2)); break;
            case 'grapes': sum = quantity * 4.20; console.log(sum.toFixed(2)); break;

            default: console.log('error'); break;
        }



    } else {
        console.log('error');
    }
}
fruitShop(["apple",
    "Workday",
    "2"])



