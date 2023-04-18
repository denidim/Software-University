function addItem() {
    let inputText = document.querySelector('#newItemText');

    let li = document.createElement('li');
    li.textContent = inputText.value;

    let newAncor = document.createElement('a');
    newAncor.textContent = '[Delete]';
    newAncor.setAttribute('href','#');
    newAncor.addEventListener('click', deleteHandler);

    li.appendChild(newAncor);

    let ulParent = document.querySelector('#items');
    ulParent.appendChild(li);

    inputText.value = '';


    function deleteHandler(e) {
        e.currentTarget.parentElement.remove();
    }

}