function addItem() {
    let text = document.getElementById('newItemText');
    let value = document.getElementById('newItemValue');

    let selectField = document.getElementById('menu');

    let option = document.createElement('option');

    option.textContent = text.value;
    option.value = value.value;

    selectField.appendChild(option);

    text.value = '';
    value.value = '';
}
