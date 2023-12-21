// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/BulkyHub")
    .build();

connection.start().then(function () {
    console.log("SignalR connected.");

    connection.on("ReceiveUpdatedCategory", function (updatedCategory) {
        // Handle the received updated category
        console.log("Received updated category:", updatedCategory);
        // Update your UI or perform actions based on the received data
    });
}).catch(function (err) {
    return console.error(err.toString());
});