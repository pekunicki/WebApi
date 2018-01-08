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

        internal static User CreateUser(bool isNew)
        {
            var emailMsg = isNew ? Messages.InputNewEmail : Messages.InputEmail;
            Logger.LogInfo(emailMsg);
            var username = Console.ReadLine();

            var passMsg = isNew ? Messages.InputNewPassword : Messages.InputPassword;
            Logger.LogInfo(passMsg);
            var password = Console.ReadLine();

            return new User
            {
                Username = username,
                Password = password
            };
        }
    }
}