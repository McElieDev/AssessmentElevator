/// <summary>
///  An interface that defines the contract for the elevator controller. 
///  It includes methods for calling an elevator and displaying the elevator status.
/// </summary>

namespace DVTElevatorAssessment.CustomClass
{
    public interface IElevatorController
    {
        void CallElevator(int floorNumber, int peopleWaiting);
        void DisplayElevatorStatus();
    }
}