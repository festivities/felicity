using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services {
    internal class Messaging {
        public static async Task receiveMessage(SocketMessage message) {
            IMessageChannel renderChan = Felicity._client.GetChannel(Felicity.renderChan) as IMessageChannel;

            if(message.Channel.Id != renderChan.Id || message.Author.IsBot) return;
            if(message.Attachments.Any() || message.Embeds.Any()) return;

            // message violates the festive rule
            await message.DeleteAsync();
            IUserMessage deleteThis = await renderChan.SendMessageAsync("Please do not chat in this channel!");
            await Task.Delay(3500);
            await deleteThis.DeleteAsync();

            return;
        }
    }
}
