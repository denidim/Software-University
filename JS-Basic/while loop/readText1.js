function readText(input) {
    
    let str = input[0];
    let index = 1;


    while (str !== 'Stop') {
        console.log(str);
        str = input[index];
        index++;
        
    }
}

readText(["Nakov",
"SoftUni",
"Sofia",
"Bulgaria",
"SomeText",
"Stop",
"AfterStop",
"Europe",
"HelloWorld"]);

