using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felicity.Services {
    internal class Messaging {
        public static Task receiveMessage(SocketMessage message) {
            IMessageChannel renderChan = Felicity._client.GetChannel(Felicity.renderChan) as IMessageChannel;

            if(message.Channel.Id != renderChan.Id || message.Author.IsBot) return Task.CompletedTask;
            if(message.Attachments.Any()) {
                foreach(Attachment attachment in message.Attachments) Console.WriteLine(attachment.Filename);
                Console.WriteLine("fuck you");
                return Task.CompletedTask;
            }

            message.Channel.SendMessageAsync(":joy:");

            return Task.CompletedTask;
        }
    }
}
