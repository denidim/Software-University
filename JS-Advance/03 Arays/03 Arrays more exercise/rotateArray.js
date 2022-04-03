function rotate(arr) {
  let rotations = Number(arr.pop());
  let arrayOfElement = arr;

  for (let i = 0; i < rotations; i++) {
   let elementToMove = arrayOfElement.pop();
    arrayOfElement.unshift(elementToMove);
  }
  console.log(arrayOfElement.join(' '));
}
rotate(['1', '2', '3', '4', '2'])
rotate(['Banana', 'Orange', 'Coconut', 'Apple', '15']);