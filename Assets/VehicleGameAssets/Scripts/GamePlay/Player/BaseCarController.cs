
using UnityEngine;
using UnityEngine.InputSystem;
using VehicleGame.Input;

namespace VehicleGame.Gameplay.Player
{
    public class BaseCarController : MonoBehaviour
    {
        [Header("Controllers")]
        public CarHealth carHealth;

        [Header("Movement Settings")]
        public float forwardSpeed = 12f;
        public float horizontalSpeed = 8f;
        public float limitX = 3.5f;

        [Header("Car Tilt Settings")]
        public float tiltAmount = 20f;
        public float tiltSpeed = 8f;

        protected PlayerInputActions input;

        protected float inputX;
        protected float currentTilt;

        private void Awake()
        {
            input = new();
        }

        void OnEnable()
        {
            input.Enable();
            input.Player.Move.performed += OnMove;
            input.Player.Move.canceled += OnMove;
        }

        void OnDisable()
        {
            input.Player.Move.performed -= OnMove;
            input.Player.Move.canceled -= OnMove;
            input.Disable();
        }

        private void Update()
        {
            if (GameplayManager.Instance.isPause) { return; }
            MoveForward();
            MoveHorizontal();
            TiltCar();
        }
        /// <summary>
        /// Input
        /// </summary>
        /// <param name="ctx"></param>
        public virtual void OnMove(InputAction.CallbackContext ctx)
        {
            Vector2 v = ctx.ReadValue<Vector2>();
            inputX = v.x;
        }
        /// <summary>
        /// Forward movement
        /// </summary>
        public virtual void MoveForward()
        {
            transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
        }
        /// <summary>
        /// Horizontal movement
        /// </summary>
        public virtual void MoveHorizontal()
        {
            Vector3 pos = transform.position;
            pos.x += inputX * horizontalSpeed * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, -limitX, limitX);
            transform.position = pos;
        }
        /// <summary>
        /// Tilt Car
        /// </summary>
        public virtual void TiltCar()
        {
            float targetTilt = -inputX * tiltAmount;
            currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);

            Vector3 angles = transform.localEulerAngles;
            angles.z = currentTilt;
            transform.localEulerAngles = angles;
        }

    }

}

