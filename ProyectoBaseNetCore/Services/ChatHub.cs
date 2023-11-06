using Microsoft.AspNetCore.SignalR;

namespace ProyectoBaseNetCore.Services
{
    public class ChatHub : Hub
    {
        public async Task EnviarMensaje(string usuario, string mensaje)
        {
            await Clients.All.SendAsync("RecibirMensaje", usuario, mensaje);
        }

        public async Task EnviarMensajeAUsuario(string usuarioDestino, string contenido)
        {
            await Clients.User(usuarioDestino).SendAsync("RecibirMensaje", contenido);
        }

        public async Task AgregarUsuarioAlGrupo(string usuario, string groupName)
        {
            string connectionId = Context.ConnectionId;

            await Groups.AddToGroupAsync(connectionId, groupName);
        }

        private static readonly Dictionary<string, HashSet<string>> UserConnections = new Dictionary<string, HashSet<string>>();

        public override async Task OnConnectedAsync()
        {
            string username = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            if (!UserConnections.ContainsKey(username))
            {
                UserConnections[username] = new HashSet<string>();
            }

            UserConnections[username].Add(connectionId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string username = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            if (UserConnections.ContainsKey(username))
            {
                UserConnections[username].Remove(connectionId);
                if (UserConnections[username].Count == 0)
                {
                    UserConnections.Remove(username);
                }
            }

            await base.OnDisconnectedAsync(exception);
        }

        public static bool IsUserConnected(string username)
        {
            return UserConnections.ContainsKey(username) && UserConnections[username].Count > 0;
        }
    }
}