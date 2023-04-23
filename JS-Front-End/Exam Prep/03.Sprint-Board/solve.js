function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';
    const loadBoardBtn = document.getElementById('load-board-btn');
    const titleInput = document.getElementById('title');
    const descriptionInput = document.getElementById('description');
    const addTaskBtn = document.getElementById('create-task-btn');

    const moveToButtons = {
        'ToDo': 'Move to In Progress',
        'In Progress': 'Move to Code Review',
        'Code Review': 'Move to Done',
        'Done': 'Close'
    }
    const ulSectionsPerStatus = {
        'ToDo': document.querySelector('#todo-section .task-list'),
        'In Progress': document.querySelector('#in-progress-section .task-list'),
        'Code Review': document.querySelector('#code-review-section .task-list'),
        'Done': document.querySelector('#done-section .task-list')
    }

    loadBoardBtn, addEventListener('click', loadAllTasks);
    function loadAllTasks() {
        fetch(BASE_URL)
            .then((res) => res.json())
            .then((data) => {
                const allData = Object.values(data);
                for (const key in ulSectionsPerStatus) {
                    ulSectionsPerStatus[key].innerHTML = '';
                }

                for (const item of allData) {
                    const newLi = createElements('li', '', false, ulSectionsPerStatus[item.status], item._id, ['task']);
                    const titleH3 = createElements('h3', item.title, false, newLi);
                    const descriptionPara = createElements('p', item.description, false, newLi);
                    const btnMoveTo = createElements('button', `${moveToButtons[item.status]}`, false, newLi);

                    btnMoveTo.addEventListener('click', moveToNextSection)
                }
            })
    }

    function moveToNextSection(e) {
        if (e) {
            e.preventDefault();
        }
        const btn = e.currentTarget;
        const nextSection = btn.textContent.slice(8);
        const currentLi = btn.parentNode;
        if (btn.textContent !== 'Close') {
            ulSectionsPerStatus[nextSection].appendChild(currentLi);
            httpHeaders = {
                method: 'PATCH',
                body: JSON.stringify({
                    status: nextSection,
                })
            }
            fetch(`${BASE_URL}${currentLi.id}`, httpHeaders)
            .then(() => loadAllTasks());

        }
        else {
            httpHeaders = {
                method: 'DELETE',
            }
            fetch(`${BASE_URL}${currentLi.id}`, httpHeaders)
            .then(() => loadAllTasks());
        }

    }

    addTaskBtn.addEventListener('click', (e) => {
        if (e) {
            e.preventDefault();
        }
        const newTitle = titleInput.value;
        const newDescription = descriptionInput.value;
        if (newTitle && newDescription) {
            httpHeaders = {
                method: 'POST',
                body: JSON.stringify({
                    title: newTitle,
                    description: newDescription,
                    status: 'ToDo'
                })
            }

            fetch(BASE_URL, httpHeaders)
            .then(() => loadAllTasks());

            titleInput.value = '';
            descriptionInput.value = '';

        }

    })

    function createElements(type, contentOrValue, useInnerHTML, parentNode, id, classes, attributes) {
        const htmlElement = document.createElement(type);
        if (contentOrValue && useInnerHTML) {
            htmlElement.innerHTML = contentOrValue;
        }
        else {
            if (contentOrValue && type === 'input') {
                htmlElement.value = contentOrValue;
            }
            if (contentOrValue && type !== 'input') {
                htmlElement.textContent = contentOrValue;
            }
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