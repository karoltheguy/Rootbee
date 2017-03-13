using EcobeeLibUWP.Protocol.Thermostat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootBeeTest
{
    class GetThermostatInfoTest
    {
        public void GetTempTest()
        {
            var request = new ThermostatSummaryRequest
            {
                Selection = new EcobeeLibUWP.Protocol.Objects.Selection
                {
                    SelectionType = "registered"
                }
            };

            //var response = client.Get<ThermostatSummaryRequest, ThermostatSummaryResponse>(request).Result;
        }
    }
}
