using System;
using Client.Models.CLI;

namespace Client.Utils
{
    internal class CLIHandler
    {
        internal static ChangePassword CreateNewPassword()
        {
            Logger.LogInfo(Messages.InputChangePassword);
            var password = Console.ReadLine();
            return new ChangePassword
            {
                NewPassword = password
            };
        }

        internal static User CreateUser()
        {
            Logger.LogInfo(Messages.InputNewEmail);
            var username = Console.ReadLine();

            Logger.LogInfo(Messages.InputNewPassword);
            var password = Console.ReadLine();

            return new User
            {
                Username = username,
                Password = password
            };
        }
    }
}