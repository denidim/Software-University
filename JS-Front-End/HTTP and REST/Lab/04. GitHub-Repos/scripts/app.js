function loadRepos() {

   const resultContainer = document.getElementById('res');
   const BASE_URL = 'https://api.github.com/users/testnakov/repos';
   fetch(BASE_URL, { method: 'GET' })
      .then((responce)=>responce.text())
      .then((data)=>{
         resultContainer.textContent = data;
      })
      .catch((error) => {
         console.log(error);
      })
}