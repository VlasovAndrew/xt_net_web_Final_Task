let messageWall = document.getElementById('message-wall');
let channelID = document.getElementById('channel-id').value;

let lastMessageIndex = 0;

let readMessages = (data) => {
    let response = JSON.parse(data);

    let message = response["messages"];
    let adminStatus = response["role"];
    let messageLength = message.length;

    for (let i = lastMessageIndex; i < messageLength; i++) {
        let messageRow = document.createElement('div');
        messageRow.classList.add("my-2");
        messageRow.classList.add('message-row');
        let userCaption = document.createElement('span');

        let messageDate = new Date(message[i].SendingTime);
        userCaption.innerHTML = `От ${message[i].UserName}  
            ${message[i].UserSurname}
            ${messageDate.toLocaleTimeString()}
            ${ messageDate.toLocaleDateString()}`;

        let messageText = document.createElement('div');
        messageText.innerHTML = `${message[i].Text}`;

        messageRow.appendChild(userCaption);
        messageRow.appendChild(messageText);
        if (adminStatus) {
            messageRow.onclick = () => {
                window.location.href = '../messages/edit?id=' + message[i].ID;
            };
        }        
        
        messageWall.appendChild(messageRow);
    }
    if (messageLength > lastMessageIndex) {
        lastMessageIndex = messageLength;
    }
}

let getMessages = () => {
    $.get('/actions/GetMessages?id=' + channelID, readMessages);
}

getMessages();
setInterval(getMessages, 500);
