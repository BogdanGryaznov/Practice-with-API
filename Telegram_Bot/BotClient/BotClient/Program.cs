using Domain.Models;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotClient
{
    internal class Program
    {

        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message) 
            {
                return;
            }
            if(message.Text is not { } messageText)
            {
                return;
            }
            var chatId = message.Chat.Id;

            Console.WriteLine($"Recieved a '{messageText}' message in a chat {chatId}.");

            //Ответить на сообщение
            Message sentmessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You said:\n" + messageText,
                cancellationToken: cancellationToken
                );

            if(message.Text == "Проверка")
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Куплю гараж!!",
                    cancellationToken: cancellationToken
                    );
            }
            else
            if(message.Text.ToLower() == "привет")
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"Здравствуй, {message.Chat.FirstName}",
                    cancellationToken: cancellationToken
                    );
            }
            if (message.Text.ToLower() == "картинка")
            {
                await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: InputFile.FromUri("https://github.com/BogdanGryaznov/Practice-with-API/assets/124984105/ea96bd84-0fee-4f6c-b2a9-bae0e4753504"),
                    caption: "Лови фотокарточку!",
                    cancellationToken: cancellationToken
                    );
            }
            if (message.Text.ToLower() == "видео")
            {
                await using Stream stream = System.IO.File.OpenRead("C:/Users/user/Downloads/internet_yamero.mp4");
                await botClient.SendVideoAsync(
                    chatId: chatId,
                    video: InputFile.FromStream(stream),
                    cancellationToken: cancellationToken
                    );
            };
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}" + exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");



            //  ___  ______ _____      _____ _   _ ___________   _____ _____ _____ _____ 
            // / _ \ | ___ \_   _|    /  ___| | | |  _  | ___ \ |_   _|  ___/  ___|_   _|
            /// /_\ \| |_/ / | |______\ `--.| |_| | | | | |_/ /   | | | |__ \ `--.  | |  
            //|  _  ||  __/  | |______|`--. \  _  | | | |  __/    | | |  __| `--. \ | |  
            //| | | || |    _| |_     /\__/ / | | \ \_/ / |       | | | |___/\__/ / | |  
            //\_| |_/\_|    \___/     \____/\_| |_/\___/\_|       \_/ \____/\____/  \_/  

            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:7178/api/User");
            Console.WriteLine(result);

            var test = await result.Content.ReadAsStringAsync();
            Console.WriteLine(test);

            Domain.Models.User[] users = JsonConvert.DeserializeObject<Domain.Models.User[]>(test);

            foreach(var user in users)
            {
                Console.WriteLine($"{user.IdUser} {user.Login} {user.Password} {user.RoleId} {user.Address} {user.IsDeleted}");
            }


            
            // _____ _____ _      _____ _____ ______  ___  ___  ___ ______  _____ _____ 
            //|_   _|  ___| |    |  ___|  __ \| ___ \/ _ \ |  \/  | | ___ \|  _  |_   _|
            //  | | | |__ | |    | |__ | |  \/| |_/ / /_\ \| .  . | | |_/ /| | | | | |  
            //  | | |  __|| |    |  __|| | __ |    /|  _  || |\/| | | ___ \| | | | | |  
            //  | | | |___| |____| |___| |_\ \| |\ \| | | || |  | | | |_/ /\ \_/ / | |  
            //  \_/ \____/\_____/\____/ \____/\_| \_\_| |_/\_|  |_/ \____/  \___/  \_/  
                                                                          

            var botClient = new TelegramBotClient("6051001460:AAF3TbsLm3l1rEvdmZZ7jjD28tj1zjD4VB8");
            using CancellationTokenSource cts = new();

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
                );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            cts.Cancel();
        }
    }
}