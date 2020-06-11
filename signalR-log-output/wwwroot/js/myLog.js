"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/logHub").build();

connection.on("Notification", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " - " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});
