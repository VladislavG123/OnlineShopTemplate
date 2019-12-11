using OnlineShop.DTO;
using OnlineShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace OnlineShop.Services
{
    public class TwilioSmsService : ISmsService
    {
        public Task<SmsServiceResponseDTO> SendVerificationCode(string phoneNumber, string code)
        {
            const string accountSid = "ACa902f79f4063bfa4e4da8b2930f931b2";
            const string authToken = "55ce5d687fbdf981f550141835655fbf";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Code: " + code,
                from: new Twilio.Types.PhoneNumber("+12056198687"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );


            return Task.FromResult(new SmsServiceResponseDTO { StatusCode = 200, Message = "Сообщение успешно отправлено" });
        }
    }
}
