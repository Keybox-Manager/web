function getCardInfo(id) {
    fetch('/vault/getcard/' + id)
        .then(response => response.json())
        .then(card => {
            updateCardInfo(card);
        })
        .catch(error => {
            console.error('Error:', error);
        });
}

function updateCardInfo(card) {
    $('#svgCardId').hide();
    $('#cardId').show();
    $('#cardName').text(card.name);
    $('#categoryName').val(card.category.name);
    $('#url').val(card.url);
    $('#notes').val(card.notes);

    updateAccounts(card.accounts);
}

function updateAccounts(accounts) {
    $('#accountList').empty();
    accounts.forEach(account => {
        addElement('loginDivPattern', account.login);
        addElement('passwordDivPattern', account.password);
        addElement('emailDivPattern', account.email);
    });
}

function addElement(id, value) {
    const element = $('#' + id).clone()
        .removeAttr('id');
    element.find("input").val(value)
        .removeAttr('id');
    $('#accountList').append(element);
}