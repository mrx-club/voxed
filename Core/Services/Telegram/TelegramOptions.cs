namespace Core.Services.Telegram
{
    public class TelegramOptions
    {
        public const string SectionName = "Telegram";

        public string Token { get; init; }
        public string ChatId { get; init; }
    }
}
