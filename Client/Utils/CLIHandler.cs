using System;
using Client.Models.CLI;

namespace Client.Utils
{
    internal class CLIHandler
    {
        internal static ChangePassword CreateNewPassword()
        {
            Logger.LogInfo("Wprowadz nowe haslo dla uzytkownika");
            var password = Console.ReadLine();
            return new ChangePassword
            {
                NewPassword = password
            };
        }

        internal static User CreateNewUser()
        {
            Logger.LogInfo("Wprowadz email nowego uzytkownika");
            var username = Console.ReadLine();
            Logger.LogInfo("Podaj haslo nowego uzytkownika");
            var password = Console.ReadLine();
            return new User
            {
                Username = username,
                Password = password
            };
        }
    }
}