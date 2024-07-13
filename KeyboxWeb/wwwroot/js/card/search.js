function search(name) {
    fetch('/card/search?name=' + name)
        .then(response => response.text())
        .then(view => {
            $('#cardList').html(view);
        })
        .catch(error => {
            console.error('Error:', error);
        });
}