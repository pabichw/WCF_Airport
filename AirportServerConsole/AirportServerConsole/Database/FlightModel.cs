using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirportServerConsole.Database
{
    [DataContract]
    public class Flight
    {
        [DataMember]
        private string citySource;
        [DataMember]
        private string cityTarget { get; set; }
        [DataMember]
        private DateTime timeDeparture { get; set; }
        [DataMember]
        private DateTime timeArrive { get; set; }

        public Flight(string citySource, string cityTarget, DateTime timeDeparture, DateTime timeArrive)
        {
            this.citySource = citySource;
            this.cityTarget = cityTarget;
            this.timeDeparture = timeDeparture;
            this.timeArrive = timeArrive;
        }
        public string getCitySource() { return citySource; }
        public string getCityTarget() { return cityTarget; }
        public DateTime getTimeDeparture() { return timeDeparture; }
        public DateTime getTimeArrive() { return timeArrive; }

    }
}
