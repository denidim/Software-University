function focused() {
    const inputs = Array.from(document.querySelectorAll('[type="text"]'));
    for (const el of inputs) {
        el.addEventListener('focus', handleFocus);
        el.addEventListener('blur', handleBlur);
    }

    function handleFocus(e){
        this.parentNode.classList.add('focused')
    }

    function handleBlur(e){
        let parent = e.target.parentNode;
        if(parent.classList.contains('focused')){
            parent.classList.remove('focused')
        }
    }
}