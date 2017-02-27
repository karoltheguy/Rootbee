using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RootBee.Protocols
{
    class Selection
    {

        /// <summary>
        /// The type of match data supplied: Values: none, thermostats, user, managementSet.
        /// </summary>
        [DataMember(Name = "selectionType")]
        public String selectionType { get; set; }
        
        /// <summary>
        /// The match data based on selectionType (e.g. a list of thermostat idendifiers in the case of a selectionType of thermostats)
        /// </summary>
        [DataMember(Name = "selectionMatch")]
        public String selectionMatch { get; set; }
        
        /// <summary>
        /// Include the thermostat runtime object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeRuntime")]
        public Boolean includeRuntime { get; set; }
        
        /// <summary>
        /// Include the extended thermostat runtime object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeExtendedRuntime")]
        public Boolean includeExtendedRuntime { get; set; }
        
        /// <summary>
        /// Include the electricity readings object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeElectricity")]
        public Boolean includeElectricity { get; set; }
        
        /// <summary>
        /// Include the thermostat settings object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeSettings")]
        public Boolean includeSettings { get; set; }
        
        /// <summary>
        /// Include the thermostat location object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeLocation")]
        public Boolean includeLocation { get; set; }
        
        /// <summary>
        /// Include the thermostat program object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeProgram")]
        public Boolean includeProgram { get; set; }
        
        /// <summary>
        /// Include the thermostat calendar events objects. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeEvents")]
        public Boolean includeEvents { get; set; }
        
        /// <summary>
        /// Include the thermostat device configuration objects. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeDevice")]
        public Boolean includeDevice { get; set; }
        
        /// <summary>
        /// Include the thermostat technician object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeTechnician")]
        public Boolean includeTechnician { get; set; }
        
        /// <summary>
        /// Include the thermostat utility company object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeUtility")]
        public Boolean includeUtility { get; set; }
        
        /// <summary>
        /// Include the thermostat management company object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeManagement")]
        public Boolean includeManagement { get; set; }
        
        /// <summary>
        /// Include the thermostat's unacknowledged alert objects. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeAlerts")]
        public Boolean includeAlerts { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "includeReminders")]
        public Boolean includeReminders { get; set; }
        
        /// <summary>
        /// Include the current thermostat weather forecast object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeWeather")]
        public Boolean includeWeather { get; set; }
        
        /// <summary>
        /// Include the current thermostat house details object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeHouseDetails")]
        public Boolean includeHouseDetails { get; set; }
        
        /// <summary>
        /// Include the current thermostat OemCfg object. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeOemCfg")]
        public Boolean includeOemCfg { get; set; }
        
        /// <summary>
        /// Include the current thermostat equipment status information. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeEquipmentStatus")]
        public Boolean includeEquipmentStatus { get; set; }
        
        /// <summary>
        /// Include the current thermostat alert and reminders settings. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeNotificationSettings")]
        public Boolean includeNotificationSettings { get; set; }
        
        /// <summary>
        /// Include the current thermostat privacy settings. Note: access to this object is restricted to callers with implict authentication, setting this value to true without proper credentials will result in an authentication exception.
        /// </summary>
        [DataMember(Name = "includePrivacy")]
        public Boolean includePrivacy { get; set; }
        
        /// <summary>
        /// Include the current firmware version the Thermostat is running. If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeVersion")]
        public Boolean includeVersion { get; set; }
        
        /// <summary>
        /// Include the current securitySettings object for the selected Thermostat(s). If not specified, defaults to false.
        /// </summary>
        [DataMember(Name = "includeSecuritySettings")]
        public Boolean includeSecuritySettings { get; set; }
        
        /// <summary>
        /// Include the list of current thermostatRemoteSensor objects for the selected Thermostat(s). If not specified, defaults to false. 
        /// </summary>
        [DataMember(Name = "includeSensors")]
        public Boolean includeSensors { get; set; }
    }
}
