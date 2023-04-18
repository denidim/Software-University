function calc() {
    const firstInput = Number(document.getElementById('num1').value);
    const secondInput = Number(document.getElementById('num2').value);
    const sum = document.getElementById('sum');
    sum.value = firstInput + secondInput;
}
