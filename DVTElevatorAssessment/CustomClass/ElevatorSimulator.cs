using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DVTElevatorAssessment.CustomClass
{
	/// <summary>
	/// This class contains the Main method that runs the elevator and all its processes.
	/// </summary>
	public class ElevatorSimulator
	{
		public readonly ElevatorController elevatorController;

	   public ElevatorSimulator(int elevatorCount, int floorCount, int elevatorCapacity, int elevatorWeightLimit)
		{
			elevatorController = new ElevatorController(elevatorCount, floorCount, elevatorCapacity, elevatorWeightLimit);
		}

		/// <summary>
        /// The Main Method or Run Method to start the Elevator Simulator
        /// </summary>
        /// <param name="args"></param>
		public void Main(string[] args)
		{
		   while (true)
			{
				Console.WriteLine("Enter the floor number to call the elevator (1 to 5), or 0 to exit:");
				if (!int.TryParse(Console.ReadLine(), out int floorNumber) || (floorNumber < 0 || floorNumber > elevatorController.FloorCount))
				{
					Console.WriteLine("Invalid input! Please enter a valid floor number.");
					continue;
				}

				if (floorNumber == 0)
					break;

				Console.WriteLine($"Enter the number of people waiting on floor {floorNumber}:");
				if (!int.TryParse(Console.ReadLine(), out int peopleCount) || peopleCount < 0)
				{
					Console.WriteLine("Invalid input! Please enter a valid number of people.");
					continue;
				}

				elevatorController.CallElevator(floorNumber, peopleCount);

				Console.WriteLine("\nElevator Status:");
				elevatorController.DisplayElevatorStatus();
			}
		}
	}
}
