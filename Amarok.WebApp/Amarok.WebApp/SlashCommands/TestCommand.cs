using Discord;
using Discord.Net;
using Newtonsoft.Json;

namespace Amarok.WebApp.Server.SlashCommands
{
    public class TestCommand
    {
        private readonly string name = "test-command";
        private readonly string description = "This is a test command";
        public SlashCommandBuilder CommandBuilder { get; set; }

        public TestCommand()
        {
            SlashCommandBuilder guildCommand = new();
            guildCommand.WithName(name);
            guildCommand.WithDescription(description);

            CommandBuilder = guildCommand;
        }

        public async Task Build(IGuild guild, SlashCommandBuilder command)
        {
            try
            {
                await guild.CreateApplicationCommandAsync(command.Build());
            }
            catch (HttpException exception)
            {
                // If our command was invalid, we should catch an ApplicationCommandException. This exception contains the path of the error as well as the error message. You can serialize the Error field in the exception to get a visual of where your error is.
                string json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);

                // You can send this error somewhere or just print it to the console, for this example we're just going to print it.
                Console.WriteLine(json);
            }
        }
    }
}
