using UnityEngine;
using UnityEngine.InputSystem;

public class UIAim : MonoBehaviour
{
    private Vector3 screenPosition;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Update is called once per frame
    void Update()
    {
        screenPosition = Mouse.current.position.ReadValue();

        transform.position = screenPosition;
    }
}
