function footbool(input) {

    let tshurtPrice = Number(input[0]);
    let totalSum = Number(input[1]);

    let shorts = tshurtPrice * 0.75;
    let socks = shorts * 0.20;
    let trainers = (tshurtPrice + shorts) * 2;
    let total = tshurtPrice + shorts + socks + trainers;
    let discount = total * 0.85;

    if(discount >= totalSum){

        console.log("Yes, he will earn the world-cup replica ball!");
        console.log(`His sum is ${discount.toFixed(2)} lv.`);

    }
    else{

        console.log("No, he will not earn the world-cup replica ball.");
        console.log(`He needs ${(totalSum - discount).toFixed(2)} lv. more.`);
    }

    
}
footbool(["55",
"310"])
