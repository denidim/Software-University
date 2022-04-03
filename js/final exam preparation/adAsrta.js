function adAstra(input) {
    let text = input[0];

    let pattern = /([\|]|[#])(?<itemName>[A-Za-z\s]+)\1(?<expDate>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1/g;

    let match = null;
    let totalCalories = 0;
    let provisions = [];

    while (match = pattern.exec(text)) {

        let item = match.groups['itemName'];
        let expDate = match.groups['expDate'];
        let calories = Number(match.groups['calories']);

        totalCalories += calories;
    
        provisions.push(`Item: ${item}, Best before: ${expDate}, Nutrition: ${calories}`);
    }
    const calPerDay = 2000;
    let days = Math.floor(totalCalories / calPerDay);

    console.log(`You have food to last you for: ${days} days!`);
   console.log(provisions.join('\n'));
}
adAstra([
    '#Bread#19/03/21#4000#|Invalid|03/03.20||Apples|08/10/20|200||Carrots|06/08/20|500||Not right|6.8.20|5|'
]);
console.log('---');
adAstra(['$$#@@%^&#Fish#24/12/20#8500#|#Incorrect#19.03.20#450|$5*(@!#Ice Cream#03/10/21#9000#^#@aswe|Milk|05/09/20|2000|'
]);

console.log('---');

adAstra(['Hello|#Invalid food#19/03/20#450|$5*(@' ]);