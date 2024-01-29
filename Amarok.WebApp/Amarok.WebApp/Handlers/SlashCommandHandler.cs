using Discord.WebSocket;

namespace Amarok.WebApp.Server.Handlers
{
    public class SlashCommandHandler
    {
        private readonly DiscordSocketClient _client;
        public SlashCommandHandler(DiscordSocketClient client)
        {
            _client = client;
            client.SlashCommandExecuted += Client_SlashCommandHandler;
        }

        private async Task Client_SlashCommandHandler(SocketSlashCommand command)
        {
            await command.RespondAsync($"You executed {command.Data.Name}");
        }
    }
}
