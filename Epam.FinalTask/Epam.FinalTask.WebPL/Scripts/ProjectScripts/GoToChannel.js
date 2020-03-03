let currentUserId = document.getElementById('user-id').value;
let userItems = document.getElementsByClassName('user-row');

let goToChannel = (channelID) => {
    window.location.href = '../messages/channel?id=' + channelID;
}

let getChannel = () => {
    let target = event.target;
    if (!target.classList.contains("message-btn")) {
        return;
    }
    let userRow = event.currentTarget;
    let userID = userRow.querySelector("input").value;

    
    $.post("/actions/CreateDirectedChannel", {
        fromUserId: currentUserId,
        toUserId: userID,
    }, goToChannel);
}



for (let i = 0; i < userItems.length; i++) {
    userItems[i].addEventListener('click', getChannel);
}
