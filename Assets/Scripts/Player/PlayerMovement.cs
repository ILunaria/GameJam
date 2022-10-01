using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;
    private Rigidbody rb;
    private PlayerInputs inputs;
    private Vector2 moveDir;
    // Start is called before the first frame update
    void Awake()
    {
        inputs = new PlayerInputs();
        inputs.Player.Enable();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(inputs.Player.Move.ReadValue<Vector2>());
    }

    private void Move(Vector2 input)
    {
       rb.velocity = new Vector3(input.x, 0, input.y) * (_status.MoveSpeed * 10) * Time.fixedDeltaTime;
       // rb.AddForce(new Vector3(input.x, 0, input.y) * speed, ForceMode.Force);
    }
}
