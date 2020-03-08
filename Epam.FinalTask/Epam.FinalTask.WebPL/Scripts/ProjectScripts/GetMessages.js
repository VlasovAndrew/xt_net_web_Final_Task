let messageWall = document.getElementById('message-wall');
let channelID = document.getElementById('channel-id').value;

let lastMessageIndex = 0;

let readMessages = (data) => {
    let response = JSON.parse(data);
    let responeseLength = response.length;
    for (let i = lastMessageIndex; i < responeseLength; i++) {
        let messageRow = document.createElement('div');
        messageRow.classList.add("my-2");
        messageRow.classList.add('message-row');
        let userCaption = document.createElement('span');
        let messageDate = new Date(response[i].SendingTime);

        userCaption.innerHTML = `От ${response[i].UserName}  
            ${response[i].UserSurname}
            ${messageDate.toLocaleTimeString()}
            ${ messageDate.toLocaleDateString()}`;

        let messageText = document.createElement('div');
        messageText.innerHTML = `${response[i].Text}`;

        messageRow.appendChild(userCaption);
        messageRow.appendChild(messageText);
        
        messageRow.onclick = () => {
            window.location.href = '../messages/edit?id=' + response[i].ID; 
        };

        messageWall.appendChild(messageRow);
    }
    if (responeseLength > lastMessageIndex) {
        lastMessageIndex = responeseLength;
    }
}

let getMessages = () => {
    $.get('/actions/GetMessages?id=' + channelID, readMessages);
}

getMessages();
setInterval(getMessages, 500);
