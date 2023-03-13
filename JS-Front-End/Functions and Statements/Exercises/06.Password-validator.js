function passwodValidator(pass){
    const lengthCheck = (pass) => pass.toString().length >= 6 && pass.toString().length <= 10;
    const onlyLettersAndDigitsCheck = (pass) => /^[A-Za-z0-9]*$/.test(pass);
    const atLeastTwoDigitsCheck = (pass) => [...pass.matchAll(/\d/g)].length >= 2;
   
    let isValid = true;

    if(!lengthCheck(pass)){
        console.log('Password must be between 6 and 10 characters');
        isValid = false;
    }
    if(!onlyLettersAndDigitsCheck(pass)){
        console.log('Password must consist only of letters and digits');
        isValid = false;
    }
    if(!atLeastTwoDigitsCheck(pass)){
        console.log('Password must have at least 2 digits');
        isValid = false;
    }

    if(isValid){
        console.log('Password is valid');
    }
}

passwodValidator('logIn');
passwodValidator('MyPass123');
passwodValidator('Pa$s$s');