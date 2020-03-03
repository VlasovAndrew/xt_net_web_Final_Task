let sendBtn = document.getElementById('send-btn');
let messageArea = document.getElementById('message-field');

let sendMessage = () => {
    let userID = document.getElementById('user-id').value;
    let channelID = document.getElementById('channel-id').value;
    let text = messageArea.value;
    messageArea.value = '';
    $.post("/actions/SendMessage", {
        UserID: userID,
        ChannelID: channelID,
        Text: text,
    });
}

sendBtn.onclick = sendMessage;