using UnityEngine;
using UnityEngine.InputSystem;
using VehicleGame.Input;

namespace VehicleGame.Gameplay.Player
{
    public class TurretAimPlane : MonoBehaviour
    {
        [Header("Rotation")]
        public float rotateSpeed = 10f;
        public float minY = -60f;
        public float maxY = 60f;

        [Header("Aim Detection")]
        public Transform planeOrigin;
        public float planeOffset = 20f;
        public Camera cam;

        private PlayerInputActions input;
        private Vector2 mousePos;
        private float targetY;

        private void Awake()
        {
            input = new PlayerInputActions();
            input.Player.Look.performed += ctx => mousePos = ctx.ReadValue<Vector2>();

        }

        private void OnEnable() => input.Player.Enable();
        private void OnDisable() => input.Player.Disable();

        private void Update()
        {
            AimTurret();
        }
        /// <summary>
        /// Rotate turren to mouse cursor
        /// </summary>
        private void AimTurret()
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = cam.ScreenPointToRay(mousePos);

            Vector3 planePoint = planeOrigin.position + planeOrigin.forward * planeOffset;
            Plane plane = new Plane(Vector3.up, planePoint);

            if (!plane.Raycast(ray, out float enter))
                return;

            Vector3 hitPos = ray.GetPoint(enter);

            Vector3 dir = hitPos - transform.position;
            dir.y = 0;

            if (dir.sqrMagnitude < 0.001f)
                return;

            float angle = Quaternion.LookRotation(dir, transform.parent.up).eulerAngles.y;
            if (angle > 180f) angle -= 360f;
            angle = Mathf.Clamp(angle, minY, maxY);
            targetY = angle;

            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, targetY, 0), rotateSpeed * Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            if (cam == null || planeOrigin == null) return;

            Vector3 planeCenter = planeOrigin.position + planeOrigin.forward * planeOffset;
            Vector3 size = new Vector3(20, 0, 20);
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(planeCenter, size);

            Ray ray = cam.ScreenPointToRay(mousePos);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * 200f);
        }

    }
}
