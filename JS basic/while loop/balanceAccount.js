function balanceAccount(input) {

  let index = 0;
  let total = 0;
  let currentInput = (input[0]);

  while (currentInput !== "NoMoreMoney") {
      let inputAsNmber = Number(currentInput);
      if (inputAsNmber < 0) {
          console.log('Invalid operation!');
          break;
      }
      total += inputAsNmber;
      console.log(`Increase: ${inputAsNmber.toFixed(2)}`);

      index++;
      currentInput = input[index];
  }
  console.log(`Total: ${total.toFixed(2)}`);
}
balanceAccount(["5.51", "69.42", "100", "NoMoreMoney"]);


 