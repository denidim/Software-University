function attachEvents() {
  const BASE_URL = 'http://localhost:3030/jsonstore/collections/books/';
  const loadBtn = document.getElementById('loadBooks');
  const tBody = document.getElementsByTagName('tbody')[0];
  const formName = document.getElementsByTagName('h3')[0];
  const submitBtn = document.querySelector('#form > button');
  const titleInput = document.querySelector('#form > input[name="title"]');
  const authorInput = document.querySelector('#form > input[name="author"]');


  loadBtn.addEventListener('click', loadHandler);
  submitBtn.addEventListener('click', submitHandler);

  function loadHandler() {
    tBody.innerHTML = '';
    fetch(BASE_URL)
      .then((res) => res.json())
      .then((data) => {
        for (const bookId in data) {
          const { author, title } = data[bookId];
          const tr = document.createElement('tr');
          tBody.appendChild(tr);
          const firstTd = document.createElement('td');
          firstTd.textContent = title;
          firstTd.id = 'title';
          const secondTd = document.createElement('td');
          secondTd.textContent = author;
          secondTd.id = 'author';
          const thirdTd = document.createElement('td');
          const editBtn = document.createElement('button');
          editBtn.textContent = 'Edit';
          editBtn.id = bookId;
          editBtn.addEventListener('click', editHandler);
          const deleteBtn = document.createElement('button');
          deleteBtn.textContent = 'Delete';
          deleteBtn.id = bookId;
          deleteBtn.addEventListener('click', deleteHandler);
          thirdTd.appendChild(editBtn);
          thirdTd.appendChild(deleteBtn);
          tr.appendChild(firstTd);
          tr.appendChild(secondTd);
          tr.appendChild(thirdTd);
        }
      })
      .catch((err) => {
        console.log(err);
      })
  }

  function submitHandler(e) {

    if (titleInput.value.length > 0 &&
      authorInput.value.length > 0) {

      if (e.currentTarget.textContent === 'Save') {

        const obj = { author: authorInput.value, title: titleInput.value };

        const htmlHEaders = {
          method: 'PUT',
          body: JSON.stringify(obj)
        };

        const id = e.currentTarget.id;

        fetch(`${BASE_URL}${id}`, htmlHEaders)
          .then((res) => res.json())
          .then(() => {
            loadHandler();
            titleInput.value = '';
            authorInput.value = '';
            submitBtn.textContent = 'Submit';
            formName.textContent = 'Form';
          })
          .catch((err) => {
            console.log(err);
          })

      } else {

        const obj = { author: authorInput.value, title: titleInput.value };

        const htmlHEaders = {
          method: 'POST',
          body: JSON.stringify(obj)
        };

        fetch(BASE_URL, htmlHEaders)
          .then((res) => res.json())
          .then(() => {
            loadHandler();
            titleInput.value = '';
            authorInput.value = '';
          })
          .catch((err) => {
            console.log(err);
          })

      }
    }
  }

  function editHandler(e) {
    formName.textContent = 'Edit Form';
    const bookTitle = this.parentNode.parentNode.querySelector('#title');
    const bookAuthor = this.parentNode.parentNode.querySelector('#author');
    titleInput.value = bookTitle.textContent;
    authorInput.value = bookAuthor.textContent;
    submitBtn.textContent = 'Save';
    submitBtn.id = e.currentTarget.id;
  }

  function deleteHandler(e) {

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