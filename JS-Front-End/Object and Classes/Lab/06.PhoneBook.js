function PrintPhoneBook(arr) {
    let phoneBook = {};

    for (const key of arr) {
        let [name, number] = key.split(' ');

        phoneBook[name] = number;
    }

    for (const key in phoneBook) {
        console.log(`${key} -> ${phoneBook[key]}`)
    }
}

PrintPhoneBook(['Tim 0834212554', 'Peter 0877547887', 'Bill 0896543112', 'Tim 0876566344']);