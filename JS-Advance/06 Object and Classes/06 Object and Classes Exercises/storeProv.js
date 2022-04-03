function solve(availableStock, deliveredSotck) {
    let storedProducts = {};
    for (let index = 0; index < availableStock.length; index += 2) {
      let currProduct = availableStock[index];
      storedProducts[currProduct] = Number(availableStock[index + 1]);
    }
    for (let index = 0; index < deliveredSotck.length; index += 2) {
      let currProduct = deliveredSotck[index];
      if (!storedProducts.hasOwnProperty(currProduct)) {
        storedProducts[currProduct] = 0;
      }
      storedProducts[currProduct] += Number(deliveredSotck[index + 1]);
    }
    for (let product of Object.keys(storedProducts)) {
      console.log(`${product} -> ${storedProducts[product]}`);
    }
  }
   
  solve(
    ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
    ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
  );