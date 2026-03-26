using UnityEngine;
using UnityEngine.InputSystem;
using VehicleGame.Input;

namespace VehicleGame.Gameplay.Player
{
    public class TurretFire : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private Transform firePoint;

        private PlayerInputActions input;

        private void Awake()
        {
            input = new PlayerInputActions();
            input.Player.Attack.performed += _ => Shoot();
        }

        private void OnEnable() => input.Player.Enable();
        private void OnDisable() => input.Player.Disable();

        //Shooting in turret
        private void Shoot()
        {
            GameObject b = BulletPool.Instance.Get();

            b.transform.position = firePoint.position;
            b.transform.rotation = firePoint.rotation;
            b.SetActive(true);
        }
    }
}
