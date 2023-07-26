using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DVTElevatorAssessment.CustomClass
{
	/// <summary>
	///  This Class implements the IElevatorController interface. 
	///  It manages the elevators and floors, handles elevator calls, and provides a way to display the elevator status. 
	///  The elevator controller maintains a list of elevators and floors.
	/// </summary>
	public class ElevatorController : IElevatorController
	{
		private readonly List<Elevator> elevators;
		private readonly List<Floor> floors;
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

	   private Elevator GetNearestAvailableElevator(int floorNumber)
		{
			return elevators.Find(elevator => elevator.IsAvailableForPeople(floors[floorNumber - 1].PeopleWaiting));
		}
		/// <summary>
        /// 
        /// </summary>
        /// <param name="floorNumber">Number of the Floor</param>
        /// <param name="peopleWaiting">Number of the People waiting for the Elevator</param>
		public void CallElevator(int floorNumber, int peopleWaiting)
		{
			if (floorNumber < 1 || floorNumber > floors.Count)
			{
				Console.WriteLine("Invalid floor number.");
				return;
			}

			if (peopleWaiting < 0)
			{
				Console.WriteLine("Invalid number of people waiting on the floor.");
				return;
			}

			var elevator = GetNearestAvailableElevator(floorNumber);
			if (elevator == null)
			{
				Console.WriteLine("No available elevator to handle the request.");
				return;
			}

			if (!elevator.IsAvailableForPeople(peopleWaiting))
			{
				Console.WriteLine("Elevator weight limit exceeded. Cannot call the elevator.");
				return;
			}

			elevator.MoveToFloor(floorNumber);
			elevator.AddPeople(peopleWaiting);
			floors[floorNumber - 1].PeopleWaiting = 0;
		}
		/// <summary>
        /// Method that displays the Elevator Status message
        /// </summary>
		public void DisplayElevatorStatus()
		{
			for (int i = 0; i < elevators.Count; i++)
			{
				var elevator = elevators[i];
				Console.WriteLine($"Elevator {i + 1}:");
				Console.WriteLine($"Current Floor: {elevator.CurrentFloor}");
				Console.WriteLine($"Direction: {elevator.CurrentDirection}");
				Console.WriteLine($"Is Moving: {elevator.IsMoving}");
				Console.WriteLine($"People Count: {elevator.PeopleCount}");
				Console.WriteLine($"Current Weight: {elevator.CurrentWeight}");
				Console.WriteLine();
			}
		}
	}
}
