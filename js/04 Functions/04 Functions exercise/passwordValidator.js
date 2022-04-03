function passwordValidator(password) {
    function isLengthBetweenSixAndTen(string) {
        if(string.length >= 6 && string.length <= 10){
            return true;
        }else{
            return false;
        }
    }

    function consistsOnlyOfLettersAndDigits(string) {
        for(let char of string){
            let charCode = char.charCodeAt(0);
            if(!(charCode >= 48 && charCode <= 57) &&
            !(charCode >= 65 && charCode <= 90)&&
            !(charCode >= 97 && charCode <= 122)) {
                return false;
            }
        }
        return true;
    }

    function hasAtleastTwoDigits(string) {
        let counter = 0;
        for(let char of string){
            let charCode = char.charCodeAt(0);
            if(charCode >= 48 && charCode <= 57){
                counter++; 
            }
        }
       // return counter >= 2;
        if(counter >= 2){
            return true;
        }else{
            return false;
        }
    }

    let isLengthValid = isLengthBetweenSixAndTen(password);
    let containsLettersAndDigits = consistsOnlyOfLettersAndDigits(password);
    let consistAtLeastTwoDigits = hasAtleastTwoDigits(password);

    if(isLengthValid && containsLettersAndDigits && consistAtLeastTwoDigits){
        console.log('Password is valid');
        return;
    }
    if(!isLengthValid){
        console.log('Password must be between 6 and 10 characters');
    }
    if(!containsLettersAndDigits){
        console.log('Password must consist only of letters and digits');
    }
    if(!consistAtLeastTwoDigits){
        console.log('Password must have at least 2 digits');
    }
}
//passwordValidator('logIn');
//passwordValidator('MyPass123');
passwordValidator('Pa$s$s');

