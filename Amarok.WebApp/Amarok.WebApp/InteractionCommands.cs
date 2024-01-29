using Discord.Interactions;

namespace Amarok.WebApp.Server
{
    public class InteractionCommands : InteractionModuleBase
    {
        private readonly InteractionService _interactionService;
        public InteractionCommands(InteractionService interactionService)
        {
            _interactionService = interactionService;
        }
    }
}
