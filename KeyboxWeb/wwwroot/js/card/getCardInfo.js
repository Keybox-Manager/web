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
    $('#cardid').show();
    $('#cardName').text(card.name);
    $('#categoryName').text(card.category.name);
    $('#password').text(card.category.name);
    $('#url').text(card.url);
    $('#notes').text(card.notes);

    updateAccounts(card.accounts);
}

function updateAccounts(accounts) {
    const accountList = $('#accountList');
    accountList.empty();
    accounts.forEach(account => {
        const accountElement = $(`
            <div>
                <div>Login: ${account.login}</div>
                <div>Password: ${account.password}</div>
                <div>Email: ${account.email}</div>
                <div>DateAdd: ${account.dateadd}</div>
                <div>DateUpdate: ${account.dateupdate}</div>
            </div>
        `);
        accountList.append(accountElement);
    });
}