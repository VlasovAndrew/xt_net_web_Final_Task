let sendBtn = document.getElementById('send-btn');
let messageArea = document.getElementById('message-field');

let sendMessage = () => {
    let userID = document.getElementById('user-id').value;
    let channelID = document.getElementById('channel-id').value;
    let text = messageArea.value;
    if (text.length > 200 || text.length == 0) {
        let messageRow = document.getElementById('message-input-area');
        let messageInput = messageRow.querySelector('textarea');
        makeInvalidInput(messageRow, messageInput, 'Сообщение должно быть не более 200 символов и не должно быть пустым');
        return;
    }
    else {
        clearAllValidationResult();
    }
    messageArea.value = '';
    $.post("/actions/SendMessage", {
        UserID: userID,
        ChannelID: channelID,
        Text: text,
    }, getMessages);
}

sendBtn.onclick = sendMessage;