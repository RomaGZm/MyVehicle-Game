using UnityEngine;
using UnityEngine.InputSystem;
using VehicleGame.Input;

public class CarController : BaseCarController
{

    // Auto-forward movement
    public override void MoveForward()
    {
       base.MoveForward();
    }

    public override void OnMove(InputAction.CallbackContext ctx)
    {
       base.OnMove(ctx);
    }

    // Horizontal control with clamping
    public override void MoveHorizontal()
    {
       base.MoveHorizontal();
    }

    // Smooth tilt of the car when steering
    public override void TiltCar()
    {
       base.TiltCar();
    }
}