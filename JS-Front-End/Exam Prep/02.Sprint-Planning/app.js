window.addEventListener('load', solve);

window.addEventListener('load', solve);

function solve() {
    let id = 0;
    let totalPoints = 0;
    const taskIdInput = document.getElementById('task-id');
    const titleInput = document.getElementById('title');
    const descriptionInput = document.getElementById('description');
    const selectLabelInput = document.getElementById('label');
    const pointsInput = document.getElementById('points');
    const assigneeInput = document.getElementById('assignee');
    const createTaskBtn = document.getElementById('create-task-btn');
    const deleteTaskBtn = document.getElementById('delete-task-btn');
    const tasksSection = document.getElementById('tasks-section');
    const totalSprintPoints = document.getElementById('total-sprint-points');
    const form = document.getElementById('create-task-form');

    const selectLabelIcons = {
        'Feature': '&#8865',
        'Low Priority Bug': '&#9737',
        'High Priority Bug': '&#9888',
    }

    const labelDivAddClass = {
        'Feature': 'feature',
        'Low Priority Bug': 'low-priority',
        'High Priority Bug': 'high-priority',
    }

    createTaskBtn.addEventListener('click', createTask);

    function createTask() {
        const title = titleInput.value;
        const description = descriptionInput.value;
        const points = pointsInput.value;
        const assignee = assigneeInput.value;
        const selectLabel = selectLabelInput.value;

        if (title && description && points && assignee && selectLabel) {
            totalPoints += Number(points);
            totalSprintPoints.textContent = `Total Points ${totalPoints}pts`;
            const article = createElements('article', '', false, tasksSection, `task-${++id}`, ['task-card']);
            const selectLabelDiv = createElements('div', `${selectLabel} ${selectLabelIcons[selectLabel]}`, true, article, '', ['task-card-label', labelDivAddClass[selectLabel]]);
            const titleH3 = createElements('h3', title, false, article, '', ['task-card-title']);
            const descriptionPara = createElements('p', description, false, article, '', ['task-card-description']);
            const pointsDiv = createElements('div', `Estimated at ${points} pts`, false, article, '', ['task-card-points']);
            const assigneeDiv = createElements('div', `Assigned to: ${assignee}`, false, article, '', ['task-card-assignee']);
            const taskCardActionsDiv = createElements('div', '', false, article, '', ['task-card-actions']);
            const deleteBtn = createElements('button', 'Delete', false, taskCardActionsDiv);

            form.reset();
            selectLabelInput.value = '';

            deleteBtn.addEventListener('click', (e) => {
                taskIdInput.value = e.currentTarget.parentNode.parentNode.id;
                titleInput.value = title;
                descriptionInput.value = description;
                pointsInput.value = points;
                assigneeInput.value = assignee;
                selectLabelInput.value = selectLabel;
                deleteTaskBtn.disabled = false;
                createTaskBtn.disabled = true;
                titleInput.disabled = true;
                descriptionInput.disabled = true;
                pointsInput.disabled = true;
                assigneeInput.disabled = true;
                selectLabelInput.disabled = true;
            })
        }
    }

    deleteTaskBtn.addEventListener('click', (e) => {
        const searchForm = e.currentTarget.parentNode.parentNode;        
        const elementToRemoveId = searchForm.querySelectorAll('input')[0].value;        
        let articleToRemove = tasksSection.querySelector(`#${elementToRemoveId}`);
        articleToRemove.remove();
        totalPoints -= Number(pointsInput.value)
        totalSprintPoints.textContent = `Total Points ${totalPoints}pts`;
        form.reset();
        selectLabelInput.value = '';
        titleInput.disabled = false;
        descriptionInput.disabled = false;
        pointsInput.disabled = false;
        assigneeInput.disabled = false;
        selectLabelInput.disabled = false;
        deleteTaskBtn.disabled = true;
        createTaskBtn.disabled = false;
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
        // {src: 'link', href : 'http'}
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
