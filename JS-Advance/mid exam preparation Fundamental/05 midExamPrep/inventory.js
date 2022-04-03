function inventory(arr) {
  let collection = arr.shift().split(", ");

  for (let element of arr) {
    let tokens = element.split(" - ");

    if(element === 'Craft!'){
      console.log(collection.join(', '));
    }

    if (tokens[0] === "Collect"){
      if (!collection.includes(tokens[1])) {
        collection.push(tokens[1]);
      }
    }

    if (tokens[0] === "Drop") {
      if (collection.includes(tokens[1])) {
        let index = collection.indexOf(tokens[1]);
        collection.splice(index, 1);
      }
    }
    if (tokens[0] === "Combine Items") {
      let items = tokens[1].split(":");
      let oldItem = items[0];
      let newItem = items[1];

      if (collection.includes(oldItem)) {
        let index = collection.indexOf(oldItem);
        collection.splice(index + 1, 0, newItem);
      } 
    }
    if (tokens[0] === "Renew") {
      if (collection.includes(tokens[1])) {
        let index = collection.indexOf(tokens[1]);
        let currItem = collection[index];
        collection.splice(index, 1);
        collection.push(currItem);

      }
    }
  }
}



inventory(["Iron, Wood, Sword", "Collect - Gold", "Drop - Wood", "Craft!"]);

inventory([
  "Iron, Sword",
  "Drop - Bronze",
  "Combine Items - Sword:Bow",
  "Renew - Iron",
  "Craft!",
]);
