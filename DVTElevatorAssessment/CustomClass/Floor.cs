using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTElevatorAssessment.CustomClass
{
    public class Floor
    {
        public int FloorNumber { get; }
        public int PeopleWaiting { get; set; }

        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
            PeopleWaiting = 0;
        }
    }
}
