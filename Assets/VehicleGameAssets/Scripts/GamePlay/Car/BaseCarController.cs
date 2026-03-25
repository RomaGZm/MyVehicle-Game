using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using VehicleGame.Input;

public class BaseCarController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 12f;         // Auto-move forward
    public float horizontalSpeed = 8f;       // Horizontal control speed
    public float limitX = 3.5f;              // X movement borders

    [Header("Car Tilt Settings")]
    public float tiltAmount = 20f;           // Tilt angle on turn (degrees)
    public float tiltSpeed = 8f;             // Smooth tilt speed

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
    void Update()
    {
        MoveForward();
        MoveHorizontal();
        TiltCar();
    }

    public virtual void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 v = ctx.ReadValue<Vector2>();
        inputX = v.x;
    }
    public virtual void MoveForward()
    {
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
    }
    public virtual void MoveHorizontal()
    {
        Vector3 pos = transform.position;
        pos.x += inputX * horizontalSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -limitX, limitX);
        transform.position = pos;
    }
    public virtual void TiltCar()
    {
        float targetTilt = -inputX * tiltAmount;
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);

        Vector3 angles = transform.localEulerAngles;
        angles.z = currentTilt;
        transform.localEulerAngles = angles;
    }
   
}
