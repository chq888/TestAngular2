using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;      // using this
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace PublicChatServer.Hubs
{
    public class ChatHub : Hub        // inherit this
    {
        public async Task SendMessage(string message, string id)
        {
            await Clients.Client(id).SendAsync("ReceiveMessage", message, id);
        }
        public async Task GetMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        public Task SendMessage1(string user, string message)               // Two parameters accepted
        {
            return Clients.All.SendAsync("ReceiveOne", user, message);    // Note this 'ReceiveOne' 
        }
        public Task ReceiveOne(string user, string message)               // Two parameters accepted
        {
            return Clients.All.SendAsync("ReceiveOne", user, message);    // Note this 'ReceiveOne' 
        }
    }
    [Authorize]
    public class ChatHubV2 : Hub
    {

    }
    public class MessageSpreader : Hub
    {
//        var ajaxSendMessageFunction = function() {
//    document.getElementById("userTextMessage").value = "";
//};

//    var connection = new signalR.HubConnectionBuilder().withUrl("/messageSpreader").build();

//    connection.on("ReceiveMessage", function(stringMessage)
//    {
//        document.getElementById("messages").value += stringMessage;
//    })

//connection.start();
    }

}
