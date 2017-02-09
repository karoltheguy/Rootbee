using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootBee
{
    class EcobeeAPIPin
    {
        //{
        //    "ecobeePin": "p73j",
        //    "code": "eyoa33KSHWUv9ooKVM9oCqMUaUJ3QNKT",
        //    "scope": "smartWrite",
        //    "expires_in": 9,
        //    "interval": 30
        //}

        public string ecobeePin { get; set; }
        public string code { get; set; }
        public string scope { get; set; }
        public string expires_in { get; set; }
        public string interval { get; set; }
    }

    class EcobeeTokenRefresh
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


}
