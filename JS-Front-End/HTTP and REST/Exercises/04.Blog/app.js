function attachEvents() {
    const POSTS_URL = 'http://localhost:3030/jsonstore/blog/posts';
    const COMMENTS_URL = 'http://localhost:3030/jsonstore/blog/comments';
    const btnLoadPosts = document.getElementById('btnLoadPosts');
    const btnViewPost = document.getElementById('btnViewPost');
    const selectPosts = document.getElementById('posts');
    const postTitle = document.getElementById('post-title');
    const postBody = document.getElementById('post-body');
    const postComments = document.getElementById('post-comments');

    let allPosts = {};

    btnLoadPosts.addEventListener('click', loadPosts);
    btnViewPost.addEventListener('click', viewPost);

    function loadPosts() {
        fetch(`${POSTS_URL}`)
            .then((res) => res.json())
            .then((posts) => {
                allPosts = posts;
                for (const key in posts) {
                    const newOption = document.createElement('option');                                 
                    newOption.value = key;
                    newOption.text = allPosts[key].title;
                    selectPosts.appendChild(newOption);
                }
            })
            .catch((err) => console.log(err))
    }

    function viewPost() {
        fetch(`${COMMENTS_URL}`)
            .then((res) => res.json())
            .then((comments) => {
                postComments.innerHTML = '';
                for (const key in comments) {
                    postTitle.textContent = allPosts[selectPosts.value].title;
                    postBody.textContent = allPosts[selectPosts.value].body;
                    if (comments[key].postId === selectPosts.value) {                       
                        const newLi = document.createElement('li');
                        newLi.textContent = comments[key].text;
                        postComments.appendChild(newLi);
                    }

                }
            })
            .catch((err) => console.log(err))
    }
}

attachEvents();