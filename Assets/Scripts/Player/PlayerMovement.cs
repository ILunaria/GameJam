using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;
    private Rigidbody rb;
    private PlayerInputs inputs;
    private Vector2 moveDir;

    #region CHECK PARAMETERS
    //Set all of these up in the inspector
    [Header("Checks")]
    [SerializeField] private Transform _groundCheckPoint;
    //Size of groundCheck depends on the size of your character generally you want them slightly small than width (for ground) and height (for the wall check)
    [SerializeField] private Vector3 _groundCheckSize;
    #endregion

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask _groundLayer;
    #endregion
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
       rb.AddForce(new Vector3(input.x, 0, input.y) * _status.moveSpeed, ForceMode.Force);
    }
}
