let messageWall = document.getElementById('message-wall');
let channelID = document.getElementById('channel-id').value;

let readMessages = (data) => {
    let response = JSON.parse(data);
    for (let i = 0; i < response.length; i++) {
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
}

$.get('/actions/GetMessages?id=' + channelID, readMessages);


