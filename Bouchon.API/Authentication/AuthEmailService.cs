using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bouchon.API.Authentication
{
    public class AuthEmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            //await configSendGridasync(message);

            dynamic email = new Email("AuthMailTemplate");
            email.To = message.Destination;
            email.From = "hello@annufal.com";
            email.Subject = message.Subject;
            email.Body = message.Body;

            email.SendAsync();
        }
    }
}