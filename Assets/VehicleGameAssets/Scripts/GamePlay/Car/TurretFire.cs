using UnityEngine;
using UnityEngine.InputSystem;
using VehicleGame.Input;

public class TurretFire : MonoBehaviour
{
    public Transform firePoint;

    private PlayerInputActions input;

    private void Awake()
    {
        input = new PlayerInputActions();
        input.Player.Attack.performed += _ => Shoot();
    }

    private void OnEnable() => input.Player.Enable();
    private void OnDisable() => input.Player.Disable();

    private void Shoot()
    {
        GameObject b = BulletPool.Instance.Get();

        b.transform.position = firePoint.position;
        b.transform.rotation = firePoint.rotation;
        b.SetActive(true);
    }
}