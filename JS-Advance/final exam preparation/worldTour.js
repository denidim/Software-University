function worldTour(input) {
    let stops = input.shift();

    while (input[0] !== 'Travel') {
        let [command, p1, p2] = input.shift().split(':');

        if (command === 'Add Stop') {
            let index = Number(p1);

            if(index >= 0 && index < stops.length) {

                let left = stops.slice(0, index);
                let rigth = stops.slice(index);
                stops = left + p2 + rigth;
                console.log(stops);
            }
          
        } else if (command === 'Remove Stop') {
            let startIndex = Number(p1);
            let endIndex = Number(p2);
            if (startIndex >= 0 && startIndex < stops.length 
                && endIndex >= 0 && endIndex < stops.length 
                && startIndex <= endIndex) {
                    
                let left = stops.slice(0, startIndex);
                let rigth = stops.slice(endIndex + 1);
                stops = left + rigth;
                console.log(stops);
            } 
        } else if (command === 'Switch') {
            if (stops.includes(p1)) {
           
          let offset = 0;
           while (stops.indexOf(p1, offset) >= 0) {
            stops = stops.replace(p1, (p1, offset) => p2);
            offset = stops.indexOf(p1, offset) + p2.length;
        }
           
                // while (stops.includes(p1)) {
                //     stops = stops.replace(p1, p2);
                // }
                    console.log(stops);
    
            }else{
                console.log(stops);
            }
        }
    }
    console.log(`Ready for world tour! Planned stops: ${stops}`);

    // function  indexValidation(text,p1,p2) {
    //     if((p1>=0&&p1<text.length)||(p2>=0&&p2<text.length)){
    //         return true;
    //     }
    // }
}
worldTour(["Hawai::Cyprys-Greece",
"Add Stop:7:Rome",
"Remove Stop:11:16",
"Switch:Hawai:Bulgaria",
"Travel"])


worldTour(['Albania:Bulgaria:Cyprus:Deuchland', 
    'Add Stop:3:Nigeria', 
    'Remove Stop:4:8', 
    'Switch:Albania: Azərbaycan', 
    'Travel'
    ])