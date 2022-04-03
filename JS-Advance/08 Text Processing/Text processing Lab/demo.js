function demo(text, word) {
    let tokens = text.split(word);
 
  console.log(tokens.join('*'.repeat(word.length)));
}
demo('A small sentence with some words', 'small')