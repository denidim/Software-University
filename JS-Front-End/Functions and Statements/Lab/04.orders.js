function oredrs(product, quantity) {
    let result = 0;
    if(product == 'water'){
        result = quantity * 1.00;
    }else if(product == 'coffee'){
        result = quantity * 1.50;
    }else if(product == 'coke'){
        result = quantity * 1.40;
    }else if(product == 'snacks'){
        result = quantity * 2.00;
    }

    console.log(result.toFixed(2));
}

oredrs('water', 5);
oredrs('coffee', 2);