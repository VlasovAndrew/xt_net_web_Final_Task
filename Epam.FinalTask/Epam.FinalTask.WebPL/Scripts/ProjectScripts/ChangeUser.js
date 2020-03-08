let userID = document.getElementById('profile-id').value;
let deleteBtn = document.getElementById('delete-btn');
let editBtn = document.getElementById('edit-btn');
let messageBtn = document.getElementById('message-btn');

deleteBtn.onclick = () => {
    $.get('/actions/deleteUser?id=' + userID, () => {
        window.location.href = '../user/search';
    });
}


editBtn.onclick = () => {
    window.location.href = '../user/edit?id=' + userID;
}

messageBtn.onclick = () => {
    window.location.href = '../messages?id=' + userID;
}