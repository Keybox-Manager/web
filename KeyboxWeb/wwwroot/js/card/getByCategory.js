function getByCategory(categoryId) {
    fetch('/card/index?categoryId=' + categoryId)
        .then(response => response.text())
        .then(view => {
            $('#cardList').html(view);
        })
        .catch(error => {
            console.error('Error:', error);
        });
}