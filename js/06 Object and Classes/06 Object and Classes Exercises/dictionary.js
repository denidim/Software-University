function dictionary(list) {
  let dict = {};

  for(let item of list){
   let obj = JSON.parse(item);
   let key = Object.keys(obj)[0];
   let value = Object.values(obj)[0];
   dict[key] = value;
  }
  let resultDict = [];

  for(let i in dict){
      resultDict.push({[i]: dict[i]});
  }

  resultDict.sort((a, b) =>{
    if(Object.keys(a)[0]  > Object.keys(b)[0]){
        return 1;
      } 
      if(Object.keys(a)[0] < Object.keys(b)[0]){
        return -1;
      } 
      if(Object.keys(a)[0] === Object.keys(b)[0]){
   
      }
  });

  for(let el of resultDict){
      let key = Object.keys(el).join();
      let value = el[key];

      console.log(`Term: ${key} => Definition: ${value}`);
  }
   
}

dictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
]);