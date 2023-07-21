using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DVTElevatorAssessment.CustomClass
{
    public class ElevatorSimulator
    {
        public readonly ElevatorController elevatorController;

        public ElevatorSimulator(int elevatorCount, int floorCount, int elevatorCapacity, int elevatorWeightLimit)
        {
            elevatorController = new ElevatorController(elevatorCount, floorCount, elevatorCapacity, elevatorWeightLimit);
        }

        public void Run()
        {
            while (true)
            {
                WriteLine("Enter Floor number to call the elevator (1 to 5), or 0 to exit:");
                if (!int.TryParse(ReadLine(), out int floorNumber) || (floorNumber < 0 || floorNumber > elevatorController.FloorCount))
                {
                    WriteLine("Invalid value! Please enter a valid floor number.");
                    continue;
                }

                if (floorNumber == 0)
                    break;

                WriteLine($"Enter Number of people waiting on floor {floorNumber}:");
                if (!int.TryParse(ReadLine(), out int peopleCount) || peopleCount > 10)
                {
                    WriteLine("Invalid value! Please enter a valid number of people less than 10 (people per Elevator).");
                    continue;
                }

                elevatorController.SetPeopleWaiting(floorNumber, peopleCount);
                elevatorController.CallElevator(floorNumber);

                WriteLine("\nElevator Status:");
                elevatorController.DisplayElevatorStatus();
            }
        }
    }
}
