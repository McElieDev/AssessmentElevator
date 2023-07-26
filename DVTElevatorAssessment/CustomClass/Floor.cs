using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTElevatorAssessment.CustomClass
{
    /// <summary>
    /// This class represents a floor with its floor number. It is a simple class with no specific behavior.
    /// </summary>
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
