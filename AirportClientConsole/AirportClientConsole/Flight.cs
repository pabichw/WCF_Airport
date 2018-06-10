using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirPortsdasdasdasdasd
{
    public class Flight
    {
        [DataMember]
        private string citySource { get; set; }
        [DataMember]
        private string cityTarget { get; set; }
        [DataMember]
        private string timeDeparture { get; set; }
        [DataMember]
        private string timeArrive { get; set; }

        public Flight(string citySource, string cityTarget, string timeDeparture, string timeArrive)
        {
            this.citySource = citySource;
            this.cityTarget = cityTarget;
            this.timeDeparture = timeDeparture;
            this.timeArrive = timeArrive;
        }
    }
}
