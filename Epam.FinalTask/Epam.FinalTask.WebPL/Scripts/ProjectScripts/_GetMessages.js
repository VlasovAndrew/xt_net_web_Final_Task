let messageWall = document.getElementById('message-wall');
let channelID = document.getElementById('channel-id').value;

let lastMessageIndex = 0;

let readMessages = (data) => {
    let response = JSON.parse(data);
    let responeseLength = response.length;
    for (let i = lastMessageIndex; i < responeseLength; i++) {
        let messageRow = document.createElement('div');
        messageRow.classList.add("my-2");
        let userCaption = document.createElement('span');
        userCaption.innerHTML = `${response[i].UserName}  ${response[i].UserSurname} ${response[i].SendingTime}`;

        let messageText = document.createElement('div');
        messageText.innerHTML = `${response[i].Text}`;

        messageRow.appendChild(userCaption);
        messageRow.appendChild(messageText);

        messageWall.appendChild(messageRow);
    }
    if (responeseLength > lastMessageIndex) {
        lastMessageIndex = responeseLength;
    }
}

let getMessages = () => {
    $.get('/actions/GetMessages?id=' + channelID, readMessages);
    console.log("hello");
}

setInterval(getMessages, 500);
