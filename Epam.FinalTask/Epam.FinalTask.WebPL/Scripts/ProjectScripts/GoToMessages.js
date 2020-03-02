let channel = document.getElementsByClassName('channel');

let goToMessages = () => {
    let channelRow = event.currentTarget;
    let channelID = channelRow.querySelector('input').value;
    window.location = '/messages/channel?id=' + channelID;
}

for (let i = 0; i < channel.length; i++) {
    channel[i].addEventListener('click', goToMessages);
}
