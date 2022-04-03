function muOnline(string) {
  let rooms = string.split("|");
  let bitcoins = 0;
  let initialHealth = 100;

  for (let i = 0; i < rooms.length; i++) {
    let tokens = rooms[i].split(" ");
    let command = tokens[0];
    let num = Number(tokens[1]);

    if (command === "potion") {
      let amount = 0;

      if (num > 100 - initialHealth) {

        amount = 100 - initialHealth;
        initialHealth += amount;

      } else {
        amount = num;
        initialHealth += num;
      }
      console.log(`You healed for ${amount} hp.`);
      console.log(`Current health: ${initialHealth} hp.`);

    } else if (command === "chest") {

      bitcoins += num;
      console.log(`You found ${num} bitcoins.`);

    } else {

      initialHealth -= num;

      if (initialHealth > 0) {
        console.log(`You slayed ${command}.`);

      } else {
        console.log(`You died! Killed by ${command}.`);
        console.log(`Best room: ${i + 1}`);
        break;
      }
    }
  }

  if (initialHealth > 0) {

    console.log("You've made it!");
    console.log(`Bitcoins: ${bitcoins}`);
    console.log(`Health: ${initialHealth}`);
  }

}
muOnline("rat 10|bat 20|potion 10|rat 10|chest 100|boss 70|chest 1000");

muOnline("cat 10|potion 30|orc 10|chest 10|snake 25|chest 110");
