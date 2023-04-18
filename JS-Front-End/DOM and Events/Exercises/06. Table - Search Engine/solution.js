function solve() {

   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const word = document.getElementById('searchField');

      const rows = Array.from(document.querySelectorAll('tbody > tr > td'));

      for (const row of rows) {

         if (row.textContent.includes(word.value)) {

            row.parentElement.classList.add('select');
         }
      }

      word.value = '';
   }
}