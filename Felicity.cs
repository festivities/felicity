using Discord;
using Discord.WebSocket;
using System.Threading.Channels;
using felicity.Services;

internal class Felicity {
    public static DiscordSocketClient _client;

    public static readonly string token = File.ReadAllText("C:\\Users\\fes\\dev\\repositories\\felicity\\token.txt");
    public const ulong userID = 1059326067791376424ul;
    public const ulong generalChan = 1063456558643695656ul;
    //public const ulong renderChan = 895185772188147722ul;
    public const ulong renderChan = 1162759175516983389ul;

    private Task ReadyAsync() {
        Console.WriteLine($"{0} is connected!", _client.CurrentUser);
        return Task.CompletedTask;
    }

    private Task LogAsync(LogMessage msg) {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    public async Task MainAsync() {
        _client = new DiscordSocketClient();

        _client.Ready += ReadyAsync;
        _client.Log += LogAsync;

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        _client.MessageReceived += Messaging.receiveMessage;

        await Task.Delay(-1);
    }

    public static Task Main(string[] args) => new Felicity().MainAsync();
}
