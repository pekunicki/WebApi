using System;
using Client.Models.CLI;
using Client.Services;
using Client.Utils;
using RestSharp;

namespace Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var authService = new AccountService();
            var user = CLIHandler.CreateNewUser();

            var registerResponse = authService.Register(user.Username, user.Password);
            if (!VerifyResponse(registerResponse, Messages.SuccessRegistrationMsg))
            {
                Console.ReadKey();
                return;
            }
            var loginResponse = authService.Login(user.Username, user.Password);
            if (!VerifyResponse(loginResponse, Messages.SuccessLoginMsg))
            {
                Console.ReadKey();
                return;
            }
            var changePasswordResponse = ChangePassword(loginResponse.Data.AuthToken, authService, user);
            if (VerifyResponse(changePasswordResponse, Messages.SuccessChangePasswordMsg))
            {
                Console.ReadKey();
                return;
            }

            Console.ReadKey();
        }

        private static IRestResponse ChangePassword(string accessToken, AccountService authService, User user)
        {
            var newPassword = CLIHandler.CreateNewPassword();
            var response = authService.ChangePassword(user.Password, newPassword.NewPassword, accessToken);
            return response;
        }

        private static bool VerifyResponse(IRestResponse response, string message)
        {
            if (response.IsSuccessful)
            {
                Logger.LogSuccess(message);
                return true;
            }
            var errorMessage = string.IsNullOrWhiteSpace(response.Content) ? response.ErrorMessage : response.Content;
            Logger.LogError(errorMessage);
            return false;
        }
    }
}