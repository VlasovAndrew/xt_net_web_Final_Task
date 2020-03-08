let userItems = document.getElementsByClassName('user-row');

let goToChannel = (channelID) => {
    window.location.href = '../messages/channel?id=' + channelID;
}

let createChannel = (userRow) => {
    let currentUserId = document.getElementById('user-id').value;
    let userID = userRow.querySelector("input").value;

    $.post("/actions/CreateDirectedChannel", {
        fromUserId: currentUserId,
        toUserId: userID,
    }, goToChannel);
}

let changeUserFriend = (userRow, friendBtn) => {
    let currentUserId = document.getElementById('user-id').value;
    let userID = userRow.querySelector('input').value;
    if (friendBtn.classList.contains('add-friend')) {
        $.post("/actions/AddFriend", {
            userId: currentUserId,
            friendId: userID,
        });
        friendBtn.innerHTML = 'Удалить из друзей';
        friendBtn.classList.remove('add-friend');
        friendBtn.classList.add('remove-friend');
    }
    else if (friendBtn.classList.contains('remove-friend')) {
        $.post("/actions/RemoveFriend", {
            userId: currentUserId,
            friendId: userID,    
        });
        friendBtn.innerHTML = 'Добавить в друзья';
        friendBtn.classList.add('add-friend');
        friendBtn.classList.remove('remove-friend');
    }
}

let goToProfile = (userRow) => {
    let userId = userRow.querySelector('input').value;
    window.location.href = '../user/profile?id=' + userId;
}

let catchClick = () => {
    let target = event.target;
    if (target.classList.contains("message-btn")) {
        createChannel(event.currentTarget);
        return;
    }
    else if (target.classList.contains("friend-btn")) {
        changeUserFriend(event.currentTarget, target);
        return;
    }

    goToProfile(event.currentTarget);
}

for (let i = 0; i < userItems.length; i++) {
    userItems[i].addEventListener('click', catchClick);
}
