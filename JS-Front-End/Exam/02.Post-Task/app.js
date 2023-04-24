window.addEventListener("load", solve);

function solve() {

    const reviewElement = document.getElementById('review-list');
    const publishedElement = document.getElementById('published-list');
    const publishBtn = document.getElementById('publish-btn');
    publishBtn.addEventListener('click', onPublish);

    function onPublish() {
        const titleInput = document.getElementById('task-title');
        const categoryInput = document.getElementById('task-category');
        const contentInput = document.getElementById('task-content');

        const title = titleInput.value;
        const category = categoryInput.value;
        const content = contentInput.value;

        if (title == '' || category == '' || content == '') {
            return;
        }

        const liElement = document.createElement('li');
        liElement.classList = 'rpost';

        const articleElement = document.createElement('article');
        const h4 = document.createElement('h4');
        h4.textContent = title;
        const pCategory = document.createElement('p');
        pCategory.textContent = `Category: ${category}`;

        const pContent = document.createElement('p');
        pContent.textContent = `Content: ${content}`;

        const btnEdit = document.createElement('button');
        btnEdit.classList = 'action-btn edit';
        btnEdit.textContent = 'Edit';
        btnEdit.addEventListener('click', onEdit);

        const btnPost = document.createElement('button');
        btnPost.classList = 'action-btn post';
        btnPost.textContent = 'Post';
        btnPost.addEventListener('click', onPublish);

        articleElement.appendChild(h4);
        articleElement.appendChild(pCategory);
        articleElement.appendChild(pContent);

        liElement.appendChild(articleElement);
        liElement.appendChild(btnEdit);
        liElement.appendChild(btnPost);

        reviewElement.appendChild(liElement);

        titleInput.value = '';
        categoryInput.value = '';
        contentInput.value = '';

        function onEdit(e) {
            e.target.parentElement.remove();
            titleInput.value = title;
            categoryInput.value = category;
            contentInput.value = content;
        }

        function onPublish(e) {
            e.target.parentElement.remove();
            liElement.removeChild(btnEdit);
            liElement.removeChild(btnPost);
            publishedElement.appendChild(liElement);
        }
    }
}       