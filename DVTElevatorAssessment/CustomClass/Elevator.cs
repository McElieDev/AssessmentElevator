using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DVTElevatorAssessment.CustomClass
{
	/// <summary>
	/// This Class represents an elevator with its current floor, direction, capacity, weight limit, people count, and current weight. 
	/// 1. It contains methods to move the elevator to a specified floor, 
	/// 2. check if it's available for people, 
	/// 3. and add or remove people.
	/// </summary>
	public class Elevator
	{
		// Assume 70 kg as Average weight
		public const int PersonWeight = 70;

		public int CurrentFloor { get; private set; }
		public bool IsMoving { get; private set; }
		public Direction CurrentDirection { get; private set; }
		public int Capacity { get; }
		public int WeightLimit { get; }
		public int PeopleCount { get; private set; }
		public int CurrentWeight { get; private set; }

		public Elevator(int capacity, int weightLimit)
		{
			Capacity = capacity;
			WeightLimit = weightLimit;
			CurrentFloor = 1;
			CurrentDirection = Direction.Idle;
			IsMoving = false;
			PeopleCount = 0;
			CurrentWeight = 0;
		}
		/// <summary>
		/// Focuses on Moving the Elevator to the specific floor like Up or Down direction
		/// </summary>
		/// <param name="floorNumber"> Floor Number input by the user</param>
		public void MoveToFloor(int floorNumber)
		{
			 if (IsMoving)
			{
				return; // Elevator is already moving
			}
		   IsMoving = true;
			CurrentDirection = floorNumber > CurrentFloor ? Direction.Up : Direction.Down;

			while (CurrentFloor != floorNumber)
			{
				if (CurrentDirection == Direction.Up)
				{
					CurrentFloor++;
				}
				else if (CurrentDirection == Direction.Down)
				{
					CurrentFloor--;
				}

				Console.WriteLine($"Elevator is moving to floor {CurrentFloor}");
			}

			IsMoving = false;
			CurrentDirection = Direction.Idle;
		}
		
		/// <summary>
		/// This Method check if the Elevator is available for people
		/// </summary>
		/// <param name="peopleCount">Number of people</param>
		/// <returns></returns>
		 public bool IsAvailableForPeople(int peopleCount)
		{
			int totalWeight = CurrentWeight + (peopleCount * PersonWeight);
			return !IsMoving && PeopleCount + peopleCount <= Capacity && totalWeight <= WeightLimit;
		}

		/// <summary>
		/// Method, Add the Number of People on the Elevator
		/// </summary>
		/// <param name="peopleCount">Number of People</param>
		public void AddPeople(int peopleCount)
		{
			if (IsAvailableForPeople(peopleCount))
			{
				PeopleCount += peopleCount;
				CurrentWeight += peopleCount * PersonWeight;
			}
			else
			{
				Console.WriteLine("Elevator is at capacity. Cannot add more people.");
			}
		}

		/// <summary>
        /// THis Method Remove the people in the elevator
        /// </summary>
        /// <param name="peopleCount">Number of People</param>
		public void RemovePeople(int peopleCount)
		{
			  if (PeopleCount - peopleCount >= 0)
				{
					PeopleCount -= peopleCount;
					CurrentWeight -= peopleCount * PersonWeight;
				}
		}
	}
}
