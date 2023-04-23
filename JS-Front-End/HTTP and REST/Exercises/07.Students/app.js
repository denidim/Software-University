function attachEvents() {
  window.addEventListener('load', loadAllStudents)
  const BASE_URL = 'http://localhost:3030/jsonstore/collections/students';
  const inputFirstName = document.querySelector('input[name="firstName"]');
  const inputLastName = document.querySelector('input[name="lastName"]');
  const inputFacultyNumber = document.querySelector('input[name="facultyNumber"]');
  const inputGrade = document.querySelector('input[name="grade"]');
  const btnSubmit = document.getElementById('submit');
  const tableBody = document.querySelector('#results > tbody');
  btnSubmit.addEventListener('click', createStudent);

  async function createStudent() {
    const firstName = inputFirstName.value;
    const lastName = inputLastName.value;
    const facultyNumber = inputFacultyNumber.value;
    const grade = inputGrade.value;
    const httpHeaders = {
      method: 'POST',
      body: JSON.stringify({ firstName, lastName, facultyNumber, grade })
    }
    await fetch(BASE_URL, httpHeaders);
  }

  async function loadAllStudents(){
    const initial =  await fetch(BASE_URL);
    const data = await initial.json();
    

    for (const {firstName, lastName, facultyNumber, grade} of Object.values(data)) {    
      const tableRow = createElements('tr', '', tableBody);
      createElements('td', firstName, tableRow);
      createElements('td', lastName, tableRow);
      createElements('td', facultyNumber, tableRow);
      createElements('td', grade, tableRow);      
    }
  }

  function createElements(type, contentOrValue, parentNode, id, classes, attributes) {
    const htmlElement = document.createElement(type);

    if (contentOrValue && type === 'input') {
      htmlElement.value = contentOrValue;
    }
    if (contentOrValue && type !== 'input') {
      htmlElement.textContent = contentOrValue;
    }

    if (id) {
      htmlElement.id = id;
    }
    if (classes) {
      htmlElement.classList.add(...classes)
    }
    if (attributes) {
      for (const key in attributes) {
        htmlElement.setAttribute(key, attributes[key])
      }
    }
    if (parentNode) {
      parentNode.appendChild(htmlElement);
    }
    return htmlElement;
  }

}

attachEvents();