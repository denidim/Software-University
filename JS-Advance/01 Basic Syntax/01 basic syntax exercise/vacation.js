function vacation(group, type, day) {
    let price = 0;

    if (type === 'Business' && group >= 100) {
        group -= 10;
    }
    if (type === 'Students') {
        switch (day) {
            case 'Friday': price = group * 8.45;
                break;
            case 'Saturday': price = group * 9.80;
                break;
            case 'Sunday': price = group * 10.46;
                break;
        } 
    } else if (type === 'Business') {
        switch (day) {
            case 'Friday': price = group * 10.90;
                break;
            case 'Saturday': price = group * 15.60;
                break;
            case 'Sunday': price = group * 16;
                break;
        }    
    } else if (type === 'Regular') {
        switch (day) {
            case 'Friday': price = group * 15;
                break;
            case 'Saturday': price = group * 20;
                break;
            case 'Sunday': price = group * 22.50;
                break;
        }    
    }
    if (type === 'Students' && group >= 30) {
        price = price * 0.85;
    }else if (type === 'Regular' && group >= 10 && group <= 20) {
        price = price * 0.95;
    }
    console.log(`Total price: ${price.toFixed(2)}`);
}
vacation(30, "Students", "Sunday");
vacation(40, "Regular", "Saturday");
vacation(100, "Business", "Saturday");