function solve(input) {
    let cards = input.shift().split(', ');
    let n = Number(input.shift());
    
    for(let i = 0; i < n; i++){
        let [command, ... items] = input.shift().split(', ');

        if(command === 'Add'){
            let cardName = items[0];
            if(!cards.includes(cardName)){
                cards.push(cardName);
                console.log("Card successfully added");
            } else{
                console.log("Card is already in the deck");
            }
        } else if( command === 'Remove'){
            let cardName = items[0];

            if(cards.includes(cardName)){
                let index = cards.indexOf(cardName);
                cards.splice(index, 1);
                console.log("Card successfully removed");
            } else{
                console.log("Card not found");
            }
        } else if( command === 'Remove At'){
            let index = Number(items[0]);
            if(index >= 0 && index < cards.length){
                cards.splice(index, 1);
                console.log("Card successfully removed");
            }else{
                console.log("Index out of range");
            }
        } else if(command === 'Insert'){
            let index = Number(items[0]);
            let cardName = items[1];
            if (index >= 0 && index < cards.length){
                if(!cards.includes(cardName)){
                    cards.splice(index, 0, cardName);
                    console.log("Card successfully added");
                } else{
                    console.log("Card is already added");
                }
            }else{
                console.log("Index out of range");
            }
        }
       
    }
    console.log(cards.join(', '));
}

solve(["Ace of Diamonds, Queen of Hearts, King of Clubs",
"3",
"Add, King of Diamonds",
"Insert, 2, Jack of Spades",
"Remove, Ace of Diamonds"]);


solve(["Two of Clubs, King of Spades, Five of Spades, Jack of Hearts",
"2",
"Add, Two of Clubs",
"Remove, Five of Hearts"]);

solve(["Jack of Spades, Ace of Clubs, Jack of Clubs",
"2",
"Insert, -1, Queen of Spades",
"Remove At, 1"]);