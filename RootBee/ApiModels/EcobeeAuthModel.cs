using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootBee
{
    public class EcobeeAPIPin
    {
        //{
        //    "ecobeePin": "p73j",
        //    "code": "eyoa33KSHWUv9ooKVM9oCqMUaUJ3QNKT",
        //    "scope": "smartWrite",
        //    "expires_in": 9,
        //    "interval": 30
        //}
        
        /// <summary>
        /// Activation PIN
        /// </summary>
        public string ecobeePin { get; set; }
        public string code { get; set; }
        public string scope { get; set; }
        public string expires_in { get; set; }
        public string interval { get; set; }
    }

    public class EcobeeTokenRefresh
    {
        //{
        //    "access_token": "Rc7JE8P7XUgSCPogLOx2VLMfITqQQrjg",
        //    "token_type": "Bearer",
        //    "expires_in": 3599,
        //    "refresh_token": "og2Obost3ucRo1ofo0EDoslGltmFMe2g",
        //    "scope": "smartWrite" 
        //}



        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }

    }

    public class EcobeeError
    {
        //{
        //    "error": "authorization_pending",
        //    "error_description": "Waiting for user to authorize application.",
        //    "error_uri": "https://tools.ietf.org/html/rfc6749#section-5.2"
        //}

        //    "error": "invalid_grant",
        //    "error_description": "The authorization grant, token or credentials are invalid, expired, revoked, do not match the redirection URI used in the authorization request, or was issued to another client.",
        //    "error_uri": "https://tools.ietf.org/html/rfc6749#section-5.2"

        public string error { get; set; }
        public string error_description { get; set; }
        public string error_uri { get; set; }
    }

}
