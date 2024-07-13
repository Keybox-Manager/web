function showInfo(id) {
    fetch('/card/showInfo/' + id)
        .then(response => response.text())
        .then(view => {
            $('#cardInfo').html(view);
        })
        .catch(error => {
            console.error('Error:', error);
        });
}