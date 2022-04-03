function login(list) {

    let username = list.shift();
    let passwordAsList = username.split('');
    let passwordAsListReversed = passwordAsList.reverse();
    let password = passwordAsListReversed.join('');
    let counter = 1;

    while (true) {
        let currentPassword = list.shift();
        if (counter === 4) {
            console.log(`User ${username} blocked!`);
            break;
        }
        if (currentPassword === password) {
            console.log(`User ${username} logged in.`);
            break;
        } else {
            console.log("Incorrect password. Try again.");
        }
        counter++;
    }
}
//login(['Acer','login','go','let me in','recA']);
//login(['momo', 'omom']);
 login(['sunny', 'rainy', 'cloudy', 'sunny', 'not sunny']);