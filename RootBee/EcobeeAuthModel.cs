using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootBee
{
    class EcobeeAuthModel
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
}
