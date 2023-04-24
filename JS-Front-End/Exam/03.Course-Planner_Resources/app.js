
const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';
let inputsObj = [];
let courseToBeUpdated = {};

const inputDOMSelectors ={
    title: document.getElementById('course-name'),
    type: document.getElementById('course-type'),
    description: document.getElementById('description'),
    teacher: document.getElementById('teacher-name')
}

const otherDOMSelectors ={
    form: document.querySelector('#form form'),
    addBtn: document.getElementById('add-course'),
    editBtn: document.getElementById('edit-course'),
    loadBtn: document.getElementById('load-course'),
    coursesContainer: document.getElementById('list')
}

otherDOMSelectors.loadBtn.addEventListener('click', loadAllCourses);
otherDOMSelectors.editBtn.addEventListener('click', editCourse);
otherDOMSelectors.addBtn.addEventListener('click', addNewCourse);

function addNewCourse(event){
    if(event){
        event.preventDefault();
    }
    const newCourse = {
        title: inputDOMSelectors.title.value,
        type: inputDOMSelectors.type.value,
        description: inputDOMSelectors.description.value,
        teacher: inputDOMSelectors.teacher.value,
    }
    httpHeaders ={
        method: 'POST',
        body: JSON.stringify(newCourse)
    }

    fetch(BASE_URL, httpHeaders)
    .then(() =>{
        loadAllCourses();
        otherDOMSelectors.form.reset();
    })
    .catch((err) => {
        console.error(err);
    })

}

function editCourse(event){
    if(event){
        event.preventDefault();
    }
    const payload = {
        title: inputDOMSelectors.title.value,
        type: inputDOMSelectors.type.value,
        description: inputDOMSelectors.description.value,
        teacher: inputDOMSelectors.teacher.value,
    }
    httpHeaders ={
        method: 'PATCH',
        body: JSON.stringify(payload)
    }
    fetch(`${BASE_URL}${courseToBeUpdated._id}`, httpHeaders)
    .then((res) => res.json)
    .then(() =>{
        loadAllCourses();
        otherDOMSelectors.editBtn.setAttribute('disabled', true);
        otherDOMSelectors.addBtn.removeAttribute('disabled');
        otherDOMSelectors.form.reset();
    })
    .catch((err) => {
        console.error(err);
    })
}

function loadAllCourses(event){
    if(event){
        event.preventDefault();
    }
    otherDOMSelectors.coursesContainer.innerHTML = '';

    fetch(BASE_URL)
    .then((res) => res.json())
    .then((data) =>{
        inputsObj = Object.values(data);
        console.log(inputsObj);
        for (const course of Object.values(data)) {
            const divContainer = createElement('div', '', otherDOMSelectors.coursesContainer, '', ['container'], {id: course._id});
            createElement('h2', course.title, divContainer);
            createElement('h3', course.teacher, divContainer);
            createElement('h3', course.type, divContainer);
            createElement('p', course.description, divContainer);
            const editBtnInContainer = createElement('button', 'Edit Course', divContainer, '', ['edit-btn']);
            editBtnInContainer.addEventListener('click', loadDataInInputForm)
            const finishBtnInContainer = createElement('button', 'Finish Course', divContainer, '', ['finish-btn']);
            finishBtnInContainer.addEventListener('click', deleteCourse);
        }

    })
    .catch((err) => {
        console.error(err);
    })
}

function loadDataInInputForm(){
    const parentElement = this.parentNode;
    const id = this.parentNode.id;
    courseToBeUpdated = inputsObj.find((inp) => inp._id === id);
    for (const key in inputDOMSelectors) {
        inputDOMSelectors[key].value = courseToBeUpdated[key];
    }
    otherDOMSelectors.addBtn.setAttribute('disabled', true);
    otherDOMSelectors.editBtn.removeAttribute('disabled');
    parentElement.remove();
}

function deleteCourse(){
    const id = this.parentNode.id;
    
    httpHeaders ={
        method: 'DELETE'
    }

    fetch(`${BASE_URL}${id}`, httpHeaders)
    .then(() =>{
        loadAllCourses();
    })
    .catch((err) => {
        console.error(err);
    })
}


function inputsValidator(obj){
    return Object.values(obj).every((inp) => inp.value.trim() !== '');
  }
  
   function createElement(type, content, parentNode, id, classes, attributes){
    const htmlElement = document.createElement(type);
  
    if (content && type === 'input') {
      htmlElement.value = content;
    }
    if (content && type !== 'input') {
      htmlElement.textContent = content;
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