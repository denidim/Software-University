function create(words) {

   for (const word of words) {
      let p = document.createElement('p');
      p.style.display = 'none'
      p.textContent = word;

      let div = document.createElement('div');
      div.appendChild(p);

      div.addEventListener('click', handleClick);

      function handleClick(e) {
         this.childNodes[0].style.display = 'block';
      }

      document.getElementById('content').appendChild(div);
   }
}