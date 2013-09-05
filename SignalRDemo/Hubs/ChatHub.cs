using Microsoft.AspNet.SignalR;

namespace SignalRDemo.Hubs
{
    public class ChatHub : Hub
    {
        public override System.Threading.Tasks.Task OnConnected()
        {
          Clients.Others.MessageIsReceived("Client with ID" + Context.ConnectionId + " joined the chat");
          return base.OnConnected();
        }

        /// <summary>
        /// Method that can be called from the clients
        /// </summary>
        /// <param name="message"></param>
        public void NewMessage(string message)
        {
            // Send a message to all connected clients
            Clients.All.MessageIsReceived(message);
        }


        public void OtherWaysToTargetSpecificClients()
        {
            // Send message to everyone except the client that send the message to the server
            Clients.Others.ShowAlert("Watch out!");

            // Send messages to specific group 
            Clients.Group("Admins").DoSomethingAdminny();

            // Send message to the client that send the message to the server
            Clients.Caller.IncrementCounter();
        }
    }
}