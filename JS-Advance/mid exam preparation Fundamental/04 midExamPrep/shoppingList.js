function shoppingList(arr) {
  let list = arr.shift().split("!");

  for (let element of arr) {
    if (element === "Go Shopping!") {
      console.log(list.join(", "));
    } else {
      let tokens = element.split(" ");
      let index = list.indexOf(tokens[1]);

      if (tokens[0] === "Urgent") {
        if (!list.includes(tokens[1])) {
          list.unshift(tokens[1]);
        }
      }
      if (tokens[0] === "Unnecessary") {
        if (list.includes(tokens[1])) {
          list.splice(index, 1);
        }
      }
      if (tokens[0] === "Correct") {
        if (list.includes(tokens[1])) {
          list.splice(index, 1, tokens[2]);
        }
      }
      if (tokens[0] === "Rearrange") {
        if (list.includes(tokens[1])) {
          list.splice(index, 1);
          list.push(tokens[1]);
        }
      }
    }
  }
}

shoppingList([
  "Tomatoes!Potatoes!Bread",
  "Unnecessary Milk",
  "Urgent Tomatoes",
  "Go Shopping!",
]);

shoppingList([
  "Milk!Pepper!Salt!Water!Banana",
  "Urgent Salt",
  "Unnecessary Grapes",
  "Correct Pepper Onion",
  "Rearrange Grapes",
  "Correct Tomatoes Potatoes",
  "Go Shopping!",
]); //Milk, Onion, Salt, Water, Banana
