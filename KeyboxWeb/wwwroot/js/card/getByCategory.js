function getByCategory(categoryId) {
    fetch('/vault/index?categoryId=' + categoryId)
        .then(response => response.text())
        .then(view => {
            $('#panelCategory').html(view);
        })
        .catch(error => {
            console.error('Error:', error);
        });
}