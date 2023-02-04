﻿using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Core.Services.Telegram
{
    public interface ITelegramService
    {
        Task<Message> SendMessage(string message);
        Task UploadFile(Stream file);
    }

    public class TelegramService : ITelegramService
    {
        private readonly TelegramOptions _config;
        private readonly TelegramBotClient _client;

        public TelegramService(IOptions<TelegramOptions> options)
        {
            _config = options.Value;
            _client = new TelegramBotClient(_config.Token);

            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };

            //_client.StartReceiving(
            //    HandleUpdateAsync,
            //    HandleErrorAsync,
            //    receiverOptions,
            //    cancellationToken: cts.Token);
        }

        public async Task<Message> SendMessage(string message)
        {
            try
            {
                return await _client.SendTextMessageAsync(_config.ChatId, message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Type != UpdateType.Message)
                return;
            // Only process text messages
            if (update.Message!.Type != MessageType.Text)
                return;

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            // Echo received message text
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You said:\n" + messageText,
                cancellationToken: cancellationToken);
        }

        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        public async Task UploadFile(Stream file)
        {
            var msg = await _client.SendDocumentAsync(_config.ChatId, new InputOnlineFile(file, "img.jpg"));
            Debug.WriteLine(msg.Document.FileId);
        }
    }
}
