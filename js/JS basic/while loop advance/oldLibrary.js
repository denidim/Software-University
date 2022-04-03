function oldBooks(input) {
    let index = 0;
    let book = input[index];
    index++;

    let command = input[index];
    index++;

    let counter = 0;
    let isFound = false;

    while (command !== 'No More Books') {
        let currentBook = command;

        if (currentBook === book) {
            isFound = true;
           console.log(`You checked ${counter} books and found it.`);
            break;
        }
        counter++;

        command = input[index];
        index++;
    } 

    if(!isFound){ 
        console.log("The book you search is not here!");
        console.log(`You checked ${counter} books.`);
    }

}
oldBooks(["The Spot",
"Hunger Games",
"Harry Potter",
"Torronto",
"Spotify",
"No More Books"])






