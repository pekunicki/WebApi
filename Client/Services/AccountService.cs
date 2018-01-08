using System;
using Client.Models;
using Client.Utils;
using RestSharp;
using RestSharp.Serializers.Newtonsoft.Json;
using RestRequest = RestSharp.RestRequest;

namespace Client.Services
{
    internal class AccountService
    {
        private readonly RestClient _restClient;

        public AccountService()
        {
            _restClient = new RestClient(Settings.BaseUrl);
        }

        public IRestResponse<TokenResponse> Login(string email, string pass)
        {
            var request = new RestRequest("token", Method.POST);
            CreateLoginRequest(email, pass, request);

            var response = _restClient.Execute<TokenResponse>(request);
            LogNewRequest(request.Resource);

            return response;
        }

        public IRestResponse Register(string email, string pass)
        {
            var request = CreateJsonRestRequest("api/Account/Register", Method.POST);
            var body = CreateRegisterRequest(email, pass);
            request.AddBody(body);

            var response = SendSimpleRequest(request);

            return response;
        }

        public IRestResponse ChangePassword(string oldPassword, string newPassword, string accessToken)
        {
            var request = CreateJsonRestRequest("api/Account/ChangePassword", Method.POST);
            var body = CreateChangePasswordRequest(oldPassword, newPassword);
            request.AddHeader("Authorization", $"bearer {accessToken}");
            request.AddBody(body);

            var response = SendSimpleRequest(request);

            return response;
        }

        private IRestResponse SendSimpleRequest(RestRequest request)
        {
            var response = _restClient.Execute(request);
            LogNewRequest(request.Resource);
            return response;
        }

        private void LogNewRequest(string endpoint)
        {
            Logger.LogNewInfo($"{DateTime.UtcNow.ToShortTimeString()} - New Request has been sent on /{endpoint}");
        }

        private static RestRequest CreateJsonRestRequest(string endpoint, Method httpMethod)
        {
            return new RestRequest(endpoint, httpMethod)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new NewtonsoftJsonSerializer()
            };
        }

        private static void CreateLoginRequest(string email, string pass, RestRequest request)
        {
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", email);
            request.AddParameter("password", pass);
        }

        private ChangePasswordRequest CreateChangePasswordRequest(string oldPassword, string newPassword)
        {
            return new ChangePasswordRequest
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = newPassword
            };
        }

        private static RegisterRequest CreateRegisterRequest(string email, string pass)
        {
            return new RegisterRequest
            {
                Email = email,
                Password = pass,
                ConfirmPassword = pass
            };
        }
    }
}