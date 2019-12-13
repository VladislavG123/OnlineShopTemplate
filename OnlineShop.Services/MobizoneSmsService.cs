using OnlineShop.DTO;
using OnlineShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public class MobizoneSmsService : ISmsService
    {
        public async Task<SmsServiceResponseDTO> SendVerificationCode(string phoneNumber, string code)
        {
            string url = $"https://api.mobizon.kz/service/message/sendsmsmessage?" +
                $"recipient={phoneNumber}&text=Code: {code}" +
                $"&apiKey=kz739b92e1907f9680a0b71e3851ab59dcec2c26af77d8ee39876b18483fa5b232126f";

            using (var webClient = new WebClient())
            {
                webClient.DownloadStringAsync(new System.Uri(url));
                var response = new SmsServiceResponseDTO();
                response.StatusCode = 200;
                return response;
            }

        }
    }
}
