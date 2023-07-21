using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DVTElevatorAssessment.CustomClass
{
    public class ElevatorController
    {
        private readonly List<Elevator> elevators;
        private readonly List<Floor> floors;

        public IReadOnlyList<Elevator> Elevators => elevators;

        public int FloorCount => floors.Count;

        public ElevatorController(int elevatorCount, int floorCount, int elevatorCapacity, int elevatorWeightLimit)
        {
            elevators = new List<Elevator>();
            for (int i = 0; i < elevatorCount; i++)
            {
                elevators.Add(new Elevator(elevatorCapacity, elevatorWeightLimit));
            }

            floors = new List<Floor>();
            for (int i = 1; i <= floorCount; i++)
            {
                floors.Add(new Floor(i));
            }
        }

        public Elevator GetNearestAvailableElevator(int floorNumber)
        {
            // Find the nearest available elevator based on the floor number and direction...
            return elevators.Find(elevator => elevator.IsAvailable());
        }

        public void CallElevator(int floorNumber)
        {
            var elevator = GetNearestAvailableElevator(floorNumber);
            if (elevator != null)
            {
                int peopleWaiting = floors[floorNumber - 1].PeopleWaiting;
                if (elevator.CurrentWeight + (peopleWaiting * Elevator.PersonWeight) <= elevator.WeightLimit)
                {
                    elevator.MoveToFloor(floorNumber);
                    elevator.AddPeople(peopleWaiting);
                    floors[floorNumber - 1].PeopleWaiting = 0;
                }
                else
                {
                    WriteLine("Elevator weight limit exceeded. Cannot call the elevator.");
                }
            }
        }

        public void SetPeopleWaiting(int floorNumber, int peopleCount)
        {
            if (floorNumber > 0 && floorNumber <= floors.Count)
            {
                floors[floorNumber - 1].PeopleWaiting = peopleCount;
            }
        }

        public void DisplayElevatorStatus()
        {
            for (int i = 0; i < elevators.Count; i++)
            {
                var elevator = elevators[i];
                WriteLine($"Elevator {i + 1}:");
                WriteLine($"Current Floor: {elevator.CurrentFloor}");
                WriteLine($"Direction: {elevator.CurrentDirection}");
                WriteLine($"Is Moving: {elevator.IsMoving}");
                WriteLine($"People Count: {elevator.PeopleCount}");
                WriteLine($"Current Weight: {elevator.CurrentWeight}");
                WriteLine();
            }
        }
    }
}
