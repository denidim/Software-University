function addItem() {
    let inputText = document.querySelector('#newItemText');
    
    let li = document.createElement('li');
    li.textContent = inputText.value;

    let parent = document.querySelector('#items');
    parent.appendChild(li);

    inputText.value = '';
}