function loadRepos() {
	const BASE_URL = 'https://api.github.com/users/';//testnakov/repos';
	const username = document.getElementById('username').value;
	const ulContainer = document.getElementById('repos');

	Array.from(ulContainer.children).
		forEach((ch) => ch.remove);

	fetch(`${BASE_URL}${username}/repos`)
		.then((res) => res.json())
		.then((data) => {
			data.forEach(({ full_name, owner }) => {
				const li = document.createElement('li');
				const a = document.createElement('a');
				a.setAttribute('href', owner.html_url)
				a.textContent = full_name;
				li.appendChild(a);
				ulContainer.appendChild(li);
			});
		})
		.catch((err) => {
			const li = document.createElement('li');
			li.textContent = err.message;
			ulContainer.appendChild(li);
		})
	console.log("TODO...");
}