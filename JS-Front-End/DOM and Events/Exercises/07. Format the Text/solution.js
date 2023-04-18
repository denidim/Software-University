function solve() {
  let text = document.getElementById('input');
  let array = text.value.trim().split('.');
  array.pop();

  let sentence = '';
  let textArray = [];

  for (let i = 0; i < array.length; i++) {
    if (i % 3 === 0 && i !== 0) {
      textArray.push(sentence.trim());
      sentence = '';
    }
    sentence += (array[i] + '. ');

    if (i === array.length - 1) {
      textArray.push(sentence.trim());
    }
  }

  for (const t of textArray) {
    console.log(t);
    let p = document.createElement('p');
    p.textContent = t;
    document.getElementById('output').appendChild(p);
  }
}
