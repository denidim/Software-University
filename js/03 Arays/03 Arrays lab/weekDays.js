function weekDays(num) {
    let days = [
        'Monday',
        'Tuesday',
        'Wednesday',
        'Thursday',
        'Friday',
        'Saturday',
        'Sunday'
    ];
    if (num < 1 || num > 7) {
        console.log('Invalid day!');
    } else {
        let index = num - 1;
            console.log(days[index]);
    }
}
weekDays(3);
weekDays(6);
weekDays(11);