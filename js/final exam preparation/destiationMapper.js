function destinationMapper(input) {

    let text = input;
    let destinations = [];
    let result = 0;

    //let pattern = /([= | \/])([A-Z][a-zA-z]{3,})\1/g;
    let pattern2 = /(=|\/)(?<destinations>[A-Z]{1}[A-Za-z]{2,})(\1)/g;
    let match = pattern2.exec(text);

    while (match != null) {
        let destination = match[2];
        result += destination.length;

        destinations.push(destination);
        match = pattern2.exec(text);
    }
    console.log(`Destinations: ${destinations.join(', ')}`);
    console.log(`Travel Points: ${result}`);

}
destinationMapper("=Hawai=/Cyprus/=Invalid/invalid==i5valid=/I5valid/=i=");

console.log('===');
destinationMapper("ThisIs some InvalidInput");

