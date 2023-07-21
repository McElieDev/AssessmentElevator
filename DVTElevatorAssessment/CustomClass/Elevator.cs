using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DVTElevatorAssessment.CustomClass
{
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

        public void MoveToFloor(int floorNumber)
        {
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

            IsMoving = false; // Set IsMoving to false after the movement is completed.
            CurrentDirection = Direction.Idle;
        }

        public bool IsAvailable()
        {
            return !IsMoving && PeopleCount < Capacity && CurrentWeight < WeightLimit;
        }

        public void AddPeople(int peopleCount)
        {
            int additionalWeight = peopleCount * PersonWeight;
            int newWeight = CurrentWeight + additionalWeight;

            if (PeopleCount + peopleCount <= Capacity && newWeight <= WeightLimit)
            {
                PeopleCount += peopleCount;
                CurrentWeight = newWeight;
            }
            else
            {
                WriteLine("Elevator is at capacity. Cannot add more people.");
            }
        }

        public void RemovePeople(int peopleCount)
        {
            if (PeopleCount - peopleCount >= 0)
            {
                int removedWeight = peopleCount * PersonWeight;
                PeopleCount -= peopleCount;
                CurrentWeight -= removedWeight;
            }
        }
    }
}
