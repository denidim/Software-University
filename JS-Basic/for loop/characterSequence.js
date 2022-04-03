function characterSequence(input) {

    let text = input[0];
    let textL = text.length;

    for (index = 0; index < textL; index++) {
        console.log(text[index]);
    }
}

characterSequence(["ice cream"]);