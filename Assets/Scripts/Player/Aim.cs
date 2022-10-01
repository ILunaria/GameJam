using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    [SerializeField] private PlayerStatus status;
    [SerializeField] GameObject weapon;
    [SerializeField] Transform bulletSpawn;
    private Vector3 aimDirection;
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    Plane plane = new Plane(Vector3.down, 1);


    private void Awake()
    {
        PlayerInputs inputs = new PlayerInputs();
        inputs.Player.Enable();
        inputs.Player.Shoot.performed += ShootAction_Performed;
    }

    public void ShootAction_Performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnShootInput();
        }
    }
    // Update is called once per frame
    void Update()
    {
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
    private void OnShootInput()
    {
        Instantiate(status.bullet, bulletSpawn.position, Quaternion.LookRotation(aimDirection, Vector3.up));
    }

}
