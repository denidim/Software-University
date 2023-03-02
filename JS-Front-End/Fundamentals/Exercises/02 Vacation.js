function solve(people, type, day) {
    let price;
    let total;

    if (type === 'Students') {
        if (day === 'Friday') {
            price = 8.45;
        } else if (day === 'Saturday') {
            price = 9.80;
        } else if (day === 'Sunday') {
            price = 10.46;
        }
        total = people * price;
        if (people >= 30) {
            total -= total * 0.15;
        }
    } else if (type === 'Business') {
        if (day === 'Friday') {
            price = 10.90;
        } else if (day === 'Saturday') {
            price = 15.60;
        } else if (day === 'Sunday') {
            price = 16;
        }
        total = people * price;
        if (people >= 100) {
            total -= 10 * price;
        }
    } else if (type === 'Regular') {
        if (day === 'Friday') {
            price = 15;
        } else if (day === 'Saturday') {
            price = 20;
        } else if (day === 'Sunday') {
            price = 22.50;
        }
        total = people * price;
        if (people >= 10 && people <= 20) {
            total -= 0.95 * total;
        }
    }

    console.log(`Total price: ${total.toFixed(2)}`)
}

solve(30, "Students", "Sunday")
solve(40, "Regular", "Saturday")