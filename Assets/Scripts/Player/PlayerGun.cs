using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{

    [SerializeField] private PlayerStatus status;
    [SerializeField] GameObject weapon;
    [SerializeField] Transform bulletSpawn;
    float timeSinceLastShoot;
    PlayerInputs inputs;
    private Vector3 aimDirection;
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    Plane plane = new Plane(Vector3.down, 0.7f);
    private PauseUI pause;
    private void Start()
    {
        pause = FindObjectOfType<PauseUI>().GetComponent<PauseUI>();
        inputs = new PlayerInputs();
        inputs.Player.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        if (pause.isPaused) return;
        timeSinceLastShoot += Time.deltaTime;
        if (inputs.Player.Shoot.IsPressed())
        {
            OnShootInput();
        }

        screenPosition = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (plane.Raycast(ray, out float distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        worldPosition.y = weapon.transform.position.y;

        aimDirection = Vector3.Normalize(worldPosition - transform.position);
        weapon.transform.forward = Vector3.Lerp(weapon.transform.forward, aimDirection, 20f * Time.deltaTime);
    }
    private bool CanShoot() => timeSinceLastShoot > 1f / (status.fireRate / 60);
    private void OnShootInput()
    {
        if (CanShoot())
        {
            Instantiate(status.bullet, bulletSpawn.position, Quaternion.LookRotation(aimDirection, Vector3.up));

            timeSinceLastShoot = 0f;
        }
    }

}
