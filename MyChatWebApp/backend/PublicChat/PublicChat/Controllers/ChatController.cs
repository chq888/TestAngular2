using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using PublicChatServer.Hubs;
using PublicChatServer.ReqDto;

namespace PublicChatServer.Controllers
{
    [Produces("application/json")]
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IHubContext<MessageSpreader> messageSpreaderHubContext;

        public ChatController(IHubContext<ChatHub> hubContext, IHubContext<MessageSpreader> messageSpreaderHubContext)
        {
            _hubContext = hubContext;
            this.messageSpreaderHubContext = messageSpreaderHubContext;
        }

        [Route("send")]                                           //path looks like this: https://localhost:44379/api/chat/send
        [HttpPost]
        public IActionResult SendRequest([FromBody] MessageDto msg)
        {
            _hubContext.Clients.All.SendAsync("ReceiveOne", msg.user, msg.msgText);
            return Ok();
        }

        private void DistributeMessage(string message)
        {
            messageSpreaderHubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }

    }
}
public class ChatCore
{
    private readonly IHubContext<MessageSpreader> hubContext;
    private StringBuilder sb = new();

    public ChatCore(IHubContext<MessageSpreader> HubContext)
    {
        hubContext = HubContext;
    }

    private void DistributeMessage(string message)
    {
        hubContext.Clients.All.SendAsync("ReceiveMessage", message);
    }


}

public interface IMessagingService
{
    Task SendMessage(string senderUsername);
}


public class MessagingService : IMessagingService
{
    // Названия SignalR-Событий на стороне клиентов
    private const string ON_NEW_MESSAGE_METHOD_NAME = "NewMessage";
    private readonly IHubContext<ChatHubV2> _hubContext;

    public MessagingService(IHubContext<ChatHubV2> hubContext)
    {
        _hubContext = hubContext;
    }

    protected async Task Send<TMessage>(IEnumerable<string> connections, string methodName, TMessage objectToSend)
    {
        await _hubContext.Clients.Clients(connections).SendAsync(methodName, objectToSend);
    }
}