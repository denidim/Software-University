function heartDelivey(arr) {
  let houses = arr.shift().split("@");
  let jumpLength = 0;

  for (let command of arr) {
    if (command === 'Love!') {
      console.log(`Cupid's last position was ${jumpLength}.`);
      
      let houseCounter = 0;
      for (let house of houses) {
        if (house > 0) {
          houseCounter++;
        }
      }
      
    
      if (houseCounter > 0) {
        console.log(`Cupid has failed ${houseCounter} places.`);
      } else {
        console.log("Mission was successful.");
      }

      break;

    }
    else {
      let tokens = command.split(' ');
      jumpLength += Number(tokens[1]);

      if (jumpLength >= houses.length) {
        jumpLength = 0;
      }
      if (houses[jumpLength] === 0) {
        console.log(`Place ${houses[jumpLength]} already had Valentine's day.`);

      } else {
        houses[jumpLength] -= 2;

        if (houses[jumpLength] === 0) {
          console.log(`Place ${jumpLength} has Valentine's day.`);
        }
      }
    }
  }
 
}
heartDelivey(["2@4@2",
  "Jump 2",
  "Jump 2",
  "Jump 8",
  "Jump 3",
  "Jump 1",
  "Love!"]);

// heartDelivey(["10@10@10@2",
//   "Jump 1",
//   "Jump 2",
//   "Love! "]);



  // let index = 0;
  // let houseIndex = 0;
  // let command = arr[index];
  // while (command !== "Love!") {
  //   let tokens = command.split(" ");
  //   houseIndex += Number(tokens[1]);

  //   if (houseIndex >= houses.length) {
  //     houseIndex = 0;
  //   }

  //   if (houses[houseIndex] === 0) {
  //     console.log(`Place ${houseIndex} already had Valentine's day.`)
  //   }
  //   else {
  //     houses[houseIndex] -= 2;
  //     if (houses[houseIndex] === 0) {
  //       console.log(`Place ${houseIndex} has Valentine's day.`);
  //     }
  //   }

  //   index++;
  //   command = arr[index];
  // }
  // console.log(`Cupid's last position was ${houseIndex}.`);

  // let counter = 0;
  // for (let house of houses) {
  //   if (house > 0) {
  //     counter++;
  //   }
  // }

  // if (counter > 0) {
  //   console.log(`Cupid has failed ${counter} places.`);
  // } else {
  //   console.log("Mission was successful.");
  // }

//heartDelivey(["10@10@10@2", "Jump 1", "Jump 2", "Love!"]);

// heartDelivey([
//   "2@4@2",
//   "Jump 2",
//   "Jump 2",
//   "Jump 8",
//   "Jump 3",
//   "Jump 1",
//   "Love!",
// ]);
