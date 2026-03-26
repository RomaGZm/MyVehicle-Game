using UnityEngine.InputSystem;


namespace VehicleGame.Gameplay.Player
{
    public class CarController : BaseCarController
    {
        public override void MoveForward()
        {
            base.MoveForward();
        }

        public override void OnMove(InputAction.CallbackContext ctx)
        {
            base.OnMove(ctx);
        }

        public override void MoveHorizontal()
        {
            base.MoveHorizontal();
        }

        public override void TiltCar()
        {
            base.TiltCar();
        }
    }
}
