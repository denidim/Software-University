function birthdayParty(input) {

    let rent = parseInt(input[0]);

    let cake = rent * 0.20;
    let drinks = cake - cake * 0.45;
    let animator = rent / 3;
    let budget = rent + cake + drinks + animator;

    console.log(budget);

}

birthdayParty(['2250']);

