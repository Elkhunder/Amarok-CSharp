﻿using System.Web;
using Discord;
using Discord.WebSocket;

namespace Amarok.WebApp.Server.Services
{
    public class DiscordService : BackgroundService
    {
        private DiscordSocketClient _client { get; set; }
        private ILogger<DiscordService> _logger;
        private readonly IConfiguration _configuration;

        public DiscordService(ILogger<DiscordService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _client = new DiscordSocketClient();

            _logger.LogInformation("Discord Service Initialized");
        }
            

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(DiscordService)} is running");
            _client.Log += _client_Log;
            _client.Ready += _client_Ready;
            _client.Disconnected += _client_Disconnected;
            _client.Connected += _client_Connected;
            await _client.LoginAsync(Discord.TokenType.Bot, _configuration["Discord:Development_Token"]);
            await _client.StartAsync();
        }

        private Task _client_Connected()
        {
            _logger.LogInformation($"{nameof(_client)} connected");
            return Task.CompletedTask;
        }

        private Task _client_Disconnected(Exception arg)
        {
            _logger.LogInformation($"{arg.Message}");
            return Task.CompletedTask;
        }

        private Task _client_Ready()
        {
            _logger.LogInformation($"{nameof(_client)} Ready!");
            return Task.CompletedTask;
        }

        private Task _client_Log(LogMessage message)
        {
            _logger.LogInformation(message.ToString());

            return Task.CompletedTask;
        }
    }
}
