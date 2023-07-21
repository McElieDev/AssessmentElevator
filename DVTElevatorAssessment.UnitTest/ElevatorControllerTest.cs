using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DVTElevatorAssessment.CustomClass;

namespace DVTElevatorAssessment.UnitTest
{
    [TestClass]
    public class ElevatorControllerTest
    {
        [TestMethod]
        public void TestCallElevator()
        {
            var elevatorController = new ElevatorController(2, 5, 10, 700); // 2 elevators, 5 floors, capacity 10, weight limit 700 kg

            elevatorController.SetPeopleWaiting(3, 8);
            elevatorController.SetPeopleWaiting(5, 4);

            elevatorController.CallElevator(3);
            Assert.AreEqual(3, elevatorController.Elevators[0].CurrentFloor, "Elevator 1 should be on floor 3");

            elevatorController.CallElevator(5);
            Assert.AreEqual(5, elevatorController.Elevators[1].CurrentFloor, "Elevator 2 should be on floor 5");
        }

        [TestMethod]
        public void TestElevatorCapacityAndWeightLimit()
        {
            var elevator = new Elevator(5, 250); // Capacity: 5, Weight Limit: 250 kg

            elevator.AddPeople(3); // Each person weighs 70 kg, so total weight: 210 kg
            Assert.AreEqual(3, elevator.PeopleCount, "Elevator should have 3 people");
            Assert.AreEqual(210, elevator.CurrentWeight, "Elevator weight should be 210 kg");

            elevator.AddPeople(2); // Adding 2 more people, exceeding capacity
            Assert.AreEqual(3, elevator.PeopleCount, "Elevator should still have 3 people");
            Assert.AreEqual(210, elevator.CurrentWeight, "Elevator weight should still be 210 kg");

            elevator.RemovePeople(1);
            Assert.AreEqual(2, elevator.PeopleCount, "Elevator should have 2 people");
            Assert.AreEqual(140, elevator.CurrentWeight, "Elevator weight should be 140 kg");

            elevator.AddPeople(4); // Adding 4 more people, exceeding weight limit
            Assert.AreEqual(2, elevator.PeopleCount, "Elevator should still have 2 people");
            Assert.AreEqual(140, elevator.CurrentWeight, "Elevator weight should still be 140 kg");
        }

        [TestMethod]
        public void TestElevatorMovement()
        {
            var elevator = new Elevator(10, 700); // Capacity: 10, Weight Limit: 700 kg

            elevator.MoveToFloor(5);
            Assert.AreEqual(5, elevator.CurrentFloor, "Elevator should be on floor 5");

            elevator.MoveToFloor(7);
            Assert.AreEqual(7, elevator.CurrentFloor, "Elevator should be on floor 7");

            elevator.MoveToFloor(3);
            Assert.AreEqual(3, elevator.CurrentFloor, "Elevator should be on floor 3");
        }
    }
}
