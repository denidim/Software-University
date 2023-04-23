function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/phonebook/';

    const loadButton = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');
    const personName = document.getElementById('person');
    const personPhone = document.getElementById('phone');
    const ulPhoneBookContainer = document.getElementById('phonebook');

    loadButton.addEventListener('click', loadHandler);
    createBtn.addEventListener('click', createHandler)

    async function loadHandler() {
        try {
            const phoneBookResponce = await fetch(`${BASE_URL}`);
            let phoneBookData = await phoneBookResponce.json();
            ulPhoneBookContainer.innerHTML = '';
            phoneBookData = Object.values(phoneBookData);
            for (const { phone, person, _id } of phoneBookData) {
                const li = document.createElement('li');
                const deleteBtn = document.createElement('button');
                deleteBtn.textContent = 'Delete';
                deleteBtn.id = _id;
                deleteBtn.addEventListener('click', deletePhoneBookHandler);
                li.textContent = `${person}: ${phone}`;
                li.appendChild(deleteBtn);
                ulPhoneBookContainer.appendChild(li);
            }
        } catch (err) {
            console.log(err);
        }
    }

    function createHandler() {
        const createPersonObj = { person: personName.value, phone: personPhone.value }
        const httpHeaders = {
            method: 'POST',
            body: JSON.stringify(createPersonObj)
        }
        fetch(BASE_URL, httpHeaders)
            .then((res) => res.json())
            .then(() => {
                loadHandler();
                personName.value = '';
                personPhone.value = '';
            })
            .catch((err) => {
                console.log(err);
            })
    }

    async function deletePhoneBookHandler(e) {
        const httpHeaders = {
            method: 'DELETE'
        }
        fetch(`${BASE_URL}${this.id}`, httpHeaders)
            .then((res) => res.json())
            .then(loadHandler)
            .catch((err) => {
                console.log(err);
            })
    }

}

attachEvents();